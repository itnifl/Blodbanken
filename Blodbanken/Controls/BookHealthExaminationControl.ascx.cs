using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class BookHealthExaminationControl : System.Web.UI.UserControl {
      private AuthenticatonModule AuthMod = new AuthenticatonModule();
      private FormModule Forms = new FormModule();
      private TimeBooker Booker = new TimeBooker();
      public string CurrentUser { get; set; }
      public bool ShowUserDropDown { get; set; } = false;
      protected void Page_Load(object sender, EventArgs e) {
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         List<ExaminationBooking> allExaminationbookings = null;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
            List<SystemUser> users = AuthMod.GetAllUsers();
            allExaminationbookings = Booker.GetAllExaminationBookings();
            DropDownList[] selectArray = { selectUserForExaminationBooking };
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            }
            if (!String.IsNullOrEmpty(CurrentUser)) {
               selectUserForExaminationBooking.SelectedValue = CurrentUser;
            }
            else if (selectUserForExaminationBooking.SelectedItem != null && !String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = selectUserForExaminationBooking.Text;
            }
            else if (String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = HttpContext.Current.User.Identity.Name;
            }
            bool userHasFilledInForm = !(Forms.GetUserSchemaForm(CurrentUser).Count > 0);
            submitHEButton.Disabled = userHasFilledInForm;
            lblPersonQuestionForm1.Visible = lblPersonQuestionForm2.Visible = userHasFilledInForm;
            patientHEName.Value = CurrentUser;
            patientHEName.Disabled = true;
         }
         else {
            selectUserForExaminationBooking.Visible = false;
            submitHEButton.Disabled = true;
         }
         __examinationBeholder.InnerText = JsonConvert.SerializeObject(new { ExaminationBookings = allExaminationbookings });
      }
   }
}