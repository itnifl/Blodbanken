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
   public class TimeBooker {
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public List<ParkspaceBooking> GetFutureParkspaceBookingsForDonors(string logonName) {
         List<ParkspaceBooking> bookings = new List<ParkspaceBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
          
         SqlCommand cmd = new SqlCommand("SELECT PB.bookingID AS bookingID, PB.bookingDate AS bookingDate, PB.parkingSpace AS parkingSpace, DB.logonName AS logonName FROM DonorBooking AS DB JOIN ParkspaceBooking AS PB ON (DB.parkingID=PB.parkingSpace) WHERE DB.logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;

         var reader = cmd.ExecuteReader();

         while (reader.Read()) {
            DateTime dtResult;
            int bookingID, parkingSpace = 0;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            Int32.TryParse(reader["parkingSpace"] != null ? reader["parkingSpace"].ToString() : String.Empty, out parkingSpace);
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);
            if (dtResult != null && parkingSpace != 0) bookings.Add(new ParkspaceBooking(bookingID, dtResult, parkingSpace));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         
         return bookings;
      }
      public List<DonorBooking> GetUserDonorBookings(string logonName) {
         List<DonorBooking> bookings = new List<DonorBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT bookingID, bookingDate, logonName from DonorBooking where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);
            if (dtResult != null) bookings.Add(new DonorBooking(bookingID, dtResult, readLogonName));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }
      public List<ExaminationBooking> GetUserExaminationBookings(string logonName) {
         List<ExaminationBooking> bookings = new List<ExaminationBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT bookingID, bookingDate, logonName from ExaminationBooking where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult); 
            if(dtResult != null) bookings.Add(new ExaminationBooking(bookingID, dtResult, readLogonName));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }
      public List<Schema> GetUserInfoForm(string logonName) {
         List<Schema> schemas = new List<Schema>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.[Schema] WHERE logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;
         var reader = cmd.ExecuteReader();
         List<string> columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
         columns.Sort();

         // read each record
         while (reader.Read()) {
            Schema theSchema = new Schema();
            foreach (string column in columns) {
               Type myType = typeof(Schema);
               PropertyInfo myPropInfo = myType.GetProperty(column);
               myPropInfo.SetValue(this, reader[column].ToString(), null);
            }
            schemas.Add(theSchema);
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return schemas;
      }
   }
   public class ExaminationBooking {
      public int BookingID { get; set; }
      public string LogonName { get; set; }
      public DateTime BookingDate { get; set; }
      public ExaminationBooking(int bookingID, DateTime bookingDate, string logonName) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
      }
   }
   public class DonorBooking {
      public int BookingID { get; set; }
      public string LogonName { get; set; }
      public DateTime BookingDate { get; set; }
      public DonorBooking(int bookingID, DateTime bookingDate, string logonName) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
      }
   }
   public class ParkspaceBooking {
      public int BookingID { get; set; }
      public int ParkingSpace { get; set; }
      public DateTime BookingDate { get; set; }
      public ParkspaceBooking(int bookingID, DateTime bookingDate, int parkingSpace) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.ParkingSpace = parkingSpace;
      }
   }
   public class Schema {
      public string logonName { get; set; }
      public int schemaID { get; set; }
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