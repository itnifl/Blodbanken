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
         string port = String.IsNullOrEmpty(Request.Url.Port.ToString()) ? String.Empty : ":" + Request.Url.Port.ToString();
         if (!NextLink.Contains("http") && !NextLink.Contains("~")) {
            NextLink = "http://" + Request.Url.Host + port + (NextLink.StartsWith("/") ? NextLink : "/" + NextLink);
         }
         if (!PrevLink.Contains("http") && !PrevLink.Contains("~")) {            
            PrevLink = "http://" + Request.Url.Host + port + (PrevLink.StartsWith("/") ? PrevLink : "/" + PrevLink);
         }
         aNextLink.NavigateUrl = NextLink;
         aPrevLink.NavigateUrl = PrevLink;
      }
   }
}