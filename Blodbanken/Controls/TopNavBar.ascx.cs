﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Blodbanken {
   public partial class WebUserControl1 : System.Web.UI.UserControl {
      public string UserName = "No one";
      protected void Page_Load(object sender, EventArgs e) {
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            UserName = HttpContext.Current.User.Identity.Name;
         }
         lblLoggedInUsername.Text = UserName;
      }
   }
}