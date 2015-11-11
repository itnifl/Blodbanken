using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.WorkflowItems {
   public partial class BookMedicalExamination : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            ExaminationBookingForm.CurrentUser = HttpContext.Current.User.Identity.Name;
         }
         BottomNavBar.CurrentLink = "/WorkflowItems/QuestionForm.aspx";
         BottomNavBar.CurrentLinkText = "<ul><li><b>Egenerklæring</b></li></ul>";
      }
   }
}