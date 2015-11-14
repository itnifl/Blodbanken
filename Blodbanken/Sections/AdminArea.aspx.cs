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
      public string CurrentUser { get; set;  }
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
         return "";
      }
      private T CastToType<T>(object input) {
         return (T)input;
      }
      protected void Page_Load(object sender, EventArgs e) {
         List<SystemUser> users = AuthMod.GetAllUsers();

         if (IsPostBack) {
            Control selectedControl = Page.GetPostBackControlId();
            if (selectedControl.GetType() == typeof(DropDownList)) {
               var control = CastToType<DropDownList>(selectedControl);
               CurrentUser = control.SelectedItem.Text;
               __activeFocus = this.GetFocusSection(control);
            } else if (selectedControl.GetType() == typeof(Button)) {
               var control = CastToType<Button>(selectedControl);
               __activeFocus = this.GetFocusSection(control);
            }            
         }

         DropDownList[] selectArray = { selectChangeUser1 , selectDeleteUser1, selectUserForSchemaEdit, selectUserForConsentEdit, selectUserForWorkflowEdit, selectUserForExaminationAccept };
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
            this.workflowExaminationAcceptPlaceHolder.Controls.Add(selectUserForExminationAcceptCtrl);
         }
         if (selectUserForConsentEdit.SelectedItem != null) {
            ConsentEditControl selectUserForConsentEditCtrl = (ConsentEditControl)Page.LoadControl("~/Controls/ConsentEditControl.ascx");
            selectUserForConsentEditCtrl.CurrentUser = this.selectUserForConsentEdit.SelectedValue;
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
            deleteUserPlaceHolder.Controls.Add(selectDeleteUser1Ctrl);
         }
         if (selectUserForSchemaEdit.SelectedItem != null) {
            UserSchemaControl selectUserForSchemaEditCtrl = (UserSchemaControl)Page.LoadControl("~/Controls/UserSchemaControl.ascx");
            selectUserForSchemaEditCtrl.CurrentUser = this.selectDeleteUser1.SelectedValue;
            SchemaEditPlaceHolder.Controls.Add(selectUserForSchemaEditCtrl);
         }
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
   }
}