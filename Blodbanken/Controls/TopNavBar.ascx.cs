﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Blodbanken.App_Code;

namespace Blodbanken {
   public partial class WebUserControl1 : System.Web.UI.UserControl {
      public string UserName = String.Empty;
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal) HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            UserName = HttpContext.Current.User.Identity.Name;
            lstLogOff.Visible = true;
            lstWelcome.Visible = true;
         } else {
            lstLogOff.Visible = false;
            lstWelcome.Visible = false;
         }
         lblLoggedInUsername.Text = UserName;
         if (HttpContext.Current.User.IsInRole("Admin")) lstAdminLink.Visible = true;
         else lstAdminLink.Visible = false;
      }
   }
}