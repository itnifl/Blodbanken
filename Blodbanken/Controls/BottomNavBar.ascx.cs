using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.Controls {
   public partial class BottomNavBar : System.Web.UI.UserControl {
      public string NextLink { get; set; }
      public string PrevLink { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         aNextLink.NavigateUrl = NextLink;
         aPrevLink.NavigateUrl = PrevLink;
      }
   }
}