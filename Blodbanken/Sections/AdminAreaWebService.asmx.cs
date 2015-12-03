using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using Newtonsoft.Json;
using Blodbanken.CodeEngines;
using System.Web.Script.Services;
using System.Security.Principal;

namespace Blodbanken.Sections {
   /// <summary>
   /// Summary description for AdminAreaWebService
   /// </summary>
   [WebService(Namespace = "http://tempuri.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [System.ComponentModel.ToolboxItem(false)]
   [System.Web.Script.Services.ScriptService]
   public class AdminAreaWebService : System.Web.Services.WebService {
      internal FormModule FormModule = new FormModule();
      internal TimeBooker Booker = new TimeBooker();

      [WebMethod]
      public string LogOffUser() {
         FormsAuthentication.SignOut();
         if(Session != null) Session.Abandon();
         HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
         GenericPrincipal myUser = (GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         myUser = null;
         System.Threading.Thread.CurrentPrincipal = null;

         UserIdentity id = new UserIdentity();
         id.IsAuthenticated = false;
         var userRoles = new String[] { };
         var prin = new GenericPrincipal(id, userRoles);

         HttpContext.Current.User = prin;
         HttpContext.Current.Cache.Remove("customPrincipal");
         HttpContext.Current.Cache.Insert("customPrincipal", prin);
         HttpContext.Current.Response.Cookies.Clear();

         //FormsAuthentication.SetAuthCookie
         return JsonConvert.SerializeObject(new { runStatus = true });
      }

      [WebMethod]
      public string SetEmailAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetMailAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public string SetPersInfoAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetPersInfoAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public string SetSMSAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetSMSAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public string SetUserExaminationBooking(int bookingID, DateTime bookingDateTime, string logonName, DateTime examinationApproved, int parkingID, int durationHours) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            ExaminationBooking exBooking = new ExaminationBooking(bookingID, bookingDateTime, logonName, examinationApproved, durationHours);
            if (parkingID != -1) exBooking.ParkingID = parkingID;
            runStatus = Booker.SetExaminationBooking(exBooking);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
      public string GetUserExaminationBooking(string logonName, int bookingID) {
         ExaminationBooking exBooking = null;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            exBooking = Booker.GetUserExaminationBookings(logonName).SingleOrDefault(booking => booking.BookingID == bookingID);
         }
         return JsonConvert.SerializeObject(new { ExaminationBooking = exBooking });
      }
      [WebMethod]
      public string DeleteHealthExaminatonSchema(int schemaID) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            FormModule.DeleteForm(schemaID);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public string BookHealthExamination(DateTime bookingDate, int durationHours, string logonName) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = Booker.BookHealthExamination(bookingDate, durationHours, logonName);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public string BookDonorAppointment(DateTime bookingDate, int durationHours, string logonName) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = Booker.BookDonorAppointment(bookingDate, durationHours, logonName);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
   }
}
