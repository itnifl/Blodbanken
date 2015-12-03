using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Blodbanken.CodeEngines;
using System.Security.Principal;

namespace Blodbanken.Public {
   public partial class Login : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {
         logonErrorSpan.Visible = false;
      }

      protected void btnLogon_Click(object sender, EventArgs e) {
         if (AuthMod.ValidateUser(txtInputBrukernavn.Text, txtInputPassord.Text)) {
            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtInputBrukernavn.Text, DateTime.Now,
               DateTime.Now.AddMinutes(30), chkRememberMe.Checked, "AuthentiCationCookie");
            string cookiestr = FormsAuthentication.Encrypt(tkt);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (chkRememberMe.Checked)
               authCookie.Expires = tkt.Expiration;
            authCookie.Path = FormsAuthentication.FormsCookiePath;

            string encTicket = authCookie.Value;
            if (!String.IsNullOrEmpty(encTicket)) {
               var ticket = FormsAuthentication.Decrypt(encTicket);
               UserIdentity id = new UserIdentity(ticket, AuthMod);
               var userRoles = AuthMod.GetRolesForUser(id.Name);
               var prin = new GenericPrincipal(id, userRoles);
               HttpContext.Current.User = prin;
            }
            System.Threading.Thread.CurrentPrincipal = HttpContext.Current.User;
            HttpContext.Current.Cache.Insert("customPrincipal", HttpContext.Current.User);

            Response.Cookies.Add(authCookie);
            FormsAuthentication.RedirectFromLoginPage(txtInputBrukernavn.Text, chkRememberMe.Checked);
         } else {
            logonErrorSpan.Visible = true;
            //Response.Redirect("~/Public/Login.aspx", true);
         }
      }
   }
}