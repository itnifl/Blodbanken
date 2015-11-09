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
         bool persInfoCosent = usr.PersInfoConsent;
         txtAddress.Value = usr.Address;
         txtAddress.Disabled = !persInfoCosent;
         txtEPost.Value = usr.EMail;
         txtEPost.Disabled = !persInfoCosent;
         txtFirstname.Value = usr.FirstName;
         txtFirstname.Disabled = !persInfoCosent;
         txtLastName.Value = usr.LastName;
         txtLastName.Disabled = !persInfoCosent;
         txtPassword.Value = usr.Password;

         txtSocialSecurityNumber.Value = usr.NationalIdentity.ToString();
         txtSocialSecurityNumber.Disabled = !persInfoCosent;
         txtTlfArbeid.Value = usr.PhoneWork;
         txtTlfArbeid.Disabled = !persInfoCosent;
         txtTlfMobil.Value = usr.PhoneMobile;
         txtTlfMobil.Disabled = !persInfoCosent;
         txtTlfPrivat.Value = usr.PhonePrivate;
         txtTlfPrivat.Disabled = !persInfoCosent;
         selectAge.SelectedValue = usr.Age.ToString();
         selectAge.Enabled = persInfoCosent;
         selectRole.SelectedValue = usr.UserRole.ToString();
         selectRole.Enabled = persInfoCosent;
         selectGender.SelectedValue = usr.Gender;
         selectGender.Enabled = persInfoCosent;
         lblPersInfConsent.Disabled = !persInfoCosent;
      }
   }
}