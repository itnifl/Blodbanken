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

      public bool SetExaminationBooking(ExaminationBooking booking) {
         int rowsUpdated = 0;
         List<ExaminationBooking> bookings = new List<ExaminationBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("UPDATE ExaminationBooking SET bookingDate=@bookingDate, examinationApproved=@examinationApproved, parkingID=@parkingID WHERE bookingID=@bookingID", conn);
         cmd.Parameters.Add("@bookingDate", SqlDbType.DateTime);
         cmd.Parameters["@bookingDate"].Value = booking.BookingDate;

         cmd.Parameters.Add("@examinationApproved", SqlDbType.Int);
         cmd.Parameters["@examinationApproved"].Value = booking.ExaminationApproved;

         cmd.Parameters.Add("@bookingID", SqlDbType.Int);
         cmd.Parameters["@bookingID"].Value = booking.BookingID;

         cmd.Parameters.Add("@oarkingID", SqlDbType.Int);
         cmd.Parameters["@parkingID"].Value = booking.ParkingID;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();

         return rowsUpdated == 0 ? false : true;
      }
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
         cmd.Parameters["@logonNameParam"].Value = String.IsNullOrEmpty(logonName) ? "UNKNOWN" : logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID, examinationApproved = 0;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            Int32.TryParse(reader["examinationApproved"] != null ? reader["examinationApproved"].ToString() : String.Empty, out examinationApproved);
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult); 
            if(dtResult != null) bookings.Add(new ExaminationBooking(bookingID, dtResult, readLogonName, examinationApproved));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }
   }
   public class ExaminationBooking {
      public int BookingID { get; set; }
      public int ExaminationApproved { get; set; }
      public string LogonName { get; set; }
      public DateTime BookingDate { get; set; }
      public int ParkingID { get; set; }
      public ExaminationBooking(int bookingID, DateTime bookingDate, string logonName, int examinationApproved) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.ExaminationApproved = examinationApproved;
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
}