using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Web;
using System.Security.Principal;

namespace Blodbanken.CodeEngines {
   public enum UserRole {
      Admin,
      Viewer,
      Donor
   }
   public class AuthenticatonModule : RoleProvider {
      private const int SaltValueSize = 4;
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public override string ApplicationName {
         get {
            throw new NotImplementedException();
         }

         set {
            throw new NotImplementedException();
         }
      }

      public bool CreateUser(string userName, string passWord, UserRole role) {
         int rowsUpdated = 0;
         if (ValidateCredentialData(userName, passWord)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users values(@userName,@passWord,@userRole)", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
            cmd.Parameters["@userName"].Value = userName;

            string hashedPassword = String.Empty;
            using (MD5 md5Hash = MD5.Create()) {
               hashedPassword = GetMd5Hash(md5Hash, passWord);
            }
            cmd.Parameters.Add("@passWord", SqlDbType.VarChar, 35);
            cmd.Parameters["@passWord"].Value = hashedPassword;

            cmd.Parameters.Add("@userRole", SqlDbType.VarChar, 35);
            cmd.Parameters["@userRole"].Value = role.ToString();

            rowsUpdated = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Dispose();
         }
         return rowsUpdated == 0 ? false : true;
      }
      public bool UpdatePassword(string userName, string passWord) {
         int rowsUpdated = 0;
         if (ValidateCredentialData(userName, passWord)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET password=@passWord WHERE logonName=@userName", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
            cmd.Parameters["@userName"].Value = userName;
            string hashedPassword = String.Empty;
            using (MD5 md5Hash = MD5.Create()) {
               hashedPassword = GetMd5Hash(md5Hash, passWord);
            }
            cmd.Parameters.Add("@passWord", SqlDbType.VarChar, 35);
            cmd.Parameters["@passWord"].Value = hashedPassword;

            rowsUpdated = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Dispose();
         }
         return rowsUpdated == 0 ? false : true;
      }
      public bool ValidateUser(string userName, string passWord) {
         string lookupPasswordHash = null;

         if (ValidateCredentialData(userName, passWord)) {
            try {
               SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
               conn.Open();

               SqlCommand cmd = new SqlCommand("Select password from Users where logonName=@userName", conn);
               cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
               cmd.Parameters["@userName"].Value = userName;

               lookupPasswordHash = (string)cmd.ExecuteScalar();

               cmd.Dispose();
               conn.Dispose();
            } catch (Exception ex) {
               System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            if (null == lookupPasswordHash) {
               // Could write failed login attempts here to event log for additional security.
               return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            string hashedPassword = String.Empty;
            bool passwordsAreEqual = false;
            using (MD5 md5Hash = MD5.Create()) {
               passwordsAreEqual = VerifyMd5Hash(md5Hash, passWord, lookupPasswordHash);
            }
            return passwordsAreEqual;
         }
         return lookupPasswordHash == passWord;
      }
      private static bool ValidateCredentialData(string userName, string passWord) {
         if ((null == userName) || (0 == userName.Length) || (userName.Length > 15)) {
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
            return false;
         }

         if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25)) {
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
            return false;
         }
         return true;
      }
      private static string GetMd5Hash(MD5 md5Hash, string input) {
         byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
         StringBuilder sBuilder = new StringBuilder();

         for (int i = 0; i < data.Length; i++) {
            sBuilder.Append(data[i].ToString("x2"));
         }

         return sBuilder.ToString();
      }
      private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash) {
         // Hash the input.
         string hashOfInput = GetMd5Hash(md5Hash, input);

         // Create a StringComparer an compare the hashes.
         StringComparer comparer = StringComparer.OrdinalIgnoreCase;

         if (0 == comparer.Compare(hashOfInput, hash)) {
            return true;
         } else {
            return false;
         }
      }

      public override bool IsUserInRole(string username, string roleName) {
         string role = String.Empty;
         if (ValidateCredentialData(username, roleName)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select userRole from Users where logonName=@userName", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
            cmd.Parameters["@userName"].Value = username;

            role = (String)cmd.ExecuteScalar();

            cmd.Dispose();
            conn.Dispose();
         }
         return role == roleName ? true : false;
      }

      public override string[] GetRolesForUser(string username) {
         string role = String.Empty;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("Select userRole from Users where logonName=@userName", conn);
         cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
         cmd.Parameters["@userName"].Value = username;

         role = (String)cmd.ExecuteScalar();

         cmd.Dispose();
         conn.Dispose();
         return new string[] { role };
      }
      public List<SystemUser> GetAllUsers() {
         List<SystemUser> users = new List<SystemUser>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("Select logonName, userRole, firstName, lastName from Users where firstName IS NOT NULL", conn);
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            string readerRole = reader["userRole"].ToString();
            UserRole role = readerRole == "Admin" ? UserRole.Admin : (readerRole == "Viewer" ? UserRole.Viewer : UserRole.Donor);
            users.Add(new SystemUser(reader["logonName"].ToString(), role, reader["firstName"].ToString(), reader["lastName"].ToString()));
         }
         cmd.Dispose();
         reader.Close();

