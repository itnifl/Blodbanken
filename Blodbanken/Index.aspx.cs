using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using System.Web.Security;

namespace Blodbanken {
   public partial class Index : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         if (!(System.Web.HttpContext.Current.User != null) && !System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
            Response.Redirect("~/Public/Login.aspx", true);
         }
      }
   }
}
/*
* Kalender notater i leksjon 5
* Validering i leksjon 6
*/