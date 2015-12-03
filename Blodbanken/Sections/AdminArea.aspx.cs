using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Blodbanken.Controls;
using Newtonsoft.Json;

namespace Blodbanken.Sections {
   public partial class AdminArea : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
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
                  CurrentUser = control.SelectedItem.Value;
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
         if (String.IsNullOrEmpty(CurrentUser) && !IsPostBack) {
            HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
               CurrentUser = HttpContext.Current.User.Identity.Name;
            }
         }
         if ((!String.IsNullOrEmpty(CurrentUser) && IsPostBack) || !IsPostBack) {
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
               if (!String.IsNullOrEmpty(CurrentUser)) {
                  select.SelectedValue = CurrentUser;
               }
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
            selectChangeUser1Ctrl.ChangedNewUser = __activeFocus == "itemUserChanger";
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
            selectUserForSchemaEditCtrl.MessageReporter += (string message, bool status) => {
               this.CustomMessage = message;
               responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(status, __activeFocus, CustomMessage));
            };
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
   }
}