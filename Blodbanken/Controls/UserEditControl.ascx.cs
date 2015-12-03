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
      public event Action<string> MessageReporter;
      public string CurrentUser { get; set; }
      public bool ChangedNewUser { get; set; } = false;
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelEditUserHeader.InnerText = "Endre brukeropplysninger for " + CurrentUser;
         if(!IsPostBack || ChangedNewUser)
            this.PopulateHTMLForm(CurrentUser);
         if (HttpContext.Current.User != null && !HttpContext.Current.User.IsInRole("Admin"))
            selectRole.Items.Remove(new ListItem("Admin","1"));
      }
      public void UpdateUser(object sender, CommandEventArgs e) {
         SystemUser usr = AuthModule.GetUser(CurrentUser);
         bool persInfoCosent = usr.PersInfoConsent;
         if (e.CommandName == btnUpdate.CommandName && persInfoCosent) {
            UserRole role = UserRole.Admin;
            switch (selectRole.SelectedValue.ToLower()) {
               case "1":
                  role = UserRole.Admin;
                  break;
               case "2":
                  role = UserRole.Donor;
                  break;
               case "3":
                  role = UserRole.Viewer;
                  break;
            }
            bool status = AuthModule.UpdateUser(CurrentUser, role, txtFirstname.Value, txtLastName.Value,
               txtTlfMobil.Value, Int32.Parse(selectAge.SelectedValue), txtAddress.Value,
               txtSocialSecurityNumber.Value, selectGender.SelectedValue.ToLower() == "1" ? "male" : "female",
               txtTlfArbeid.Value, txtTlfPrivat.Value, txtEPost.Value);
            if (MessageReporter != null) {
               MessageReporter(status ? "Oppdatering av bruker " + txtFirstname.Value + " " + txtLastName.Value + " var en suksess" : "Oppdatering av bruker " + txtFirstname.Value + " " + txtLastName.Value + " feilet");
            }
         }
         else if (!persInfoCosent) {
            lblPersInfConsent.Disabled = !persInfoCosent;
            lblPersInfConsent.Visible = !persInfoCosent;
            if (MessageReporter != null) {
               MessageReporter("Lagring av personopplysninger er ikke godkjent av bruker, vennligst godkjenn dette først.");
            }
         } else if (usr.Age < 18 && usr.Age > 65 && (usr.UserRole == UserRole.Donor || usr.UserRole == UserRole.Admin)) {
            if (MessageReporter != null) {
               MessageReporter("Bare personer som er mellom 18 og 65 år er tillatt å donere blod.");
            }
         }
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
         selectRole.SelectedValue = usr.UserRole.ToString().ToLower() == "admin" ? "1" : (usr.UserRole.ToString().ToLower() == "donor" ? "2" : "3");
         selectRole.Enabled = persInfoCosent;
         selectGender.SelectedValue = usr.Gender.ToLower() == "male" ? "1" : "2";
         selectGender.Enabled = persInfoCosent;
         lblPersInfConsent.Disabled = !persInfoCosent;
         lblPersInfConsent.Visible = !persInfoCosent;
      }
   }
}