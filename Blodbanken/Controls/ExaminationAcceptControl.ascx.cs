﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class ExaminationAcceptControl : System.Web.UI.UserControl {
      TimeBooker TimeBookings = new TimeBooker();
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      FormModule FormMod = new FormModule();
      public bool RadiosEnabled { get; set; } = false;
      public string CurrentUser { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         infoPanelHeader.InnerText = "Helseundersøkelser for " + CurrentUser;
         infoPanelHeader.Attributes.Add("data-currentuser", CurrentUser);
         List<ExaminationBooking> eBookings = TimeBookings.GetUserExaminationBookings(CurrentUser);
         SystemUser usr = AuthMod.GetUser(CurrentUser);
         healthExaminationList.Items.Clear();
         foreach (ExaminationBooking eBooking in eBookings) {
            ListItem item = new ListItem(usr.FirstName + " " + usr.LastName + " - " + eBooking.BookingDate, eBooking.BookingID.ToString());
            item.Attributes.Add("data-parkingid", eBooking.ParkingID.ToString());
            item.Attributes.Add("data-durationhours", eBooking.DurationHours.ToString());
            item.Attributes.Add("data-bookingdatetime", JsonConvert.SerializeObject(eBooking.BookingDate));
            healthExaminationList.Items.Add(item);
         }
         radiosExaminationAccept1a.Disabled = !RadiosEnabled;
         radiosExaminationAccept1b.Disabled = !RadiosEnabled;
         ExaminationBooking selectedBooking = eBookings.SingleOrDefault(booking => booking.BookingID == Int32.Parse(healthExaminationList.SelectedItem.Value));
         if (selectedBooking != null) {
            radiosExaminationAccept1a.Checked = DateTime.Compare(DateTime.Now.AddDays(-30), selectedBooking.ExaminationApproved) <= 0; 
            radiosExaminationAccept1b.Checked = DateTime.Compare(DateTime.Now.AddDays(-30), selectedBooking.ExaminationApproved) >= 0;
         }
         if (healthExaminationList.Items.Count == 0) {
            radiosExaminationAccept1a.Disabled = true;
            radiosExaminationAccept1b.Disabled = true;
         }

         userSchemaAcceptHeader.InnerText = "Helseundersøkelser for " + CurrentUser;
         userSchemaAcceptHeader.Attributes.Add("data-currentuser", CurrentUser);
         List<Schema> userSchemas = FormMod.GetUserSchemaForm(CurrentUser);
         selectUserSchemaAcceptList.Items.Clear();
         foreach (Schema schema in userSchemas) {
            ListItem item = new ListItem(usr.FirstName + " " + usr.LastName + " - " + schema.schemaID, schema.schemaID.ToString());
            selectUserSchemaAcceptList.Items.Add(item);
         }
      }
   }
}