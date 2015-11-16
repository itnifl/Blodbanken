using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Blodbanken.CodeEngines;

namespace Blodbanken.Sections {
   public partial class UserCreator : System.Web.UI.Page {
      public string CustomMessage { get; set; }
      private string __activeFocus { get; set; }
      protected void Page_Load(object sender, EventArgs e) {
         UserCreatorForm.MessageReporter += UserCreatorForm_MessageReporter;
      }

      private void UserCreatorForm_MessageReporter(string message) {
         this.CustomMessage = message;
         responsebox.InnerText = JsonConvert.SerializeObject(new ReplyObject(true, __activeFocus, CustomMessage));
      }
   }
}