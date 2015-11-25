using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Blodbanken.CodeEngines;

namespace Blodbanken.WorkflowItems {
   public partial class PersInfoPage : System.Web.UI.Page {
      string CustomMessage { get; set; }
      string __activeFocus { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            UserEditForm.CurrentUser = HttpContext.Current.User.Identity.Name;
         }
         BottomNavBar.NextLink = "/WorkflowItems/QuestionForm.aspx";
         BottomNavBar.PrevLink = "/WorkflowItems/PersInfoConsent.aspx";
         UserEditForm.MessageReporter += (string message) => {
            this.CustomMessage = message;            
            responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
         };
      }
   }
}