using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Blodbanken.Controls;

namespace Blodbanken.Sections {
   public partial class AdminArea : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {
         List<SystemUser> users = AuthMod.GetAllUsers();

         DropDownList[] selectArray = { selectChangeUser1 , selectDeleteUser1, selectUserForSchemaEdit, selectUserForConsentEdit, selectUserForWorkflowEdit, selectUserForExminationAccept };
         foreach (DropDownList select in selectArray) {
            select.Items.Clear();
            users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
            users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
         }

         //Dynamically add UserControls to page where needed:
         WorkFlowControl workFlowCtrl = (WorkFlowControl)Page.LoadControl("~/Controls/WorkFlowControl.ascx");
         workFlowCtrl.CurrentUser = this.selectUserForWorkflowEdit.SelectedValue;
         this.workflowPlaceHolder.Controls.Add(workFlowCtrl);

         if (selectUserForExminationAccept.SelectedItem != null) {
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
      }
   }
}