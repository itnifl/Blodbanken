using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blodbanken.CodeEngines;

namespace Blodbanken.Controls {
   public partial class UserSchemaControl : System.Web.UI.UserControl {
      public string CurrentUser { get; set; }
      public event Action<string> MessageReporter;
      FormModule FormMaster = new FormModule();
      AuthenticatonModule AuthMod = new AuthenticatonModule();
      protected void Page_Load(object sender, EventArgs e) {
         List<Schema> list = FormMaster.GetUserSchemaForm(CurrentUser);
         SystemUser usr = AuthMod.GetUser(CurrentUser);
         list.ForEach(item => selectUserFormList.Items.Add(
            new ListItem(usr.FirstName + " " + usr.LastName + " - " + item.schemaID.ToString(), item.schemaID.ToString()
         )));
         if (selectUserFormList.Items.Count == 0) {
            btnDeleteUserForm.Enabled = false;
         }
      }
      public void DeleteForm(object sender, CommandEventArgs e) {
         bool status = true;
         if (e.CommandName == btnDeleteUserForm.CommandName) {
            int schemaID = -1;
            Int32.TryParse(selectUserFormList.SelectedValue, out schemaID);
            status = FormMaster.DeleteForm(schemaID);
            if (MessageReporter != null) {
               MessageReporter(status ? "Sletting av helseskjema for '" + CurrentUser + "' med ID '"+ schemaID + "' er fullført." : "Sletting av helseskjema for  '" + CurrentUser + "' med ID '" + schemaID + "' feilet.");
            }
         }         
      }
   }
}