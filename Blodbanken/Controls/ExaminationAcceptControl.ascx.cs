using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class ExaminationAcceptControl : System.Web.UI.UserControl {
      TimeBooker TimeBookings = new TimeBooker();
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public bool RadiosEnabled { get; set; } = false;
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelHeader.InnerText = "Helseundersøkelser for " + CurrentUser;
         infoPanelHeader.Attributes.Add("data-currentUser", CurrentUser);
         List<ExaminationBooking> eBookings = TimeBookings.GetUserExaminationBookings(CurrentUser);
         SystemUser usr = AuthMod.GetUser(CurrentUser);
         foreach (ExaminationBooking eBooking in eBookings) {
            ListItem item = new ListItem(usr.FirstName + " " + usr.LastName + " - " + eBooking.BookingDate, eBooking.BookingID.ToString());
            item.Attributes.Add("data-parkingID", eBooking.BookingID.ToString());
            item.Attributes.Add("data-bookingDateTime", JsonConvert.SerializeObject(eBooking.BookingDate));
            healthExaminationList.Items.Add(item);
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