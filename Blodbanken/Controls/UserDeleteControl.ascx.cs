using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class UserDeleteControl : System.Web.UI.UserControl {
      public string CurrentUser { get; set; }
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public event Action<string> MessageReporter;
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;

         if (HttpContext.Current.User.IsInRole("Admin")) btnDeleteUser.Visible = true;
         else btnDeleteUser.Visible = false;
      }
      public void DeleteUser(object sender, CommandEventArgs e) {
         bool status = false;
         if (e.CommandName == btnDeleteUser.CommandName) {
            status = AuthMod.DeleteUser(CurrentUser);
         }
         if (MessageReporter != null) {
            MessageReporter(status ? "Bruker '" + CurrentUser + "' ble slettet": "Sletting a bruker '" + CurrentUser + "' feilet");
         }
      }
   }
}