using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.Controls {
   public partial class BottomNavBar : System.Web.UI.UserControl {
      public string CurrentLink { get; set; }
      public string CurrentLinkText { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         aNextLink.NavigateUrl = CurrentLink;
         aNextLink.Text = CurrentLinkText;
      }
   }
}