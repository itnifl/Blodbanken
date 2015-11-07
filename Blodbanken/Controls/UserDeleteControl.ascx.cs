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

      }
      public void DeleteUser(object sender, EventArgs e) {
         AuthMod.DeleteUser(CurrentUser);
      }
   }
}