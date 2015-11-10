using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class UserCreatorFormControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            this.CurrentUser = HttpContext.Current.User.Identity.Name;
            if (!HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
               selectRole.Items.Remove(new ListItem(UserRole.Admin.ToString(), "1"));
            }
         }
      }
      protected void CreateUser(object sender, EventArgs e) {
         string username = txtUsername.Value;
         string password = String.Empty;
         if (txtPassword1.Value == txtPassword2.Value) {
            password = txtPassword1.Value;
         }
         //AuthMod.CreateUser();
      }
   }
}