         cmd = new SqlCommand("Select logonName, userRole from Users where firstName IS NULL", conn);
         reader = cmd.ExecuteReader();
         while (reader.Read()) {
            string readerRole = reader["userRole"].ToString();
            UserRole role = readerRole == "Admin" ? UserRole.Admin : (readerRole == "Viewer" ? UserRole.Viewer : UserRole.Donor);
            users.Add(new SystemUser(reader["logonName"].ToString(), role));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return users;
      }
      public SystemUser GetUser(string logonName) {
         SystemUser user = new SystemUser();
         if (String.IsNullOrEmpty(logonName)) return user;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("Select logonName, password, userRole, firstName, lastName, phoneNumber, age, address, persInfoConsent from Users where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;

         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            string readerRole = reader["userRole"].ToString();
            UserRole role = readerRole == "Admin" ? UserRole.Admin : (readerRole == "Viewer" ? UserRole.Viewer : UserRole.Donor);
            int age, persInfoConsent;
            Int32.TryParse(reader["age"].ToString(), out age);
            Int32.TryParse(reader["persInfoConsent"].ToString(), out persInfoConsent);
            string logonNameInput = reader["logonName"] != null ? reader["logonName"].ToString() : String.Empty;
            string passwordImput = reader["password"] != null ? reader["password"].ToString() : String.Empty;
            string firstNameInput = reader["firstName"] != null ? reader["firstName"].ToString() : String.Empty;
            string lastNameInput = reader["lastName"] != null ? reader["lastName"].ToString() : String.Empty;
            string phoneNumberInput = reader["phoneNumber"] != null ? reader["phoneNumber"].ToString() : String.Empty;
            string addressInput = reader["address"] != null ? reader["address"].ToString() : String.Empty;
            user = new SystemUser(logonNameInput, passwordImput, role, firstNameInput, lastNameInput, phoneNumberInput, age, addressInput, persInfoConsent != 0);
         }
         cmd.Dispose();
         reader.Close();

         conn.Dispose();
         return user;
      }

      public override void CreateRole(string roleName) {
         throw new NotImplementedException();
      }

      public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
         throw new NotImplementedException();
      }

      public override bool RoleExists(string roleName) {
         throw new NotImplementedException();
      }

      public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
         throw new NotImplementedException();
      }

      public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
         throw new NotImplementedException();
      }

      public override string[] GetUsersInRole(string roleName) {
         throw new NotImplementedException();
      }

      public override string[] GetAllRoles() {
         throw new NotImplementedException();
      }

      public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
         throw new NotImplementedException();
      }
   }
   public class UserIdentity : IIdentity, IPrincipal {
      private readonly FormsAuthenticationTicket _ticket;
      private AuthenticatonModule _authMod;
      private bool _isAuthenticated;

      public UserIdentity(FormsAuthenticationTicket ticket) {
         _ticket = ticket;
         _isAuthenticated = true;
      }
      public UserIdentity(FormsAuthenticationTicket ticket, AuthenticatonModule AuthMod) {
         _ticket = ticket;
         _authMod = AuthMod;
         _isAuthenticated = true;
      }
      public UserIdentity() {
         _ticket = new FormsAuthenticationTicket(String.Empty, false, 1);
         _authMod = null;
         _isAuthenticated = false;
      }
      public string AuthenticationType {
         get { return "Forms"; }
      }
      public bool IsAuthenticated {
         get { return _isAuthenticated; }
         set { _isAuthenticated = value; }
      }
      public string Name {
         get { return _ticket.Name; }
      }

      public string UserId {
         get { return _ticket.UserData; }
      }

      public bool IsInRole(string role) {
         return _authMod.IsUserInRole(this.Name, role);
      }

      public IIdentity Identity {
         get { return this; }
      }
   }
   public class SystemUser {
      public string LogonName { get; set; }
      public string Password { get; set; }
      public UserRole UserRole { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public int Age { get; set; } = 0;
      public string Address { get; set; }
      public bool PersInfoConsent { get; set; } = false;
      public SystemUser() {
         this.LogonName = null;
         this.Password = null;
         this.UserRole = UserRole.Viewer;
         this.FirstName = null;
         this.LastName = null;
         this.PhoneNumber = null;
         this.Age = 0;
         this.Address = null;
         this.PersInfoConsent = false;
      }
      public SystemUser(string logonName, string password, UserRole userRole, string firstName, string lastName, string phoneNumber, int age, string address, bool persInfoConsent) {
         this.LogonName = logonName;
         this.Password = password;
         this.UserRole = userRole;
         this.FirstName = firstName;
         this.LastName = lastName;
         this.PhoneNumber = phoneNumber;
         this.Age = age;
         this.Address = address;
         this.PersInfoConsent = persInfoConsent;
      }
      public SystemUser(string logonName, UserRole userRole, string firstName, string lastName) {
         this.LogonName = logonName;
         this.UserRole = userRole;
         this.FirstName = firstName;
         this.LastName = lastName;
      }
      public SystemUser(string logonName, UserRole userRole) {
         this.LogonName = logonName;
         this.UserRole = userRole;
      }
   }
}