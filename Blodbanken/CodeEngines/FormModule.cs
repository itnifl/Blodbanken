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
         SqlCommand cmd = new SqlCommand("DELETE FROM dbo.[Schema] WHERE schemaID=@schemaID", conn);
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
         int? phoneConsent = (int?)null;
         if(!String.IsNullOrEmpty(logonName)) {
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT persInfoConsent FROM Users WHERE logonName=@logonName", conn);
            cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
            cmd.Parameters["@logonName"].Value = logonName;
            phoneConsent = ConvertTo.GetValue<int?>(cmd.ExecuteScalar());
            cmd.Dispose();
            conn.Dispose();
         }
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
         Schema existingForm = this.GetUserSchemaForm(userSchema.logonName).Where(schema => schema.schemaID == userSchema.schemaID).FirstOrDefault();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         int rowsUpdated = 0;
         if (existingForm != null) {
            SqlCommand cmd = new SqlCommand("UPDATE dbo.[Schema] SET logonName=@logonName, spm1=@spm1, spm2=@spm2, spm3=@spm3, spm4=@spm4, spm5=@spm5, spm6=@spm6, spm7=@spm7, spm8=@spm8, spm9=@spm9, spm10=@spm10, spm11=@spm11, spm12=@spm12, spm13=@spm13, spm14=@spm14, spm15=@spm15, spm16=@spm16, spm17=@spm17, spm18=@spm18, spm19=@spm19, spm20=@spm20, spm21=@spm21, spm22=@spm22, spm23=@spm23, spm24=@spm24, spm25=@spm25, spm26=@spm26, spm27=@spm27, spm28=@spm28, spm29=@spm29, spm30=@spm30, spm31=@spm31, spm32=@spm32, spm33=@spm33, spm34=@spm34, spm35=@spm35, spm36=@spm36, spm37=@spm37, spm38=@spm38, spm39=@spm39, spm40=@spm40, spm41=@spm41, spm42=@spm42, spm43=@spm43, spm44=@spm44, spm45=@spm45, spm46=@spm46, spm47=@spm47, spm48=@spm48, spm49=@spm49, spm50=@spm50, spm51=@spm51, spm52=@spm52, spm53=@spm53, spm54=@spm54, spm55=@spm55, spm56=@spm56, spm57=@spm57, spm58=@spm58, spm59=@spm59, spm60=@spm60 WHERE schemaID=@schemaID", conn);
            foreach (PropertyInfo property in typeof(Schema).GetProperties()) {
               if (userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null).GetType() == "".GetType()) {
                  cmd.Parameters.Add("@" + property.Name, SqlDbType.VarChar, 35);
               }
               else if (userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null).GetType() == DateTime.Now.GetType()) {
                  cmd.Parameters.Add("@" + property.Name, SqlDbType.DateTime);
               }
               else {
                  cmd.Parameters.Add("@" + property.Name, SqlDbType.Int);
               }

               if (property.Name == "approved") {
                  DateTime dtTime = ((DateTime)userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null));
                  if (dtTime == null || dtTime == DateTime.MinValue) cmd.Parameters["@" + property.Name].Value = DBNull.Value;
                  else cmd.Parameters["@" + property.Name].Value = dtTime.ToString("MM/dd/yyyy");
               }
               else {
                  cmd.Parameters["@" + property.Name].Value = userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null);
               }
            }
            rowsUpdated = cmd.ExecuteNonQuery();
            cmd.Dispose();
         } else {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[Schema] (logonName,spm1,spm2,spm3,spm4,spm5,spm6,spm7,spm8,spm9,spm10,spm11,spm12,spm13,spm14,spm15,spm16,spm17,spm18,spm19,spm20,spm21,spm22,spm23,spm24,spm25,spm26,spm27,spm28,spm29,spm30,spm31,spm32,spm33,spm34,spm35,spm36,spm37,spm38,spm39,spm40,spm41,spm42,spm43,spm44,spm45,spm46,spm47,spm48,spm49,spm50,spm51,spm52,spm53,spm54,spm55,spm56,spm57,spm58,spm59,spm60) values(@logonName,@spm1,@spm2,@spm3,@spm4,@spm5,@spm6,@spm7,@spm8,@spm9,@spm10,@spm11,@spm12,@spm13,@spm14,@spm15,@spm16,@spm17,@spm18,@spm19,@spm20,@spm21,@spm22,@spm23,@spm24,@spm25,@spm26,@spm27,@spm28,@spm29,@spm30,@spm31,@spm32,@spm33,@spm34,@spm35,@spm36,@spm37,@spm38,@spm39,@spm40,@spm41,@spm42,@spm43,@spm44,@spm45,@spm46,@spm47,@spm48,@spm49,@spm50,@spm51,@spm52,@spm53,@spm54,@spm55,@spm56,@spm57,@spm58,@spm59,@spm60)", conn);
            foreach (PropertyInfo property in typeof(Schema).GetProperties()) {
               if(property.Name != "schemaID") {
                  if (userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null).GetType() == "".GetType()) {
                     cmd.Parameters.Add("@" + property.Name, SqlDbType.VarChar, 35);
                  }
                  else if (userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null).GetType() == DateTime.Now.GetType()) {
                     cmd.Parameters.Add("@" + property.Name, SqlDbType.DateTime);
                  }
                  else {
                     cmd.Parameters.Add("@" + property.Name, SqlDbType.Int);
                  }                                 
                  if (property.Name == "approved") {
                     DateTime dtTime = ((DateTime)userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null));
                     if (dtTime == null || dtTime == DateTime.MinValue) cmd.Parameters["@" + property.Name].Value = DBNull.Value;
                     else cmd.Parameters["@" + property.Name].Value = dtTime.ToString("MM/dd/yyyy");
                  }
                  else {
                     cmd.Parameters["@" + property.Name].Value = userSchema.GetType().GetProperty(property.Name).GetValue(userSchema, null);
                  }
               }
            }
            string query = cmd.CommandText;

            foreach (SqlParameter p in cmd.Parameters) {
               query = query.Replace(p.ParameterName, p.Value.ToString());
            }
            rowsUpdated = cmd.ExecuteNonQuery();
            cmd.Dispose();
         }
         
         conn.Dispose();
         return rowsUpdated != 0;
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
                  if(dtResult != null && dtResult != DateTime.MinValue) myPropInfo.SetValue(theSchema, dtResult, null);
               } else if (column.ToLower() == "logonname") {
                  myPropInfo.SetValue(theSchema, reader[column] != null && !String.IsNullOrEmpty(reader[column].ToString()) ? reader[column].ToString() : String.Empty, null);
               } else {
                  int intResult;
                  Int32.TryParse(reader[column] != null ? reader[column].ToString() : "0", out intResult);
                  myPropInfo.SetValue(theSchema, intResult, null);
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