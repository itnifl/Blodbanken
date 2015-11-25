using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class ConsentEditControl : System.Web.UI.UserControl {
      FormModule FormModule = new FormModule();
      public string CurrentUser { get; set; }
      public bool RadiosEMailAccept { get; set; } = false;
      public bool RadiosPersInfoAccept { get; set; } = false;
      public bool RadiosSMSAccept { get; set; } = false;
      public bool RadiosEnabled { get; set; } = true;
      protected void Page_Load(object sender, EventArgs e) {                  
         HttpContext.Current.User = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            //If the current selected user is the logged in user, then enable the check boxes:
            if (CurrentUser == HttpContext.Current.User.Identity.Name && !RadiosEnabled) {
               RadiosEnabled = !RadiosEnabled;
            }            
         }

         RadiosPersInfoAccept = FormModule.GetPersInfoAccept(CurrentUser);
         RadiosEMailAccept = FormModule.GetMailAccept(CurrentUser);         
         RadiosSMSAccept = FormModule.GetSMSAccept(CurrentUser);

         infoPanelHeaderConsentEdit.InnerHtml = "Samtykker for " + CurrentUser;
         infoPanelHeaderConsentEdit.Attributes.Add("data-currentuser", CurrentUser);
         radiosEMailAccept1a.Checked = RadiosEMailAccept;
         radiosEMailAccept1a.Disabled = !RadiosEnabled;

         radiosEMailAccept1b.Checked = !RadiosEMailAccept;
         radiosEMailAccept1b.Disabled = !RadiosEnabled;

         radiosPersInfoAccept1a.Checked = RadiosPersInfoAccept;
         radiosPersInfoAccept1a.Disabled = !RadiosEnabled;

         radiosPersInfoAccept1b.Checked = !RadiosPersInfoAccept;
         radiosPersInfoAccept1b.Disabled = !RadiosEnabled;

         radiosSMSAccept1a.Checked = RadiosSMSAccept;
         radiosSMSAccept1a.Disabled = !RadiosEnabled;

         radiosSMSAccept1b.Checked = !RadiosSMSAccept;
         radiosSMSAccept1b.Disabled = !RadiosEnabled;
      }
   }
}