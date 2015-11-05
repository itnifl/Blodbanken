using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class WorkFlowControl : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      TimeBooker TimeBookings = new TimeBooker();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         SystemUser usr = AuthMod.GetUser(CurrentUser);
         bool checkStatus = CheckIfUserOK(usr);
         workflowCreateUser.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-danger");

         checkStatus = CheckIfPersInfoConsentOK(usr);
         workflowConsent.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-danger");
         errorInfo1.InnerText = "Du har ikke samtykket i lagring av personopplysninger";

         checkStatus = CheckIfUserHasFutureExamnationBookings(usr);
         workflowExamination.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");

         checkStatus = CheckIfUserHasSubmittedSchema(usr);
         workflowSchema.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");

         checkStatus = CheckIfUserHasBookedkDonorAppointment(usr);
         workflowBookAppointment.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");

         checkStatus = CheckIfUserHasBookedkParkingAtDonotAppointment(usr);
         workflowBookParking.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");
      }
      public bool CheckIfUserOK(SystemUser user) {
         return String.IsNullOrEmpty(user.LogonName) && String.IsNullOrEmpty(user.Password) && String.IsNullOrEmpty(user.PhoneMobile) && String.IsNullOrEmpty(user.FirstName) && String.IsNullOrEmpty(user.LastName) && user.Age > 0;
      }
      public bool CheckIfPersInfoConsentOK(SystemUser user) {
         return user.PersInfoConsent;
      }
      public bool CheckIfUserHasFutureExamnationBookings(SystemUser user) {
         return TimeBookings.GetUserExaminationBookings(user.LogonName).Where(booking => DateTime.Compare(DateTime.Now, booking.BookingDate) <= 0).Count() > 0;
      }
      public bool CheckIfUserHasSubmittedSchema(SystemUser user) {
         return TimeBookings.GetUserInfoForm(user.LogonName).Count() > 0;
      }
      public bool CheckIfUserHasBookedkDonorAppointment(SystemUser user) {
         return TimeBookings.GetUserDonorBookings(user.LogonName).Where(booking => DateTime.Compare(DateTime.Now, booking.BookingDate) <= 0).Count() > 0;
      }
      public bool CheckIfUserHasBookedkParkingAtDonotAppointment(SystemUser user) {
         if (!CheckIfUserHasBookedkDonorAppointment(user)) return false;
         return TimeBookings.GetFutureParkspaceBookingsForDonors(user.LogonName).Where(booking => DateTime.Compare(DateTime.Now, booking.BookingDate) <= 0).Count() > 0;
      }
   }
}

/*--
    Skal ha:
    list-group-item-success
    list-group-item-danger

    kanskje

    list-group-item-warning
--*/