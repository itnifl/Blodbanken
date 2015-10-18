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
      private const string HashingAlgorithm = "SHA256";

      public void UpdatePassword(string userName, string passWord) {
         if (ValidateCredentialData(userName, passWord)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath("App_Data/Privileges.mdf"));
            SqlCommand cmd = new SqlCommand("UPDATE Users SET password=@passWord WHERE logonName=@userName", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
            cmd.Parameters["@userName"].Value = userName;

            string hashedPassword = GetTheHashedValue(passWord);
            cmd.Parameters.Add("@passWord", SqlDbType.VarChar, 25);
            cmd.Parameters["@passWord"].Value = hashedPassword;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Dispose();
         }
      }
      public bool ValidateUser(string userName, string passWord) {
         SqlConnection conn;
         SqlCommand cmd;
         string lookupPassword = null;

         if (ValidateCredentialData(userName, passWord)) {
            try {
               conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath("App_Data/Privileges.mdf"));
               conn.Open();

               cmd = new SqlCommand("Select password from Users where logonName=@userName", conn);
               cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
               cmd.Parameters["@userName"].Value = userName;

               lookupPassword = (string)cmd.ExecuteScalar();

               cmd.Dispose();
               conn.Dispose();
            } catch (Exception ex) {
               System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            if (null == lookupPassword) {
               // Could write failed login attempts here to event log for additional security.
               return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            string hashedPassword = GetTheHashedValue(passWord);
            return lookupPassword.Equals(hashedPassword, StringComparison.Ordinal)
         }
         return false;
      }
      private static string GenerateSaltValue() {
         UnicodeEncoding utf16 = new UnicodeEncoding();

         if (utf16 != null) {
            // Create a random number object seeded from the value
            // of the last random seed value. This is done
            // interlocked because it is a static value and we want
            // it to roll forward safely.

            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            if (random != null) {
               // Create an array of random values.

               byte[] saltValue = new byte[SaltValueSize];

               random.NextBytes(saltValue);

               // Convert the salt value to a string. Note that the resulting string
               // will still be an array of binary values and not a printable string. 
               // Also it does not convert each byte to a double byte.

               string saltValueString = utf16.GetString(saltValue);

               // Return the salt value as a string.

               return saltValueString;
            }
         }

         return null;
      }

      private static string HashPassword(string clearData, string saltValue, HashAlgorithm hash) {
         UnicodeEncoding encoding = new UnicodeEncoding();

         if (clearData != null && hash != null && encoding != null) {
            // If the salt string is null or the length is invalid then
            // create a new valid salt value.

            if (saltValue == null) {
               // Generate a salt string.
               saltValue = GenerateSaltValue();
            }            

            // Convert the salt string and the password string to a single
            // array of bytes. Note that the password string is Unicode and
            // therefore may or may not have a zero in every other byte.

            byte[] binarySaltValue = new byte[SaltValueSize];

            binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
            binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
            binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
            binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

            byte[] valueToHash = new byte[SaltValueSize + encoding.GetByteCount(clearData)];
            byte[] binaryPassword = encoding.GetBytes(clearData);

            // Copy the salt value and the password to the hash buffer.

            binarySaltValue.CopyTo(valueToHash, 0);
            binaryPassword.CopyTo(valueToHash, SaltValueSize);

            byte[] hashValue = hash.ComputeHash(valueToHash);

            // The hashed password is the salt plus the hash value (as a string).

            string hashedPassword = saltValue;

            foreach (byte hexdigit in hashValue) {
               hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
            }

            // Return the hashed password as a string.

            return hashedPassword;
         }

         return null;
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
      private static string GetTheHashedValue(string passWord) {
         HashAlgorithm hash = HashAlgorithm.Create(HashingAlgorithm);
         int saltLength = SaltValueSize * UnicodeEncoding.CharSize;
         string saltValue = passWord.Substring(0, saltLength);
         return HashPassword(passWord, saltValue, hash);
      }
   }
}