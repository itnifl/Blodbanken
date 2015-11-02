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
         //http://stackoverflow.com/questions/11753631/passing-parameter-to-web-user-control-by-a-data-storage-method-like-session-vie
         SystemUser usr = AuthMod.GetUser(CurrentUser);
      }
   }
}