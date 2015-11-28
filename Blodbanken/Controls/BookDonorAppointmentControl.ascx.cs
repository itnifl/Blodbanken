using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class BookDonorAppointmentControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      FormModule Forms = new FormModule();
      TimeBooker Booker = new TimeBooker();
      public bool ShowUserDropDown { get; set; } = false;
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         List<DonorBooking> allDonorAppointments = null;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if((HttpContext.Current.User != null)) {
            if (HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
               List<SystemUser> users = AuthMod.GetAllUsers();
               allDonorAppointments = Booker.GetAllDonorBookings();
               DropDownList[] selectArray = { selectUserForDonorBooking };
               foreach (DropDownList select in selectArray) {
                  select.Items.Clear();
                  users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
                  users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
               }
               if (!String.IsNullOrEmpty(CurrentUser)) {
                  selectUserForDonorBooking.SelectedValue = CurrentUser;
               }
               else if (selectUserForDonorBooking.SelectedItem != null && String.IsNullOrEmpty(CurrentUser)) {
                  CurrentUser = selectUserForDonorBooking.Text;
               }
            }
            else {
               selectUserForDonorBooking.Visible = false;
            }
            if (String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = HttpContext.Current.User.Identity.Name;
            }
            bool hasApprovedForms = (Forms.GetUserSchemaForm(CurrentUser).Where(form => DateTime.Compare(DateTime.Now.AddDays(-30), form.approved) <= 0)).Count() > 0;

            submitButton.Disabled = !hasApprovedForms;
            lblBookDonorAppointmentError1.Visible = lblBookDonorAppointmentError2.Visible = !hasApprovedForms;
            patientName.Value = CurrentUser;
            patientName.Disabled = true;
         }
         
         __appointmentBeholder.InnerText = JsonConvert.SerializeObject(new { DonorAppointments = allDonorAppointments });
      }
   }
}