using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class ParkingBookingControl1 : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      TimeBooker Booker = new TimeBooker();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         List<ParkspaceBooking> allParkingAppointments = null;
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
            List<SystemUser> users = AuthMod.GetAllUsers();
            allParkingAppointments = Booker.GetFutureParkspaceBookingsForDonors();
            DropDownList[] selectArray = { selectUserForParkingBooking_1 };
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            }
            if (!String.IsNullOrEmpty(CurrentUser)) {
               selectUserForParkingBooking_1.SelectedValue = CurrentUser;
            } else if (selectUserForParkingBooking_1.SelectedItem != null) {
               CurrentUser = selectUserForParkingBooking_1.Text;
            }
            else if(String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = HttpContext.Current.User.Identity.Name;
            }
         } else {
            selectUserForParkingBooking_1.Visible = false;
            labelfor_selectUserForParkingBooking_1.Visible = false;
         }
         __parkingBeholder.InnerText = JsonConvert.SerializeObject(new { ParkingAppointments = allParkingAppointments });
         parkPanelHeader.InnerText = "Reserver parkering for " + CurrentUser;
         parkPanelHeader.Attributes.Add("data-currentUser", CurrentUser);
      }
   }
}