using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Blodbanken.App_Code;
using Newtonsoft.Json;
using System.Web.Services;

namespace Blodbanken.Public {
   public partial class Login : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {

      }
      [WebMethod]
      public static string LogOffUser() {
         FormsAuthentication.SignOut();
         return JsonConvert.SerializeObject(new { runStatus = true });
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