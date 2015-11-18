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
      internal static TimeBooker TimeModule = new TimeBooker();
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
      private T CastToType<T>(object input) {
         return (T)input;
      }
      protected void Page_Load(object sender, EventArgs e) {
         List<SystemUser> users = AuthMod.GetAllUsers();

         if (IsPostBack) {
            Control selectedControl = Page.GetPostBackControlId();
            if (selectedControl != null) {
               if (selectedControl.GetType() == typeof(DropDownList)) {
                  var control = CastToType<DropDownList>(selectedControl);
                  CurrentUser = control.SelectedItem.Text;
                  __activeFocus = this.GetFocusSection(control);
               }
               else if (selectedControl.GetType() == typeof(Button)) {
                  var control = CastToType<Button>(selectedControl);
                  __activeFocus = this.GetFocusSection(control);
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
         UserCreatorForm.MessageReporter += UserCreatorForm_MessageReporter;

         //Dynamically add UserControls to page where needed:
         WorkFlowControl workFlowCtrl = (WorkFlowControl)Page.LoadControl("~/Controls/WorkFlowControl.ascx");
         workFlowCtrl.CurrentUser = this.selectUserForWorkflowEdit.SelectedValue;
         this.workflowPlaceHolder.Controls.Add(workFlowCtrl);

         if (selectUserForExaminationAccept.SelectedItem != null) {
            ExaminationAcceptControl selectUserForExminationAcceptCtrl = (ExaminationAcceptControl)Page.LoadControl("~/Controls/ExaminationAcceptControl.ascx");
            selectUserForExminationAcceptCtrl.CurrentUser = this.selectUserForWorkflowEdit.SelectedValue;
            selectUserForExminationAcceptCtrl.RadiosEnabled = true;
            this.workflowExaminationAcceptPlaceHolder.Controls.Add(selectUserForExminationAcceptCtrl);
         }
         if (selectUserForConsentEdit.SelectedItem != null) {
            ConsentEditControl selectUserForConsentEditCtrl = (ConsentEditControl)Page.LoadControl("~/Controls/ConsentEditControl.ascx");
            selectUserForConsentEditCtrl.CurrentUser = this.selectUserForConsentEdit.SelectedValue;
            selectUserForConsentEditCtrl.RadiosEnabled = false;
            this.consentEditPlaceHolder.Controls.Add(selectUserForConsentEditCtrl);
         }
         if (selectChangeUser1.SelectedItem != null) {
            UserEditControl selectChangeUser1Ctrl = (UserEditControl)Page.LoadControl("~/Controls/UserEditControl.ascx");
            selectChangeUser1Ctrl.CurrentUser = this.selectChangeUser1.SelectedValue;
            selectChangeUser1Ctrl.MessageReporter += SelectChangeUser1Ctrl_MessageReporter;
            changeUserPlaceHolder.Controls.Add(selectChangeUser1Ctrl);
         }
         if (selectDeleteUser1.SelectedItem != null) {
            UserDeleteControl selectDeleteUser1Ctrl = (UserDeleteControl)Page.LoadControl("~/Controls/UserDeleteControl.ascx");
            selectDeleteUser1Ctrl.CurrentUser = this.selectDeleteUser1.SelectedValue;
            selectDeleteUser1Ctrl.MessageReporter += SelectDeleteUser1Ctrl_MessageReporter;
            deleteUserPlaceHolder.Controls.Add(selectDeleteUser1Ctrl);
         }
         if (selectUserForSchemaEdit.SelectedItem != null) {
            UserSchemaControl selectUserForSchemaEditCtrl = (UserSchemaControl)Page.LoadControl("~/Controls/UserSchemaControl.ascx");
            selectUserForSchemaEditCtrl.CurrentUser = this.selectDeleteUser1.SelectedValue;
            SchemaEditPlaceHolder.Controls.Add(selectUserForSchemaEditCtrl);
         }
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }

      private void SelectDeleteUser1Ctrl_MessageReporter(string message) {
         this.CustomMessage = message;
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }

      private void UserCreatorForm_MessageReporter(string message) {
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
      public static string SetUserExaminationBooking(int bookingID, string bookingDateTime, string logonName, int examinationApproved, int parkingID) {
         bool runStatus = false;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            DateTime dtTime = DateTime.Parse(bookingDateTime);
            ExaminationBooking exBooking = new ExaminationBooking(bookingID, dtTime, logonName, examinationApproved);
            exBooking.ParkingID = parkingID;
            runStatus = TimeModule.SetExaminationBooking(exBooking);
         }
         return JsonConvert.SerializeObject(new { runStatus = runStatus });
      }
      [WebMethod]
      public static string GetUserExaminationBooking(string logonName, int bookingID) {
         ExaminationBooking exBooking = null;
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Viewer") || HttpContext.Current.User.IsInRole("Donor"))) {
            exBooking = TimeModule.GetUserExaminationBookings(logonName).SingleOrDefault(booking => booking.BookingID == bookingID);
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
   }
}