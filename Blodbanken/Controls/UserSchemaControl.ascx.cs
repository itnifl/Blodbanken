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
      FormModule FormMaster = new FormModule();
      protected void Page_Load(object sender, EventArgs e) {
         //FormMaster.GetUserSchemaForm();
      }
      public void DeleteForm(object sender, CommandEventArgs e) {
         if (e.CommandName == btnDeleteUserForm.CommandName) {
            //FormMaster.DeleteForm(sele);
         }         
      }
   }
}