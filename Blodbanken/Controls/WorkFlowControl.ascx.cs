﻿using System;
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
         workflowExamination.Attributes["class"] += (CheckIfUserHasFutureExamnationBookings(usr) ? " list-group-item-success" : " list-group-item-warning");
         workflowSchema.Attributes["class"] += (CheckIfUserHasSubmittedSchema(usr) ? " list-group-item-success" : " list-group-item-warning");
         workflowBookAppointment.Attributes["class"] += (CheckIfUserHasBookedkDonorAppointment(usr) ? " list-group-item-success" : " list-group-item-warning");
         workflowBookParking.Attributes["class"] += (CheckIfUserHasBookedkParkingAtDonotAppointment(usr) ? " list-group-item-success" : " list-group-item-warning");
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
         return TimeBookings.GetUserParkingStatusForFutureDonorBookings(user.LogonName);
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