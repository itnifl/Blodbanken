using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

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
            if (!IsPostBack) {
               List<Schema> userSchemas = FormMod.GetUserSchemaForm(CurrentUser);
               Schema newestSchema = null;
               try {
                  newestSchema = userSchemas.Aggregate((i1, i2) => i1.schemaID > i2.schemaID ? i1 : i2);
               } catch {
                  //We de nothing if this fails
               }
               if(newestSchema != null) {
                  radios1a.Checked = newestSchema != null && newestSchema.spm1 == 0 ? false : true;
                  radios2a.Checked = newestSchema != null && newestSchema.spm2 == 0 ? false : true;
                  radios3a.Checked = newestSchema != null && newestSchema.spm3 == 0 ? false : true;
                  radios4a.Checked = newestSchema != null && newestSchema.spm4 == 0 ? false : true;
                  radios5a.Checked = newestSchema != null && newestSchema.spm5 == 0 ? false : true;
                  radios6a.Checked = newestSchema != null && newestSchema.spm6 == 0 ? false : true;
                  radios7a.Checked = newestSchema != null && newestSchema.spm7 == 0 ? false : true;
                  radios8a.Checked = newestSchema != null && newestSchema.spm8 == 0 ? false : true;
                  radios9a.Checked = newestSchema != null && newestSchema.spm9 == 0 ? false : true;
                  radios10a.Checked = newestSchema != null && newestSchema.spm10 == 0 ? false : true;
                  radios11a.Checked = newestSchema != null && newestSchema.spm11 == 0 ? false : true;
                  radios12a.Checked = newestSchema != null && newestSchema.spm12 == 0 ? false : true;
                  radios13a.Checked = newestSchema != null && newestSchema.spm13 == 0 ? false : true;
                  radios14a.Checked = newestSchema != null && newestSchema.spm14 == 0 ? false : true;
                  radios15a.Checked = newestSchema != null && newestSchema.spm15 == 0 ? false : true;
                  radios16a.Checked = newestSchema != null && newestSchema.spm16 == 0 ? false : true;
                  radios17a.Checked = newestSchema != null && newestSchema.spm17 == 0 ? false : true;
                  radios18a.Checked = newestSchema != null && newestSchema.spm18 == 0 ? false : true;
                  radios19a.Checked = newestSchema != null && newestSchema.spm19 == 0 ? false : true;
                  radios20a.Checked = newestSchema != null && newestSchema.spm20 == 0 ? false : true;
                  radios21a.Checked = newestSchema != null && newestSchema.spm21 == 0 ? false : true;
                  radios22a.Checked = newestSchema != null && newestSchema.spm22 == 0 ? false : true;
                  radios23a.Checked = newestSchema != null && newestSchema.spm23 == 0 ? false : true;
                  radios24a.Checked = newestSchema != null && newestSchema.spm24 == 0 ? false : true;
                  radios25a.Checked = newestSchema != null && newestSchema.spm25 == 0 ? false : true;
                  radios26a.Checked = newestSchema != null && newestSchema.spm26 == 0 ? false : true;
                  radios27a.Checked = newestSchema != null && newestSchema.spm27 == 0 ? false : true;
                  radios28a.Checked = newestSchema != null && newestSchema.spm28 == 0 ? false : true;
                  radios29a.Checked = newestSchema != null && newestSchema.spm29 == 0 ? false : true;
                  radios30a.Checked = newestSchema != null && newestSchema.spm30 == 0 ? false : true;
                  radios31a.Checked = newestSchema != null && newestSchema.spm31 == 0 ? false : true;
                  radios32a.Checked = newestSchema != null && newestSchema.spm32 == 0 ? false : true;
                  radios33a.Checked = newestSchema != null && newestSchema.spm33 == 0 ? false : true;
                  radios34a.Checked = newestSchema != null && newestSchema.spm34 == 0 ? false : true;
                  radios35a.Checked = newestSchema != null && newestSchema.spm35 == 0 ? false : true;
                  radios36a.Checked = newestSchema != null && newestSchema.spm36 == 0 ? false : true;
                  radios37a.Checked = newestSchema != null && newestSchema.spm37 == 0 ? false : true;
                  radios38a.Checked = newestSchema != null && newestSchema.spm38 == 0 ? false : true;
                  radios39a.Checked = newestSchema != null && newestSchema.spm39 == 0 ? false : true;
                  radios40a.Checked = newestSchema != null && newestSchema.spm40 == 0 ? false : true;
                  radios41a.Checked = newestSchema != null && newestSchema.spm41 == 0 ? false : true;
                  radios42a.Checked = newestSchema != null && newestSchema.spm42 == 0 ? false : true;
                  radios43a.Checked = newestSchema != null && newestSchema.spm43 == 0 ? false : true;
                  radios44a.Checked = newestSchema != null && newestSchema.spm44 == 0 ? false : true;
                  radios45a.Checked = newestSchema != null && newestSchema.spm45 == 0 ? false : true;
                  radios46a.Checked = newestSchema != null && newestSchema.spm46 == 0 ? false : true;
                  radios47a.Checked = newestSchema != null && newestSchema.spm47 == 0 ? false : true;
                  radios48a.Checked = newestSchema != null && newestSchema.spm48 == 0 ? false : true;
                  radios49a.Checked = newestSchema != null && newestSchema.spm49 == 0 ? false : true;
                  radios50a.Checked = newestSchema != null && newestSchema.spm50 == 0 ? false : true;
                  radios51a.Checked = newestSchema != null && newestSchema.spm51 == 0 ? false : true;
                  radios52a.Checked = newestSchema != null && newestSchema.spm52 == 0 ? false : true;
                  radios53a.Checked = newestSchema != null && newestSchema.spm53 == 0 ? false : true;
                  radios54a.Checked = newestSchema != null && newestSchema.spm54 == 0 ? false : true;
                  radios55a.Checked = newestSchema != null && newestSchema.spm55 == 0 ? false : true;
                  radios56a.Checked = newestSchema != null && newestSchema.spm56 == 0 ? false : true;
                  radios57a.Checked = newestSchema != null && newestSchema.spm57 == 0 ? false : true;
                  radios58a.Checked = newestSchema != null && newestSchema.spm58 == 0 ? false : true;
                  radios59a.Checked = newestSchema != null && newestSchema.spm59 == 0 ? false : true;
                  radios60a.Checked = newestSchema != null && newestSchema.spm60 == 0 ? false : true;
                  radios1b.Checked = newestSchema != null && newestSchema.spm1 == 0 ? true : false;
                  radios2b.Checked = newestSchema != null && newestSchema.spm2 == 0 ? true : false;
                  radios3b.Checked = newestSchema != null && newestSchema.spm3 == 0 ? true : false;
                  radios4b.Checked = newestSchema != null && newestSchema.spm4 == 0 ? true : false;
                  radios5b.Checked = newestSchema != null && newestSchema.spm5 == 0 ? true : false;
                  radios6b.Checked = newestSchema != null && newestSchema.spm6 == 0 ? true : false;
                  radios7b.Checked = newestSchema != null && newestSchema.spm7 == 0 ? true : false;
                  radios8b.Checked = newestSchema != null && newestSchema.spm8 == 0 ? true : false;
                  radios9b.Checked = newestSchema != null && newestSchema.spm9 == 0 ? true : false;
                  radios10b.Checked = newestSchema != null && newestSchema.spm10 == 0 ? true : false;
                  radios11b.Checked = newestSchema != null && newestSchema.spm11 == 0 ? true : false;
                  radios12b.Checked = newestSchema != null && newestSchema.spm12 == 0 ? true : false;
                  radios13b.Checked = newestSchema != null && newestSchema.spm13 == 0 ? true : false;
                  radios14b.Checked = newestSchema != null && newestSchema.spm14 == 0 ? true : false;
                  radios15b.Checked = newestSchema != null && newestSchema.spm15 == 0 ? true : false;
                  radios16b.Checked = newestSchema != null && newestSchema.spm16 == 0 ? true : false;
                  radios17b.Checked = newestSchema != null && newestSchema.spm17 == 0 ? true : false;
                  radios18b.Checked = newestSchema != null && newestSchema.spm18 == 0 ? true : false;
                  radios19b.Checked = newestSchema != null && newestSchema.spm19 == 0 ? true : false;
                  radios20b.Checked = newestSchema != null && newestSchema.spm20 == 0 ? true : false;
                  radios21b.Checked = newestSchema != null && newestSchema.spm21 == 0 ? true : false;
                  radios22b.Checked = newestSchema != null && newestSchema.spm22 == 0 ? true : false;
                  radios23b.Checked = newestSchema != null && newestSchema.spm23 == 0 ? true : false;
                  radios24b.Checked = newestSchema != null && newestSchema.spm24 == 0 ? true : false;
                  radios25b.Checked = newestSchema != null && newestSchema.spm25 == 0 ? true : false;
                  radios26b.Checked = newestSchema != null && newestSchema.spm26 == 0 ? true : false;
                  radios27b.Checked = newestSchema != null && newestSchema.spm27 == 0 ? true : false;
                  radios28b.Checked = newestSchema != null && newestSchema.spm28 == 0 ? true : false;
                  radios29b.Checked = newestSchema != null && newestSchema.spm29 == 0 ? true : false;
                  radios30b.Checked = newestSchema != null && newestSchema.spm30 == 0 ? true : false;
                  radios31b.Checked = newestSchema != null && newestSchema.spm31 == 0 ? true : false;
                  radios32b.Checked = newestSchema != null && newestSchema.spm32 == 0 ? true : false;
                  radios33b.Checked = newestSchema != null && newestSchema.spm33 == 0 ? true : false;
                  radios34b.Checked = newestSchema != null && newestSchema.spm34 == 0 ? true : false;
                  radios35b.Checked = newestSchema != null && newestSchema.spm35 == 0 ? true : false;
                  radios36b.Checked = newestSchema != null && newestSchema.spm36 == 0 ? true : false;
                  radios37b.Checked = newestSchema != null && newestSchema.spm37 == 0 ? true : false;
                  radios38b.Checked = newestSchema != null && newestSchema.spm38 == 0 ? true : false;
                  radios39b.Checked = newestSchema != null && newestSchema.spm39 == 0 ? true : false;
                  radios40b.Checked = newestSchema != null && newestSchema.spm40 == 0 ? true : false;
                  radios41b.Checked = newestSchema != null && newestSchema.spm41 == 0 ? true : false;
                  radios42b.Checked = newestSchema != null && newestSchema.spm42 == 0 ? true : false;
                  radios43b.Checked = newestSchema != null && newestSchema.spm43 == 0 ? true : false;
                  radios44b.Checked = newestSchema != null && newestSchema.spm44 == 0 ? true : false;
                  radios45b.Checked = newestSchema != null && newestSchema.spm45 == 0 ? true : false;
                  radios46b.Checked = newestSchema != null && newestSchema.spm46 == 0 ? true : false;
                  radios47b.Checked = newestSchema != null && newestSchema.spm47 == 0 ? true : false;
                  radios48b.Checked = newestSchema != null && newestSchema.spm48 == 0 ? true : false;
                  radios49b.Checked = newestSchema != null && newestSchema.spm49 == 0 ? true : false;
                  radios50b.Checked = newestSchema != null && newestSchema.spm50 == 0 ? true : false;
                  radios51b.Checked = newestSchema != null && newestSchema.spm51 == 0 ? true : false;
                  radios52b.Checked = newestSchema != null && newestSchema.spm52 == 0 ? true : false;
                  radios53b.Checked = newestSchema != null && newestSchema.spm53 == 0 ? true : false;
                  radios54b.Checked = newestSchema != null && newestSchema.spm54 == 0 ? true : false;
                  radios55b.Checked = newestSchema != null && newestSchema.spm55 == 0 ? true : false;
                  radios56b.Checked = newestSchema != null && newestSchema.spm56 == 0 ? true : false;
                  radios57b.Checked = newestSchema != null && newestSchema.spm57 == 0 ? true : false;
                  radios58b.Checked = newestSchema != null && newestSchema.spm58 == 0 ? true : false;
                  radios59b.Checked = newestSchema != null && newestSchema.spm59 == 0 ? true : false;
                  radios60b.Checked = newestSchema != null && newestSchema.spm60 == 0 ? true : false;
               }               
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
            string __activeFocus = String.Empty;
            responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(runStatus, __activeFocus, runStatus ?
               "Egenerklæring ble sendt inn og registrert." :
               "Noe feil skjedde, prøv igjen!"));
         }
      }
   }
}