﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class ParkingBookingControl1 : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
            List<SystemUser> users = AuthMod.GetAllUsers();
            DropDownList[] selectArray = { selectUserForParkingBooking_1 };
            if (selectUserForParkingBooking_1.SelectedItem != null) {
               CurrentUser = selectUserForParkingBooking_1.Text;
            }
            foreach (DropDownList select in selectArray) {
               select.Items.Clear();
               users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
               users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
            }
         } else {
            selectUserForParkingBooking_1.Visible = false;
            labelfor_selectUserForParkingBooking_1.Visible = false;
         }
      }
   }
}