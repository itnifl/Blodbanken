using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class BookHealthExaminationControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      FormModule Forms = new FormModule();
      public string CurrentUser { get; set; }
      public bool ShowUserDropDown { get; set; } = false;
      protected void Page_Load(object sender, EventArgs e) {
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
            List<SystemUser> users = AuthMod.GetAllUsers();
            DropDownList[] selectArray = { selectUserForExaminationBooking };
            if (selectUserForExaminationBooking.SelectedItem != null && !String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = selectUserForExaminationBooking.Text;
            }
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            }
            bool userHasFilledInForm = !(Forms.GetUserSchemaForm(CurrentUser).Count > 0);
            submitHEButton.Disabled = userHasFilledInForm;
            lblPersonQuestionForm.Visible = userHasFilledInForm;
         }
         else {
            selectUserForExaminationBooking.Visible = false;
            submitHEButton.Disabled = true;
         }
      }
   }
}