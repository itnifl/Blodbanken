using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;
using Newtonsoft.Json;

namespace Blodbanken.Controls {
   public partial class ParkingBookingControl1 : System.Web.UI.UserControl {
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      TimeBooker Booker = new TimeBooker();
      public string CurrentUser { get; set; }
      public DateTime SelectedDate { get; set; }
      public event Action<string, bool> MessageReporter;
      protected void Page_Load(object sender, EventArgs e) {
         System.Security.Principal.GenericPrincipal myUser = (System.Security.Principal.GenericPrincipal)HttpContext.Current.Cache.Get("customPrincipal");
         List<ParkspaceBooking> allParkingAppointments = null;
         List<ExaminationBooking> allExaminationBooking = null;
         List<DonorBooking> allDonorBooking = null;
         SystemUser ourCurrentUser = null;
         if (myUser != null)
            HttpContext.Current.User = myUser;
         if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
            List<SystemUser> users = AuthMod.GetAllUsers();                        
            allDonorBooking = String.IsNullOrEmpty(CurrentUser) ? Booker.GetAllDonorBookings() : Booker.GetAllDonorBookings().Where(booking => booking.LogonName == CurrentUser).ToList();
            allExaminationBooking = String.IsNullOrEmpty(CurrentUser) ? Booker.GetAllExaminationBookings() : Booker.GetAllExaminationBookings().Where(booking => booking.LogonName == CurrentUser).ToList();

            selectUserBookings.Items.Clear();
            allDonorBooking.ForEach(p => {
               ListItem item = new ListItem(p.BookingDate.ToString(), p.BookingID.ToString());
               item.Attributes.Add("data-bookingtype", "donor");
               item.Attributes.Add("data-bookingid", p.BookingID.ToString());
               selectUserBookings.Items.Add(item);
            });
            allExaminationBooking.ForEach(p => {
               ListItem item = new ListItem(p.BookingDate.ToString(), p.BookingID.ToString());
               item.Attributes.Add("data-bookingtype", "examination");
               item.Attributes.Add("data-bookingid", p.BookingID.ToString());
               selectUserBookings.Items.Add(new ListItem(p.BookingDate.ToString(), p.BookingID.ToString()));
            });

            SelectedDate = allDonorBooking.FirstOrDefault() != null ? allDonorBooking.FirstOrDefault().BookingDate : DateTime.Now;

            allParkingAppointments = DateTime.Compare(SelectedDate, DateTime.MinValue) == 0 ? 
               Booker.GetParkspaceBookings().Where(booking => booking.BookingDate.Date == SelectedDate.Date).ToList() : 
               Booker.GetParkspaceBookings();

            if (HttpContext.Current.User.IsInRole(UserRole.Admin.ToString())) {
               DropDownList[] selectArray = { selectUserForParkingBooking_1 };
               foreach (DropDownList select in selectArray) {
                  select.Items.Clear();
                  users.Where(usr => !String.IsNullOrEmpty(usr.FirstName) && !String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.LogonName)));
                  users.Where(usr => String.IsNullOrEmpty(usr.FirstName) && String.IsNullOrEmpty(usr.LastName)).ToList().ForEach(user => select.Items.Add(new ListItem(user.LogonName, user.LogonName)));
               }
               if (!String.IsNullOrEmpty(CurrentUser)) {
                  selectUserForParkingBooking_1.SelectedValue = CurrentUser;
               }
               else if (selectUserForParkingBooking_1.SelectedItem != null) {
                  CurrentUser = selectUserForParkingBooking_1.Text;
               }
            }
            else {
               selectUserForParkingBooking_1.Visible = false;
            }
            if(String.IsNullOrEmpty(CurrentUser)) {
               CurrentUser = HttpContext.Current.User.Identity.Name;
            }
            ourCurrentUser = users.Where(user => user.LogonName == CurrentUser).FirstOrDefault();
         } else {
            selectUserForParkingBooking_1.Visible = false;
            labelfor_selectUserForParkingBooking_1.Visible = false;
         }
         btnBookParking1.Enabled = selectUserBookings.Items.Count != 0;
         
         parkPanelHeader.InnerText = "Reserver parkering for " + (ourCurrentUser == null ? CurrentUser : ourCurrentUser.FirstName + " " + ourCurrentUser.LastName);
         parkPanelHeader.Attributes.Add("data-currentuser", CurrentUser);
         __parkingBeholder.InnerText = JsonConvert.SerializeObject(new { ParkingAppointments = allParkingAppointments });
      }
      public void BookParking(object sender, CommandEventArgs e) {
         String parkSpaceBooking = __selectionInfo.Value;
         BookingSelected bookingSelected = JsonConvert.DeserializeObject<BookingSelected>(parkSpaceBooking);
         bool status = Booker.BookParkingSpace(bookingSelected);
         if (MessageReporter != null && status) {
            MessageReporter("Booking av parkeringsplass nummer " + bookingSelected.SelectedParkingSpace + " den " + bookingSelected.Date + " gikk fint.", status);
         }
         if (MessageReporter != null && !status) {
            MessageReporter("Booking av parkeringsplass nummer " + bookingSelected.SelectedParkingSpace + " feilet.", status);
         }
      }
      protected void calAvailableParkingDate1_SelectionChanged(object sender, EventArgs e) {
         Calendar ourCalendar = (Calendar)sender;
         this.SelectedDate = ourCalendar.SelectedDate;
      }
   }
}