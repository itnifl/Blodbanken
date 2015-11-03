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
         workflowCreateUser.Attributes["class"] += (CheckIfUserOK(usr) ? " list-group-item-success" : " list-group-item-danger");
         workflowConsent.Attributes["class"] += (CheckIfPersInfoConsentOK(usr) ? " list-group-item-success" : " list-group-item-danger");
         workflowExamintion.Attributes["class"] += (CheckIfUserHasFutureExamnationBookings(usr) ? " list-group-item-success" : " list-group-item-warning");
         workflowSchema.Attributes["class"] += (CheckIfUserHasSubmittedSchema(usr) ? " list-group-item-success" : " list-group-item-warning");
      }
      public bool CheckIfUserOK(SystemUser user) {
         return String.IsNullOrEmpty(user.LogonName) && String.IsNullOrEmpty(user.Password) && String.IsNullOrEmpty(user.PhoneMobile) && String.IsNullOrEmpty(user.FirstName) && String.IsNullOrEmpty(user.LastName) && user.Age > 0;
      }
      public bool CheckIfPersInfoConsentOK(SystemUser user) {
         return user.PersInfoConsent;
      }
      public bool CheckIfUserHasFutureExamnationBookings(SystemUser user) {
         return TimeBookings.GetUseExaminationrBookings(user.LogonName).Where(booking => DateTime.Compare(DateTime.Now, booking.BookingDate) <= 0).Count() > 0;
      }
      public bool CheckIfUserHasSubmittedSchema(SystemUser user) {
         return TimeBookings.GetUseExaminationrBookings(user.LogonName).Where(booking => DateTime.Compare(DateTime.Now, booking.BookingDate) <= 0).Count() > 0;
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