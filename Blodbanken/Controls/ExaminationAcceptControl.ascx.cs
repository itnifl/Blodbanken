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

      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelHeader.InnerText = "Helseundersøkelser for " + CurrentUser;
         foreach (ExaminationBooking eBooking in TimeBookings.GetUserExaminationBookings(CurrentUser)) {
            healthExaminationList.Items.Add(new ListItem(eBooking.LogonName + " - " + eBooking.BookingDate, eBooking.BookingID.ToString()));
         }
      }
   }
}