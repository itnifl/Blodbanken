using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Blodbanken.Controls;
using Newtonsoft.Json;

namespace Blodbanken.WorkflowItems {
   public partial class BookParking : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            if (IsPostBack) {
               Control selectedControl = Page.GetPostBackControlId();
               if (selectedControl != null) {
                  var control = ConvertTo.GetValue<DropDownList>(selectedControl);
                  ParkBookingForm.CurrentUser = control != null ? control.SelectedItem.Value : HttpContext.Current.User.Identity.Name;
               }
            }
            if(String.IsNullOrEmpty(ParkBookingForm.CurrentUser))
               ParkBookingForm.CurrentUser = HttpContext.Current.User.Identity.Name;
         }
         BottomNavBar.PrevLink = "/WorkflowItems/BookTime.aspx";
         BottomNavBar.NextLink = "/WorkflowItems/PersInfoConsent.aspx";
         ParkBookingForm.MessageReporter += (string message, bool status) => {
            responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(status, "", message));
         };
      }
   }
}