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
      public string CurrentUser { get; set; }
      public bool RadiosEMailAccept { get; set; } = false;
      public bool RadiosPersInfoAccept { get; set; } = false;
      public bool RadiosSMSAccept { get; set; } = false;
      public bool RadiosEnabled { get; set; } = true;
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelHeaderConsentEdit.InnerHtml = "Samtykker for " + CurrentUser;
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