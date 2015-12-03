using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Blodbanken.CodeEngines;

namespace Blodbanken {
   public partial class WebUserControl1 : System.Web.UI.UserControl {
      public string UserName = String.Empty;
      protected void Page_Load(object sender, EventArgs e) {
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal) HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            UserName = HttpContext.Current.User.Identity.Name;
            lstLogOff.Visible = true;
            lstWelcome.Visible = true;
         } else {
            lstLogOff.Visible = false;
            lstWelcome.Visible = false;
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
         }
         lblLoggedInUsername.Text = UserName;
         if (HttpContext.Current.User != null && HttpContext.Current.User.IsInRole("Admin")) lstAdminLink.Visible = true;
         else lstAdminLink.Visible = false;
      }
   }
}