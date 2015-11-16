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
   public partial class UserArea : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      private string fullName;
      public string CustomMessage { get; set; }
      private string __activeFocus { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            CurrentUser = HttpContext.Current.User.Identity.Name;
            if (String.IsNullOrEmpty(CurrentUser)) {
               Response.Redirect("/Public/Login.aspx");
            }
            SystemUser user = AuthMod.GetUser(CurrentUser);
            fullName = (String.IsNullOrEmpty(user.FirstName) ? String.Empty : user.FirstName + " ") + (String.IsNullOrEmpty(user.LastName) ? String.Empty : (user.LastName));            
            if (String.IsNullOrEmpty(fullName)) {
               fullName = CurrentUser;
            }
            lblLoggedInFullName.Text = fullName;

            if (!String.IsNullOrEmpty(CurrentUser)) {
               WorkFlowControl workFlowCtrl = (WorkFlowControl)Page.LoadControl("~/Controls/WorkFlowControl.ascx");
               workFlowCtrl.CurrentUser = CurrentUser;
               this.workflowPlaceHolder.Controls.Add(workFlowCtrl);
            }
            if (!String.IsNullOrEmpty(CurrentUser)) {
               ConsentEditControl selectUserForConsentEditCtrl = (ConsentEditControl)Page.LoadControl("~/Controls/ConsentEditControl.ascx");
               selectUserForConsentEditCtrl.CurrentUser = CurrentUser;
               this.consentEditPlaceHolder.Controls.Add(selectUserForConsentEditCtrl);
            }
            if (!String.IsNullOrEmpty(CurrentUser)) {
               UserEditControl selectChangeUser1Ctrl = (UserEditControl)Page.LoadControl("~/Controls/UserEditControl.ascx");
               selectChangeUser1Ctrl.CurrentUser = CurrentUser;
               selectChangeUser1Ctrl.MessageReporter += SelectChangeUser1Ctrl_MessageReporter;
               changeUserPlaceHolder.Controls.Add(selectChangeUser1Ctrl);
            }
         } else {
            Response.Redirect("/Public/Login.aspx");
         }
      }

      private void SelectChangeUser1Ctrl_MessageReporter(string message) {
         this.CustomMessage = message;
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }
   }
}