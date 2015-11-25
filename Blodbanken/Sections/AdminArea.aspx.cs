using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Blodbanken.Controls;
using Newtonsoft.Json;
using System.Web.Services;

namespace Blodbanken.Sections {
   public partial class AdminArea : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      internal static FormModule FormModule = new FormModule();
      internal static TimeBooker Booker = new TimeBooker();
      public string CurrentUser { get; set; }
      public string CustomMessage { get; set; }
      private string __activeFocus { get; set; }

      private String GetFocusSection(DropDownList list) {
         if (list == selectChangeUser1) return "itemUserChanger";
         if (list == selectDeleteUser1) return "itemUserDeletor";
         if (list == selectUserForSchemaEdit) return "itemSchemaEdit";
         if (list == selectUserForConsentEdit) return "itemConsentEdit";
         if (list == selectUserForWorkflowEdit) return "itemWorkflowEdit";
         if (list == selectUserForExaminationAccept) return "itemExaminationAccept";
         return "";
      }
      private String GetFocusSection(Button button) {
         if (button.ID == "btnCreate") return "itemUserEditor";
         if (button.ID == "btnDeleteUser") return "itemUserDeletor";
         return "";
      }
      protected void Page_Load(object sender, EventArgs e) {
         List<SystemUser> users = AuthMod.GetAllUsers();

         if (this.Request["_activeFocus"] != null) {
            __activeFocus = this.Request["_activeFocus"].ToString();
         }
         if (IsPostBack) {
            Control selectedControl = Page.GetPostBackControlId();
            if (selectedControl != null) {
               if (selectedControl.GetType() == typeof(DropDownList)) {
                  var control = ConvertTo.GetValue<DropDownList>(selectedControl);
                  string section = this.GetFocusSection(control);
                  CurrentUser = control.SelectedItem.Text;
                  __activeFocus = String.IsNullOrEmpty(section) ? __activeFocus : section;
                  __activeFocus = String.IsNullOrEmpty(__activeFocus) ? "" : __activeFocus;
               }
               else if (selectedControl.GetType() == typeof(Button)) {
                  var control = ConvertTo.GetValue<Button>(selectedControl);
                  string section = this.GetFocusSection(control);
                  __activeFocus = String.IsNullOrEmpty(section) ? __activeFocus : section;
                  __activeFocus = String.IsNullOrEmpty(__activeFocus) ? "" : __activeFocus;
               }
            }
         }

         DropDownList[] selectArray = { selectChangeUser1, selectDeleteUser1, selectUserForSchemaEdit, selectUserForConsentEdit, selectUserForWorkflowEdit, selectUserForExaminationAccept };
         foreach (DropDownList select in selectArray) {
            select.Items.Clear();
            users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
            users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            if (!String.IsNullOrEmpty(CurrentUser)) {
               select.SelectedValue = CurrentUser;
            }
         }
         UserCreatorForm.MessageReporter += (string message, bool resultStatus, SystemUser user) => {
            this.CustomMessage = message;
            if (resultStatus) {
               selectArray.AsParallel().ForAll(select => select.Items.Add(
                  !String.IsNullOrEmpty(user.FirstName) && !String.IsNullOrEmpty(user.LastName) ? 
                  new ListItem(user.FirstName + " " + user.LastName, user.LogonName) : 
                  new ListItem(user.LogonName, user.LogonName)
               ));
            }
            responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(resultStatus, __activeFocus, CustomMessage));
         };

         ExaminationBooking.ShowUserDropDown = true;
         BloodDonorBooking.ShowUserDropDown = true;
         if (!String.IsNullOrEmpty(CurrentUser)) {
            ExaminationBooking.CurrentUser = this.CurrentUser;
            BloodDonorBooking.CurrentUser = this.CurrentUser;
            ParkingBooking.CurrentUser = this.CurrentUser;
         }

         //Dynamically add UserControls to page where needed:
         WorkFlowControl workFlowCtrl = (WorkFlowControl)Page.LoadControl("~/Controls/WorkFlowControl.ascx");
         workFlowCtrl.CurrentUser = this.selectUserForWorkflowEdit.SelectedValue;
         workFlowCtrl.ID = "WorkFlowControl";
         this.workflowPlaceHolder.Controls.Add(workFlowCtrl);

