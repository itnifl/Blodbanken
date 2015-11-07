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
         if (!checkStatus) errorInfo1.InnerText = "Mangler personopplysninger";

         checkStatus = CheckIfPersInfoConsentOK(usr);
         workflowConsent.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-danger");
         if(!checkStatus) errorInfo2.InnerText = "Mangler samtykke i lagring av personopplysninger";

         checkStatus = CheckIfUserHasFutureExaminationBookings(usr); //Her må det også sjekks om en allerede er utført - sjekk regler
         workflowExamination.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");
         if (!checkStatus) errorInfo3.InnerText = "Helseundersøkelse mangler";

         checkStatus = CheckIfUserHasSubmittedSchema(usr);
         workflowSchema.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");
         if (!checkStatus) errorInfo4.InnerText = "Spørreskjema mangler";

         checkStatus = CheckIfUserHasBookedkDonorAppointment(usr);
         workflowBookAppointment.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");
         if (!checkStatus) errorInfo5.InnerText = "Donortime mangler";

         checkStatus = CheckIfUserHasBookedkParkingAtDonotAppointment(usr);
         workflowBookParking.Attributes["class"] += (checkStatus ? " list-group-item-success" : " list-group-item-warning");
         if (!checkStatus) errorInfo6.InnerText = "Parkering mangler";
      }
      public bool CheckIfUserOK(SystemUser user) {
         return String.IsNullOrEmpty(user.LogonName) && String.IsNullOrEmpty(user.Password) && String.IsNullOrEmpty(user.PhoneMobile) && String.IsNullOrEmpty(user.FirstName) && String.IsNullOrEmpty(user.LastName) && user.Age > 0;
      }
      public bool CheckIfPersInfoConsentOK(SystemUser user) {
         return user.PersInfoConsent;
      }
      public bool CheckIfUserHasFutureExaminationBookings(SystemUser user) {
         List<ExaminationBooking> exBookings = TimeBookings.GetUserExaminationBookings(user.LogonName);
         bool hasFutureBookings = exBookings.Where(booking => DateTime.Compare(DateTime.Today, booking.BookingDate) <= 0).Count() > 0;
         bool hasRecentApprovedExaminations = exBookings.Where(booking => DateTime.Compare(DateTime.Today.AddDays(-30), booking.BookingDate) <= 0 && booking.ExaminationApproved > 0).Count() > 0;
         return hasFutureBookings || hasRecentApprovedExaminations;
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