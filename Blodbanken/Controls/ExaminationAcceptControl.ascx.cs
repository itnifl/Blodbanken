using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class ExaminationAcceptControl : System.Web.UI.UserControl {
      TimeBooker TimeBookings = new TimeBooker();
      public bool RadiosEnabled { get; set; } = false;
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelHeader.InnerText = "Helseundersøkelser for " + CurrentUser;
         List<ExaminationBooking> eBookings = TimeBookings.GetUserExaminationBookings(CurrentUser);
         foreach (ExaminationBooking eBooking in eBookings) {
            healthExaminationList.Items.Add(new ListItem(eBooking.LogonName + " - " + eBooking.BookingDate, eBooking.BookingID.ToString()));
         }
         radiosExaminationAccept1a.Disabled = !RadiosEnabled;
         radiosExaminationAccept1b.Disabled = !RadiosEnabled;
         ExaminationBooking selectedBooking = eBookings.SingleOrDefault(booking => booking.BookingID == Int32.Parse(healthExaminationList.SelectedItem.Value));
         if (selectedBooking != null) {
            radiosExaminationAccept1a.Checked = selectedBooking.ExaminationApproved > 0 ? true : false;
            radiosExaminationAccept1b.Checked = selectedBooking.ExaminationApproved == 0 ? true : false;
         }
      }
   }
}