         if (selectUserForExaminationAccept.SelectedItem != null) {
            ExaminationAcceptControl selectUserForExminationAcceptCtrl = (ExaminationAcceptControl)Page.LoadControl("~/Controls/ExaminationAcceptControl.ascx");
            selectUserForExminationAcceptCtrl.CurrentUser = this.selectUserForWorkflowEdit.SelectedValue;
            selectUserForExminationAcceptCtrl.RadiosEnabled = true;
            selectUserForExminationAcceptCtrl.ID = "ExaminationAcceptControl";
            this.workflowExaminationAcceptPlaceHolder.Controls.Add(selectUserForExminationAcceptCtrl);
         }
         if (selectUserForConsentEdit.SelectedItem != null) {
            ConsentEditControl selectUserForConsentEditCtrl = (ConsentEditControl)Page.LoadControl("~/Controls/ConsentEditControl.ascx");
            selectUserForConsentEditCtrl.CurrentUser = this.selectUserForConsentEdit.SelectedValue;
            selectUserForConsentEditCtrl.RadiosEnabled = false;
            selectUserForConsentEditCtrl.ID = "ConsentEditControl";
            this.consentEditPlaceHolder.Controls.Add(selectUserForConsentEditCtrl);
         }
         if (selectChangeUser1.SelectedItem != null) {
            UserEditControl selectChangeUser1Ctrl = (UserEditControl)Page.LoadControl("~/Controls/UserEditControl.ascx");
            selectChangeUser1Ctrl.CurrentUser = this.selectChangeUser1.SelectedValue;
            selectChangeUser1Ctrl.MessageReporter += SelectChangeUser1Ctrl_MessageReporter;
            selectChangeUser1Ctrl.ID = "UserEditControl";
            changeUserPlaceHolder.Controls.Add(selectChangeUser1Ctrl);
         }
         if (selectDeleteUser1.SelectedItem != null) {
            UserDeleteControl selectDeleteUser1Ctrl = (UserDeleteControl)Page.LoadControl("~/Controls/UserDeleteControl.ascx");
            selectDeleteUser1Ctrl.CurrentUser = this.selectDeleteUser1.SelectedValue;
            selectDeleteUser1Ctrl.MessageReporter += SelectDeleteUser1Ctrl_MessageReporter;
            selectDeleteUser1Ctrl.ID = "UserDeleteControl";
            deleteUserPlaceHolder.Controls.Add(selectDeleteUser1Ctrl);
         }
         if (selectUserForSchemaEdit.SelectedItem != null) {
            UserSchemaControl selectUserForSchemaEditCtrl = (UserSchemaControl)Page.LoadControl("~/Controls/UserSchemaControl.ascx");
            selectUserForSchemaEditCtrl.CurrentUser = this.selectDeleteUser1.SelectedValue;
            selectUserForSchemaEditCtrl.ID = "UserSchemaControl";
            SchemaEditPlaceHolder.Controls.Add(selectUserForSchemaEditCtrl);
         }
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }

      private void SelectDeleteUser1Ctrl_MessageReporter(string message) {
         this.CustomMessage = message;
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }      

      private void SelectChangeUser1Ctrl_MessageReporter(string message) {
         this.CustomMessage = message;
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }
      [WebMethod]
      public static string SetEmailAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetMailAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string SetPersInfoAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetPersInfoAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string SetSMSAccept(string logonName, bool accept) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = FormModule.SetSMSAccept(logonName, accept);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string SetUserExaminationBooking(int bookingID, string bookingDateTime, string logonName, int examinationApproved, int parkingID, int durationHours) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            DateTime dtTime = DateTime.Parse(bookingDateTime);
            ExaminationBooking exBooking = new ExaminationBooking(bookingID, dtTime, logonName, examinationApproved, durationHours);
            exBooking.ParkingID = parkingID;
            runStatus = Booker.SetExaminationBooking(exBooking);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string GetUserExaminationBooking(string logonName, int bookingID) {
         ExaminationBooking exBooking = null;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            exBooking = Booker.GetUserExaminationBookings(logonName).SingleOrDefault(booking => booking.BookingID == bookingID);
         }
         return JsonConvert.SerializeObject(new { ExaminationBooking = exBooking });
      }
      [WebMethod]
      public static string DeleteHealthExaminatonSchema(int schemaID) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            FormModule.DeleteForm(schemaID);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string BookHealthExamination(DateTime bookingDate, int durationHours, string logonName) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = Booker.BookHealthExamination(bookingDate, durationHours, logonName);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string BookDonorAppointment(DateTime bookingDate, int durationHours, string logonName) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            runStatus = Booker.BookDonorAppointment(bookingDate, durationHours, logonName);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
   }
}