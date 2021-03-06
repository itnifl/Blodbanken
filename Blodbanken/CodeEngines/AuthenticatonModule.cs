﻿using System;
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

      public bool DeleteUser(string userName) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE logonName=@userName", conn);
         cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
         cmd.Parameters["@userName"].Value = userName;
         rowsUpdated = cmd.ExecuteNonQuery();
         cmd.Dispose();
         conn.Dispose();
         return rowsUpdated == 0 ? false : true;
      }
      public bool CreateUser(string userName, string passWord, UserRole role) {
         int rowsUpdated = 0;
         if (ValidateCredentialData(userName, passWord)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
            conn.Open();

            SqlCommand checkExistance = new SqlCommand("SELECT * FROM Users WHERE logonName=@userName", conn);
            checkExistance.Parameters.Add("@userName", SqlDbType.VarChar, 35);
            checkExistance.Parameters["@userName"].Value = userName;

            var reader = checkExistance.ExecuteReader();
            if (!reader.HasRows) {
               reader.Close();
               checkExistance.Dispose();
               SqlCommand cmd = new SqlCommand("INSERT INTO Users (logonName,password,userRole) values(@userName,@passWord,@userRole)", conn);
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
            }
            else {
               reader.Close();
               checkExistance.Dispose();
            }            
            conn.Dispose();
         }
         return rowsUpdated == 0 ? false : true;
      }
      public bool UpdateUser(string logonName, UserRole userRole, string firstName = "",
            string lastName = "", string phoneMobile = "", int age = 0,
            string address = "", string nationalIdentity = "", string gender = "male", 
            string phoneWork = "", string phonePrivate = "", string eMail = "") {
         if (gender.ToLower() != "male" && gender.ToLower() != "female") {
            throw new NotSupportedException("Gender must be male or female, '" + gender + "' is not allowed");
         }
         int rowsUpdated = 0;
         
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("UPDATE Users SET logonName=@logonName, userRole=@userRole, firstName=@firstName, lastName=@lastName, phoneMobile=@phoneMobile, age=@age, address=@address, nationalIdentity=@nationalIdentity, gender=@gender, phoneWork=@phoneWork, phonePrivate=@phonePrivate, eMail=@eMail WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;

         cmd.Parameters.Add("@userRole", SqlDbType.VarChar, 35);
         cmd.Parameters["@userRole"].Value = userRole.ToString();

         cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 35);
         cmd.Parameters["@firstName"].Value = firstName;

         cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 35);
         cmd.Parameters["@lastName"].Value = lastName;

         cmd.Parameters.Add("@phoneMobile", SqlDbType.VarChar, 8);
         cmd.Parameters["@phoneMobile"].Value = phoneMobile;

         cmd.Parameters.Add("@age", SqlDbType.Int);
         cmd.Parameters["@age"].Value = age;

         cmd.Parameters.Add("@address", SqlDbType.VarChar, 400);
         cmd.Parameters["@address"].Value = address;        

         cmd.Parameters.Add("@nationalIdentity", SqlDbType.VarChar, 11);
         cmd.Parameters["@nationalIdentity"].Value = nationalIdentity;

         /*cmd.Parameters.Add("@persInfoConsent", SqlDbType.Int);
         cmd.Parameters["@persInfoConsent"].Value = persInfoConsent ? 1 : 0;

         cmd.Parameters.Add("@eMailConsent", SqlDbType.Int);
         cmd.Parameters["@eMailConsent"].Value = eMailConsent ? 1 : 0;

         cmd.Parameters.Add("@phoneConsent", SqlDbType.Int);
         cmd.Parameters["@phoneConsent"].Value = phoneConsent ? 1 : 0;*/

         cmd.Parameters.Add("@gender", SqlDbType.VarChar, 6);
         cmd.Parameters["@gender"].Value = gender.ToLower();

         cmd.Parameters.Add("@phoneWork", SqlDbType.VarChar, 8);
         cmd.Parameters["@phoneWork"].Value = phoneWork;

         cmd.Parameters.Add("@phonePrivate", SqlDbType.VarChar, 8);
         cmd.Parameters["@phonePrivate"].Value = phonePrivate;

         cmd.Parameters.Add("@eMail", SqlDbType.VarChar, 100);
         cmd.Parameters["@eMail"].Value = eMail;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();
         
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

         SqlCommand cmd = new SqlCommand("Select * from Users WHERE logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;

         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            string readerRole = reader["userRole"].ToString();
            UserRole role = readerRole == "Admin" ? UserRole.Admin : (readerRole == "Viewer" ? UserRole.Viewer : UserRole.Donor);
            int age = 0, persInfoConsent = 0, eMailConsent, phoneConsent;
            Int32.TryParse(reader["age"].ToString(), out age);
            Int32.TryParse(reader["persInfoConsent"].ToString(), out persInfoConsent);

            Int32.TryParse(reader["eMailConsent"].ToString(), out eMailConsent);
            Int32.TryParse(reader["phoneConsent"].ToString(), out phoneConsent);

            string nationalIdentity = reader["nationalIdentity"] != null ? reader["nationalIdentity"].ToString() : String.Empty;
            string logonNameInput = reader["logonName"] != null ? reader["logonName"].ToString() : String.Empty;
            string passwordImput = reader["password"] != null ? reader["password"].ToString() : String.Empty;
            string firstNameInput = reader["firstName"] != null ? reader["firstName"].ToString() : String.Empty;
            string lastNameInput = reader["lastName"] != null ? reader["lastName"].ToString() : String.Empty;
            string phoneMobileInput = reader["phoneMobile"] != null ? reader["phoneMobile"].ToString() : String.Empty;
            string addressInput = reader["address"] != null ? reader["address"].ToString() : String.Empty;

            string gender = reader["gender"] != null ? reader["gender"].ToString() : String.Empty;
            string phoneWork = reader["phoneWork"] != null ? reader["phoneWork"].ToString() : String.Empty;
            string phonePrivate = reader["phonePrivate"] != null ? reader["phonePrivate"].ToString() : String.Empty;
            string eMail = reader["eMail"] != null ? reader["eMail"].ToString() : String.Empty;

            user = new SystemUser(logonNameInput, passwordImput, role, firstNameInput, lastNameInput, 
               phoneMobileInput, age, addressInput, persInfoConsent != 0, nationalIdentity, eMailConsent != 0,
               phoneConsent != 0, gender, phoneWork, phonePrivate, eMail);
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
      public string PhoneMobile { get; set; }
      public int Age { get; set; } = 0;
      public string Address { get; set; }
      public bool PersInfoConsent { get; set; } = false;
      public string NationalIdentity { get; set; }
      public bool EMailConsent { get; set; } = false;
      public bool PhoneConsent { get; set; } = false;
      public string Gender { get; set; }
      public string PhoneWork { get; set; }
      public string PhonePrivate { get; set; }
      public string EMail { get; set; }
      public SystemUser() {
         this.LogonName = null;
         this.Password = null;
         this.UserRole = UserRole.Viewer;
         this.FirstName = null;
         this.LastName = null;
         this.PhoneMobile = null;
         this.Age = 0;
         this.Address = null;
         this.PersInfoConsent = false;
      }
      public SystemUser(string logonName, string password, UserRole userRole, string firstName, 
            string lastName, string phoneMobile, int age, string address, bool persInfoConsent,
            string nationalIdentity, bool eMailConsent, bool phoneConsent, string gender, string phoneWork, 
            string phonePrivate, string eMail) {
         this.LogonName = logonName;
         this.Password = password;
         this.UserRole = userRole;
         this.FirstName = firstName;
         this.LastName = lastName;
         this.PhoneMobile = phoneMobile;
         this.Age = age;
         this.Address = address;
         this.PersInfoConsent = persInfoConsent;

         this.NationalIdentity = nationalIdentity;
         this.EMailConsent = eMailConsent;
         this.PhoneConsent = phoneConsent;
         this.Gender = gender;
         this.PhoneWork = phoneWork;
         this.PhonePrivate = phonePrivate;
         this.EMail = eMail;
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