using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class UserEditControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthModule = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelEditUserHeader.InnerText = "Endre brukeropplysninger for " + CurrentUser;
         this.PopulateHTMLForm(CurrentUser);
      }
      public void PopulateHTMLForm(string logonName) {
         SystemUser usr = AuthModule.GetUser(logonName);
         txtAddress.Value = usr.Address;
         txtEPost.Value = usr.EMail;
         txtFirstname.Value = usr.FirstName;
         txtLastName.Value = usr.LastName;
         txtPassword.Value = usr.Password;
         txtSocialSecurityNumber.Value = usr.NationalIdentity.ToString();
         txtTlfArbeid.Value = usr.PhoneWork;
         txtTlfMobil.Value = usr.PhoneMobile;
         txtTlfPrivat.Value = usr.PhonePrivate;
         selectAge.SelectedValue = usr.Age.ToString();
         selectRole.SelectedValue = usr.UserRole.ToString();
         selectGender.SelectedValue = usr.Gender;
      }
   }
}