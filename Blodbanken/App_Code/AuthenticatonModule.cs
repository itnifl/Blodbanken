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

namespace Blodbanken.App_Code {
   public enum UserRole {
      Admin,
      Viewer,
      Donor
   }
   public class AuthenticatonModule : RoleProvider{
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
         // Convert the input string to a byte array and compute the hash.
         byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

         // Create a new Stringbuilder to collect the bytes
         // and create a string.
         StringBuilder sBuilder = new StringBuilder();

         // Loop through each byte of the hashed data 
         // and format each one as a hexadecimal string.
         for (int i = 0; i < data.Length; i++) {
            sBuilder.Append(data[i].ToString("x2"));
         }

         // Return the hexadecimal string.
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
            SqlCommand cmd = new SqlCommand("Select userRole from Users where logonName='@userName'", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 35);
            cmd.Parameters["@userName"].Value = username;

            role = (String)cmd.ExecuteScalar();

            cmd.Dispose();
            conn.Dispose();
         }
         return role == roleName ? true : false;
      }

      public override string[] GetRolesForUser(string username) {
         throw new NotImplementedException();
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
   //http://www.codeproject.com/Articles/607392/Custom-Role-Providers
   public class UserIdentity : IIdentity, IPrincipal {
      private readonly FormsAuthenticationTicket _ticket;
      private AuthenticatonModule _authMod;

      public UserIdentity(FormsAuthenticationTicket ticket) {
         _ticket = ticket;
      }
      public UserIdentity(FormsAuthenticationTicket ticket, AuthenticatonModule AuthMod) {
         _ticket = ticket;
         _authMod = AuthMod;
      }


      public string AuthenticationType {
         get { return "User"; }
      }

      public bool IsAuthenticated {
         get { return true; }
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
}