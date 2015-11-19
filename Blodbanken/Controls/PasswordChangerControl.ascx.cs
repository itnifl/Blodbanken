using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class PasswordChangerControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public event Action<string> MessageReporter;
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {

      }
      public void ChangePassword(object sender, CommandEventArgs e) {
         if (e.CommandName == btnExecute.CommandName && !String.IsNullOrEmpty(CurrentUser)) {
            if (AuthMod.ValidateUser(CurrentUser, txtPassword0.Value)) {
               bool status = AuthMod.UpdatePassword(CurrentUser, txtPassword2.Value);
               if (MessageReporter != null) {
                  MessageReporter(status ? "Endring av passord for bruker '" + CurrentUser + "' er fullført." : "Endring av passord for bruker '" + CurrentUser + "' feilet");
               }
            }            
         }
      }
   }
}
