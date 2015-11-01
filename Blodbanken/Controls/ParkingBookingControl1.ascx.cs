using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class ParkingBookingControl1 : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {
         List<SystemUser> users = AuthMod.GetAllUsers();
         System.Web.UI.HtmlControls.HtmlSelect[] selectArray = { selectUserForParkingBooking1 };
         foreach (System.Web.UI.HtmlControls.HtmlSelect select in selectArray) {
            select.Items.Clear();
            users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
            users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
         }
      }
   }
}