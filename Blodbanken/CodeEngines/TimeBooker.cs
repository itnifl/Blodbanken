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
using System.Data.SqlTypes;

namespace Blodbanken.CodeEngines {
   public class TimeBooker {
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public bool DeleteExaminationBooking(int bookingID) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("DELETE FROM ExaminationBooking WHERE bookingID=@bookingID", conn);
         cmd.Parameters.Add("@bookingID", SqlDbType.Int);
         cmd.Parameters["@bookingID"].Value = bookingID;
         rowsUpdated = cmd.ExecuteNonQuery();
         cmd.Dispose();
         conn.Dispose();
         return rowsUpdated == 0 ? false : true;
      }
      public bool SetExaminationBooking(ExaminationBooking booking) {
         int rowsUpdated = 0;
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd;
         if (booking.ParkingID.HasValue) {
            cmd = new SqlCommand("UPDATE ExaminationBooking SET bookingDate=@bookingDate, examinationApproved=@examinationApproved, durationHours=@durationHours, parkingID=@parkingID WHERE bookingID=@bookingID", conn);
            cmd.Parameters.Add("@parkingID", SqlDbType.Int);
            cmd.Parameters["@parkingID"].Value = booking.ParkingID;
         } else {
            cmd = new SqlCommand("UPDATE ExaminationBooking SET bookingDate=@bookingDate, examinationApproved=@examinationApproved, durationHours=@durationHours WHERE bookingID=@bookingID", conn);
         }
         

         cmd.Parameters.Add("@bookingDate", SqlDbType.DateTime);
         cmd.Parameters["@bookingDate"].Value = booking.BookingDate == DateTime.MinValue ? SqlDateTime.MinValue : booking.BookingDate;

         cmd.Parameters.Add("@examinationApproved", SqlDbType.DateTime);
         cmd.Parameters["@examinationApproved"].Value = booking.ExaminationApproved == DateTime.MinValue ? SqlDateTime.MinValue : booking.ExaminationApproved;

         cmd.Parameters.Add("@bookingID", SqlDbType.Int);
         cmd.Parameters["@bookingID"].Value = booking.BookingID;

         cmd.Parameters.Add("@durationHours", SqlDbType.Int);
         cmd.Parameters["@durationHours"].Value = booking.DurationHours;

         

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();

         return rowsUpdated == 0 ? false : true;
      }
      public bool BookHealthExamination(DateTime bookingDate, int durationHours, string logonName) {
         int rowsUpdated = 0;
         ExaminationBooking booking = new ExaminationBooking(bookingDate, durationHours, logonName);
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("INSERT INTO ExaminationBooking (bookingDate, examinationApproved, durationHours, logonName) values (@bookingDate, @examinationApproved, @durationHours, @logonName)", conn);

         cmd.Parameters.Add("@bookingDate", SqlDbType.DateTime);
         cmd.Parameters["@bookingDate"].Value = booking.BookingDate == DateTime.MinValue ? SqlDateTime.MinValue : booking.BookingDate;

         cmd.Parameters.Add("@examinationApproved", SqlDbType.DateTime);
         cmd.Parameters["@examinationApproved"].Value = booking.ExaminationApproved == DateTime.MinValue ? SqlDateTime.MinValue : booking.ExaminationApproved;

         cmd.Parameters.Add("@durationHours", SqlDbType.Int);
         cmd.Parameters["@durationHours"].Value = booking.DurationHours;

         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = booking.LogonName;

         rowsUpdated = cmd.ExecuteNonQuery();

         cmd.Dispose();
         conn.Dispose();

         return rowsUpdated == 0 ? false : true;
      }
      public bool BookDonorAppointment(DateTime bookingDate, int durationHours, string logonName) {
         int rowsUpdated = 0;
         DonorBooking booking = new DonorBooking(bookingDate, durationHours, logonName);
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();
         SqlCommand cmd = new SqlCommand("INSERT INTO DonorBooking (bookingDate, durationHours, logonName) values (@bookingDate, @durationHours, @logonName)", conn);

         cmd.Parameters.Add("@bookingDate", SqlDbType.DateTime);
         cmd.Parameters["@bookingDate"].Value = booking.BookingDate == DateTime.MinValue ? SqlDateTime.MinValue : booking.BookingDate;

         cmd.Parameters.Add("@durationHours", SqlDbType.Int);
         cmd.Parameters["@durationHours"].Value = booking.DurationHours;

         cmd.Parameters.Add("@logonName", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonName"].Value = booking.LogonName;

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
      public List<ParkspaceBooking> GetFutureParkspaceBookingsForDonors() {
         List<ParkspaceBooking> bookings = new List<ParkspaceBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT PB.bookingID AS bookingID, PB.bookingDate AS bookingDate, PB.parkingSpace AS parkingSpace, DB.logonName AS logonName FROM DonorBooking AS DB JOIN ParkspaceBooking AS PB ON (DB.parkingID=PB.parkingSpace)", conn);

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

         SqlCommand cmd = new SqlCommand("SELECT bookingID, bookingDate, logonName, durationHours, parkingID from DonorBooking where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID;
            int durationHours;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            string readLogonName = reader["logonName"].ToString();
            Int32.TryParse(reader["durationHours"] != null ? reader["durationHours"].ToString() : String.Empty, out durationHours);
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);
            int? parkingID = reader.IsDBNull(reader.GetOrdinal("parkingID")) ? (int?)null : Int32.Parse(reader["parkingID"].ToString());
            if (dtResult != null) bookings.Add(new DonorBooking(bookingID, dtResult, readLogonName, durationHours, parkingID));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }
      public List<DonorBooking> GetAllDonorBookings() {
         List<DonorBooking> bookings = new List<DonorBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT D.bookingID, D.bookingDate, D.logonName, D.parkingID, D.durationHours, u.firstName, u.lastName FROM DonorBooking as D JOIN Users AS u ON(D.logonName=u.logonName)", conn);
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID;
            int durationHours;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            Int32.TryParse(reader["durationHours"] != null ? reader["durationHours"].ToString() : String.Empty, out durationHours);
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);
            int? parkingID = reader.IsDBNull(reader.GetOrdinal("parkingID")) ? (int?)null : Int32.Parse(reader["parkingID"].ToString());
            string firstName = reader["firstName"] != null ? reader["firstName"].ToString() : String.Empty;
            string lastName = reader["lastName"] != null ? reader["lastName"].ToString() : String.Empty;

            DonorBooking booking = new DonorBooking(bookingID, dtResult, readLogonName, durationHours, parkingID);
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName)) {
               booking.DisplayName = firstName + " " + lastName;
            }

