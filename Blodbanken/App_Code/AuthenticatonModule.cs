using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace Blodbanken.App_Code {
   public class AuthenticatonModule {
      private const int SaltValueSize = 4;
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public void UpdatePassword(string userName, string passWord) {
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

            int result = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Dispose();
         }
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
   }
}