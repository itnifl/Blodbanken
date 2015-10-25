using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Blodbanken.App_Code;

namespace Blodbanken.Public {
   public partial class Login : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {

      }
      public void LogOffUser() {
         FormsAuthentication.SignOut();
         Response.Redirect("~/Public/Login.aspx", true);
      }

      protected void btnLogon_Click(object sender, EventArgs e) {
         if (AuthMod.ValidateUser(txtInputBrukernavn.Text, txtInputPassord.Text)) {
            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtInputBrukernavn.Text, DateTime.Now,
               DateTime.Now.AddMinutes(30), chkRememberMe.Checked, "AuthentiCationCookie");
            string cookiestr = FormsAuthentication.Encrypt(tkt);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (chkRememberMe.Checked)
               ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);
            
            FormsAuthentication.RedirectFromLoginPage(txtInputBrukernavn.Text, chkRememberMe.Checked);
         } else {
            Response.Redirect("~/Public/Login.aspx", true);
         }
      }
   }
}