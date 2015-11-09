using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class BookingControl2 : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
            List<SystemUser> users = AuthMod.GetAllUsers();
            DropDownList[] selectArray = { selectUserForBooking_2 };
            if (selectUserForBooking_2.SelectedItem != null) {
               CurrentUser = selectUserForBooking_2.Text;
            }
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            }
         } else {
            selectUserForBooking_2.Visible = false;
            labelfor_selectUserForBooking_2.Visible = false;
         }
      }
   }
}