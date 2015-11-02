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

namespace Blodbanken.CodeEngines {
   public class TimeBooker {
      private const string privilegesDatabase = "../App_Data/Privileges.mdf";

      public List<ExaminationBooking> GetUseExaminationrBookings(string logonName) {
         List<ExaminationBooking> bookings = new List<ExaminationBooking>();
         SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + System.Web.HttpContext.Current.Server.MapPath(privilegesDatabase));
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT bookingID, logonName, logonName from ExaminationBooking where logonName=@logonNameParam", conn);
         cmd.Parameters.Add("@logonNameParam", SqlDbType.VarChar, 35);
         cmd.Parameters["@logonNameParam"].Value = logonName;
         var reader = cmd.ExecuteReader();

         // write each record
         while (reader.Read()) {
            DateTime dtResult;
            int bookingID;
            Int32.TryParse(reader["BookingID"] != null ? reader["BookingID"].ToString() : String.Empty, out bookingID);
            string readLogonName = reader["logonName"].ToString();
            DateTime.TryParse(reader["bookingDate"] != null ? reader["bookingDate"].ToString() : String.Empty, out dtResult); 
            if(dtResult != null) bookings.Add(new ExaminationBooking(bookingID, dtResult, readLogonName));
         }
         cmd.Dispose();
         reader.Close();
         conn.Dispose();
         return bookings;
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
}