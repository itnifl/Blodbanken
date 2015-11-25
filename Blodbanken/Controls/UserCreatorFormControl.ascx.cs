using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class UserCreatorFormControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public event Action<string, bool, SystemUser> MessageReporter;
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
         } else {
            selectRole.Items.Remove(new ListItem(UserRole.Admin.ToString(), "1"));
         }
      }
      public void CreateUser(object sender, CommandEventArgs e) {
         if (e.CommandName == btnCreate.CommandName) {
            string username = txtUsername.Value;
            string password = String.Empty;
            if (txtPassword1.Value == txtPassword2.Value) {
               password = txtPassword1.Value;
            }
            UserRole usrRole = UserRole.Viewer;
            switch (selectRole.Value.ToString().ToLower()) {
               case "1":
                  usrRole = UserRole.Admin;
                  break;
               case "2":
                  usrRole = UserRole.Donor;
                  break;
               case "3":
                  usrRole = UserRole.Viewer;
                  break;
            }
            bool queryStatus = AuthMod.CreateUser(username, password, usrRole);
            if (MessageReporter != null) {
               MessageReporter(queryStatus ? 
                  "Oppretting av bruker '"+ username + "' er fullført. Du kan nå logge inn med denne brukeren." : 
                  "Oppretting av bruker '" + username + "' feilet",
                     queryStatus, new SystemUser(username, usrRole));
            }
         }
      }
   }
}