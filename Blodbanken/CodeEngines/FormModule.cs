using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blodbanken.CodeEngines;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Security.Principal;
using System.Reflection;

namespace Blodbanken.CodeEngines {
   public class FormModule {
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public bool DeleteForm(int schemaID) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("DELETE FROM Schema WHERE schemaID=@schemaID", conn);
         cmd.Parameters.Add("@schemaID", SqlDbType.Int);
         cmd.Parameters["@schemaID"].Value = schemaID;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();
         return rowsUpdated == 0 ? false : true;
      }
      public bool SetSMSAccept(string logonName, bool phoneConsent) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("UPDATE Users SET phoneConsent=@phoneConsent WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         cmd.Parameters.Add("@phoneConsent", SqlDbType.Int);
         cmd.Parameters["@phoneConsent"].Value = phoneConsent ? 1 : 0;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();
         return rowsUpdated == 0 ? false : true;
      }
      public bool GetSMSAccept(string logonName) {
         int? phoneConsent;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("SELECT phoneConsent FROM Users WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         phoneConsent = ConvertTo.GetValue<int?>(cmd.ExecuteScalar());
         cmd.Dispose();
         conn.Dispose();
         return phoneConsent.HasValue ? (phoneConsent == 0 ? false : true) : false;
      }
      public bool SetPersInfoAccept(string logonName, bool persInfoConsent) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("UPDATE Users SET persInfoConsent=@persInfoConsent WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         cmd.Parameters.Add("@persInfoConsent", SqlDbType.Int);
         cmd.Parameters["@persInfoConsent"].Value = persInfoConsent ? 1 : 0;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();

         return rowsUpdated == 0 ? false : true;
      }
      public bool GetPersInfoAccept(string logonName) {
         int? phoneConsent;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("SELECT persInfoConsent FROM Users WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         phoneConsent = ConvertTo.GetValue<int?>(cmd.ExecuteScalar());
         cmd.Dispose();
         conn.Dispose();
         return phoneConsent.HasValue ? (phoneConsent == 0 ? false : true) : false ;
      }
      public bool SetMailAccept(string logonName, bool eMailConsent) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("UPDATE Users SET eMailConsent=@eMailConsent WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         cmd.Parameters.Add("@eMailConsent", SqlDbType.Int);
         cmd.Parameters["@eMailConsent"].Value = eMailConsent ? 1 : 0;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();

         return rowsUpdated == 0 ? false : true;
      }
      public bool GetMailAccept(string logonName) {
         int? eMailConsent;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("SELECT eMailConsent FROM Users WHERE logonName=@logonName", conn);
         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = logonName;
         eMailConsent = ConvertTo.GetValue<int?>(cmd.ExecuteScalar());
         cmd.Dispose();
         conn.Dispose();
         return eMailConsent.HasValue ? (eMailConsent == 0 ? false : true) : false;
      }
      public bool PutUserSchemaForm(Schema userSchema) {
         throw new NotImplementedException();
      }
      public List<Schema> GetUserSchemaForm(string logonName) {
         List<Schema> schemas = new List<Schema>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.[Schema] WHERE logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = String.IsNullOrEmpty(logonName) ? "UNKNOWN" : logonName;
         var reader = cmd.ExecuteReader();
         List<string> columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
         columns.Sort();

         // read each record
         while (reader.Read()) {
            Schema theSchema = new Schema();
            foreach (string column in columns) {
               Type myType = typeof(Schema);
               PropertyInfo myPropInfo = myType.GetProperty(column);
               if (column == "approved") {
                  DateTime dtResult;
                  DateTime.TryParse(reader[column] != null ? reader[column].ToString() : String.Empty, out dtResult);
                  myPropInfo.SetValue(this, dtResult, null);
               } else if (column.ToLower() == "logonname") {
                  myPropInfo.SetValue(this, reader[column] != null ? reader[column].ToString() : String.Empty, null);
               } else {
                  int intResult;
                  Int32.TryParse(reader[column] != null ? reader[column].ToString() : "0", out intResult);
                  myPropInfo.SetValue(this, intResult, null);
               }
            }
            schemas.Add(theSchema);
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return schemas;
      }
   }
   public class Schema {
      public string logonName { get; set; }
      public DateTime approved { get; set; }
      public int? schemaID { get; set; }
      public int spm1 { get; set; }
      public int spm2 { get; set; }
      public int spm3 { get; set; }
      public int spm4 { get; set; }
      public int spm5 { get; set; }
      public int spm6 { get; set; }
      public int spm7 { get; set; }
      public int spm8 { get; set; }
      public int spm9 { get; set; }
      public int spm10 { get; set; }
      public int spm11 { get; set; }
      public int spm12 { get; set; }
      public int spm13 { get; set; }
      public int spm14 { get; set; }
      public int spm15 { get; set; }
      public int spm16 { get; set; }
      public int spm17 { get; set; }
      public int spm18 { get; set; }
      public int spm19 { get; set; }
      public int spm20 { get; set; }
      public int spm21 { get; set; }
      public int spm22 { get; set; }
      public int spm23 { get; set; }
      public int spm24 { get; set; }
      public int spm25 { get; set; }
      public int spm26 { get; set; }
      public int spm27 { get; set; }
      public int spm28 { get; set; }
      public int spm29 { get; set; }
      public int spm30 { get; set; }
      public int spm31 { get; set; }
      public int spm32 { get; set; }
      public int spm33 { get; set; }
      public int spm34 { get; set; }
      public int spm35 { get; set; }
      public int spm36 { get; set; }
      public int spm37 { get; set; }
      public int spm38 { get; set; }
      public int spm39 { get; set; }
      public int spm40 { get; set; }
      public int spm41 { get; set; }
      public int spm42 { get; set; }
      public int spm43 { get; set; }
      public int spm44 { get; set; }
      public int spm45 { get; set; }
      public int spm46 { get; set; }
      public int spm47 { get; set; }
      public int spm48 { get; set; }
      public int spm49 { get; set; }
      public int spm50 { get; set; }
      public int spm51 { get; set; }
      public int spm52 { get; set; }
      public int spm53 { get; set; }
      public int spm54 { get; set; }
      public int spm55 { get; set; }
      public int spm56 { get; set; }
      public int spm57 { get; set; }
      public int spm58 { get; set; }
      public int spm59 { get; set; }
      public int spm60 { get; set; }

   }
}