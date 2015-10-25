using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.Controls {
   public partial class LoggedInUserControl : System.Web.UI.UserControl {
      public string UserName = "No one";
      protected void Page_Load(object sender, EventArgs e) {
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            UserName = HttpContext.Current.User.Identity.Name;
         }
         lblLoggedInUsername.Text = UserName;
      }
   }
}