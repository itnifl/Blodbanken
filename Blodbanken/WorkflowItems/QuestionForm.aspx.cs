using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines; /*47-50*/

namespace Blodbanken.WorkflowItems {
   public partial class QuestionForm : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      FormModule FormMod = new FormModule();
      public event Action<string> MessageReporter;
      public string CurrentUser { get; set;  }
      SystemUser CurrentUserObject { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            this.CurrentUser = HttpContext.Current.User.Identity.Name;
            CurrentUserObject = AuthMod.GetUser(CurrentUser);
            if (CurrentUserObject.Gender.ToLower() == "female") {
               radios51a.Disabled = true;
               radios51b.Disabled = true;
            } else if(CurrentUserObject.Gender.ToLower() == "male") {
               radios47a.Disabled = true;
               radios47b.Disabled = true;

               radios48a.Disabled = true;
               radios48b.Disabled = true;

               radios49a.Disabled = true;
               radios49b.Disabled = true;

               radios50a.Disabled = true;
               radios50b.Disabled = true;
            }
         }
         BottomNavBar.PrevLink = "/WorkflowItems/PersInfoPage.aspx";
         BottomNavBar.NextLink = "/WorkflowItems/BookMedicalExamination.aspx";
      }

      public void SubmitForm(object sender, CommandEventArgs e) {
         if (e.CommandName == btnSubmitForm.CommandName) {
            Schema userPrestoredSchema = FormMod.GetUserSchemaForm(CurrentUser).FirstOrDefault();
            Schema userSchema = new Schema();
            userSchema.logonName = CurrentUser;
            userSchema.schemaID = userPrestoredSchema != null ? userPrestoredSchema.schemaID ?? -1 : -1;
            userSchema.spm1 = radios1a.Checked ? 1 : 0;
            userSchema.spm2 = radios2a.Checked ? 1 : 0;
            userSchema.spm3 = radios3a.Checked ? 1 : 0;
            userSchema.spm4 = radios4a.Checked ? 1 : 0;
            userSchema.spm5 = radios5a.Checked ? 1 : 0;
            userSchema.spm6 = radios6a.Checked ? 1 : 0;
            userSchema.spm7 = radios7a.Checked ? 1 : 0;
            userSchema.spm8 = radios8a.Checked ? 1 : 0;
            userSchema.spm9 = radios9a.Checked ? 1 : 0;
            userSchema.spm10 = radios10a.Checked ? 1 : 0;
            userSchema.spm11 = radios11a.Checked ? 1 : 0;
            userSchema.spm12 = radios12a.Checked ? 1 : 0;
            userSchema.spm13 = radios13a.Checked ? 1 : 0;
            userSchema.spm14 = radios14a.Checked ? 1 : 0;
            userSchema.spm15 = radios15a.Checked ? 1 : 0;
            userSchema.spm16 = radios16a.Checked ? 1 : 0;
            userSchema.spm17 = radios17a.Checked ? 1 : 0;
            userSchema.spm18 = radios18a.Checked ? 1 : 0;
            userSchema.spm19 = radios19a.Checked ? 1 : 0;
            userSchema.spm20 = radios20a.Checked ? 1 : 0;
            userSchema.spm21 = radios21a.Checked ? 1 : 0;
            userSchema.spm22 = radios22a.Checked ? 1 : 0;
            userSchema.spm23 = radios23a.Checked ? 1 : 0;
            userSchema.spm24 = radios24a.Checked ? 1 : 0;
            userSchema.spm25 = radios25a.Checked ? 1 : 0;
            userSchema.spm26 = radios26a.Checked ? 1 : 0;
            userSchema.spm27 = radios27a.Checked ? 1 : 0;
            userSchema.spm28 = radios28a.Checked ? 1 : 0;
            userSchema.spm29 = radios29a.Checked ? 1 : 0;
            userSchema.spm30 = radios30a.Checked ? 1 : 0;
            userSchema.spm31 = radios31a.Checked ? 1 : 0;
            userSchema.spm32 = radios32a.Checked ? 1 : 0;
            userSchema.spm33 = radios33a.Checked ? 1 : 0;
            userSchema.spm34 = radios34a.Checked ? 1 : 0;
            userSchema.spm35 = radios35a.Checked ? 1 : 0;
            userSchema.spm36 = radios36a.Checked ? 1 : 0;
            userSchema.spm37 = radios37a.Checked ? 1 : 0;
            userSchema.spm38 = radios38a.Checked ? 1 : 0;
            userSchema.spm39 = radios39a.Checked ? 1 : 0;
            userSchema.spm40 = radios40a.Checked ? 1 : 0;
            userSchema.spm41 = radios41a.Checked ? 1 : 0;
            userSchema.spm42 = radios42a.Checked ? 1 : 0;
            userSchema.spm43 = radios43a.Checked ? 1 : 0;
            userSchema.spm44 = radios44a.Checked ? 1 : 0;
            userSchema.spm45 = radios45a.Checked ? 1 : 0;
            userSchema.spm46 = radios46a.Checked ? 1 : 0;
            userSchema.spm47 = radios47a.Checked ? 1 : 0;
            userSchema.spm48 = radios48a.Checked ? 1 : 0;
            userSchema.spm49 = radios49a.Checked ? 1 : 0;
            userSchema.spm50 = radios50a.Checked ? 1 : 0;
            userSchema.spm51 = radios51a.Checked ? 1 : 0;
            userSchema.spm52 = radios52a.Checked ? 1 : 0;
            userSchema.spm53 = radios53a.Checked ? 1 : 0;
            userSchema.spm54 = radios54a.Checked ? 1 : 0;
            userSchema.spm55 = radios55a.Checked ? 1 : 0;
            userSchema.spm56 = radios56a.Checked ? 1 : 0;
            userSchema.spm57 = radios57a.Checked ? 1 : 0;
            userSchema.spm58 = radios58a.Checked ? 1 : 0;
            userSchema.spm59 = radios59a.Checked ? 1 : 0;
            userSchema.spm60 = radios60a.Checked ? 1 : 0;
            bool runStatus = FormMod.PutUserSchemaForm(userSchema);

         }
      }
   }
}