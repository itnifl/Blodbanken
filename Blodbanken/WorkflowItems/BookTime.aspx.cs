using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Blodbanken.Controls;

namespace Blodbanken.WorkflowItems {
   public partial class BookTime : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            if (IsPostBack) {
               Control selectedControl = Page.GetPostBackControlId();
               if (selectedControl != null) {
                  if (selectedControl.GetType() == typeof(DropDownList)) {
                     var control = ConvertTo.GetValue<DropDownList>(selectedControl);
                     BloodDonorForm.CurrentUser = control.SelectedItem.Value;
                  }
               }
            }
            if (String.IsNullOrEmpty(BloodDonorForm.CurrentUser)) BloodDonorForm.CurrentUser = HttpContext.Current.User.Identity.Name;
            BottomNavBar.PrevLink = "/WorkflowItems/BookMedicalExamination.aspx";
            BottomNavBar.NextLink = "/WorkflowItems/BookParking.aspx";
         }
      }
   }
}