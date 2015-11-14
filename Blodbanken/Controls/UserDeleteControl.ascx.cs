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
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;

         if (HttpContext.Current.User.IsInRole("Admin")) btnDeleteUser.Visible = true;
         else btnDeleteUser.Visible = false;
      }
      public void DeleteUser(object sender, CommandEventArgs e) {
         if (e.CommandName == btnDeleteUser.CommandName) {
            AuthMod.DeleteUser(CurrentUser);
         }         
      }
   }
}