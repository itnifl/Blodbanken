using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.WorkflowItems {
   public partial class PersInfoConsent : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            ConsentEditForm.CurrentUser = HttpContext.Current.User.Identity.Name;
         }
         BottomNavBar.NextLink = "/WorkflowItems/PersInfoPage.aspx";
         BottomNavBar.PrevLink = "/WorkflowItems/BookParking.aspx";
      }
   }
}