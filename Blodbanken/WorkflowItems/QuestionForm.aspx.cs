using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines; /*47-50*/

namespace Blodbanken.WorkflowItems {
   public partial class QuestionForm : System.Web.UI.Page {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set;  }
      SystemUser CurrentUserObject { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            this.CurrentUser = HttpContext.Current.User.Identity.Name;
            CurrentUserObject = AuthMod.GetUser(CurrentUser);
            if (CurrentUserObject.Gender.ToLower() == "emale") {
               radios51a.Disabled = true;
               radios51b.Disabled = true;
            } else if(CurrentUserObject.Gender.ToLower() == "male") {
               radios47a.Disabled = true;
               radios47b.Disabled = true;

               radios48a.Disabled = true;
               radios48b.Disabled = true;

               radios49a.Disabled = true;
               radios49b.Disabled = true;

               radios50a.Disabled = true;
               radios50b.Disabled = true;
            }
         }
         BottomNavBar.CurrentLink = "/WorkflowItems/BookTime.aspx";
         BottomNavBar.CurrentLinkText = "<ul><li><b>Book donortime</b></li></ul>";
      }
   }
}