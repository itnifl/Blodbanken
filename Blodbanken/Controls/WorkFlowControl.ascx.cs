using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class WorkFlowControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         SystemUser usr = AuthMod.GetUser(CurrentUser);
         workflowCreateUser.Attributes["class"] += (CheckIfUserOK(usr) ? " list-group-item-success" : " list-group-item-danger");
      }
      public bool CheckIfUserOK(SystemUser user) {
         return String.IsNullOrEmpty(user.LogonName) && String.IsNullOrEmpty(user.Password) && String.IsNullOrEmpty(user.PhoneNumber) && String.IsNullOrEmpty(user.FirstName) && String.IsNullOrEmpty(user.LastName) && user.Age > 0;
      }
   }
}

/*--
    Skal ha:
    list-group-item-success
    list-group-item-danger

    kanskje

    list-group-item-warning
--*/