            if (dtResult != null) bookings.Add(booking);
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

         SqlCommand cmd = new SqlCommand("SELECT  bookingID, examinationApproved, bookingDate, logonName, durationHours, parkingID from ExaminationBooking where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = String.IsNullOrEmpty(logonName) ? "UNKNOWN" : logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int durationHours, bookingID;
            DateTime examinationApproved;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            examinationApproved = reader.GetDateTime(reader.GetOrdinal("examinationApproved"));
            Int32.TryParse(reader["durationHours"] != null ? reader["durationHours"].ToString() : String.Empty, out durationHours);
            int? parkingID = reader.IsDBNull(reader.GetOrdinal("parkingID")) ? (int?)null : Int32.Parse(reader["parkingID"].ToString());
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);
            if (dtResult != null) bookings.Add(new ExaminationBooking(bookingID, dtResult, readLogonName, examinationApproved, durationHours, parkingID));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }
      public List<ExaminationBooking> GetAllExaminationBookings() {
         List<ExaminationBooking> bookings = new List<ExaminationBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT e.bookingID, e.examinationApproved, e.bookingDate, e.logonName, e.durationHours, e.parkingID, u.firstName, u.lastName FROM ExaminationBooking AS e JOIN Users AS u ON (e.logonName=u.logonName)", conn);
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int durationHours, bookingID;
            Int32.TryParse(reader["bookingID"] != null ? reader["bookingID"].ToString() : String.Empty, out bookingID);
            DateTime examinationApproved = reader.GetDateTime(reader.GetOrdinal("examinationApproved"));
            Int32.TryParse(reader["durationHours"] != null ? reader["durationHours"].ToString() : String.Empty, out durationHours);
            int? parkingID = reader.IsDBNull(reader.GetOrdinal("parkingID")) ? (int?)null : Int32.Parse(reader["parkingID"].ToString());
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult);

            string firstName = reader["firstName"] != null ? reader["firstName"].ToString() : String.Empty;
            string lastName = reader["lastName"] != null ? reader["lastName"].ToString() : String.Empty;

            ExaminationBooking booking = new ExaminationBooking(bookingID, dtResult, readLogonName, examinationApproved, durationHours, parkingID);
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName)) {
               booking.DisplayName = firstName + " " + lastName;
            }
           
            if (dtResult != null) bookings.Add(booking);
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
      }      
   }
   public class ExaminationBooking {
      public int BookingID { get; set; }
      public DateTime ExaminationApproved { get; set; }
      public string LogonName { get; set; }
      public DateTime BookingDate { get; set; }
      public int DurationHours { get; set; }
      public int? ParkingID { get; set; }
      public string DisplayName { get; set; }
      public ExaminationBooking(int bookingID, DateTime bookingDate, string logonName, DateTime examinationApproved, int durationHours, int? parkingID) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.ExaminationApproved = examinationApproved;
         this.DurationHours = durationHours;
         this.ParkingID = parkingID;
      }
      public ExaminationBooking(int bookingID, DateTime bookingDate, string logonName, DateTime examinationApproved, int durationHours) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.ExaminationApproved = examinationApproved;
         this.DurationHours = durationHours;
      }
      public ExaminationBooking(DateTime bookingDate, int durationHours, string logonName) {
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.ExaminationApproved = DateTime.MinValue;
         this.DurationHours = durationHours;
      }
   }
   public class DonorBooking {
      public int BookingID { get; set; }
      public string LogonName { get; set; }
      public DateTime BookingDate { get; set; }
      public int DurationHours { get; set; }
      public int? ParkingID { get; set; }
      public string DisplayName { get; set; }
      public DonorBooking(int bookingID, DateTime bookingDate, string logonName, int durationHours, int? parkingID) {
         this.BookingID = bookingID;
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.DurationHours = durationHours;
         this.ParkingID = parkingID;
      }
      public DonorBooking(DateTime bookingDate, int durationHours, string logonName) {
         this.BookingDate = bookingDate;
         this.LogonName = logonName;
         this.DurationHours = durationHours;
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