using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blodbanken.CodeEngines {
   public static class ExtensionMetods {
      /// <summary>
      /// Gets the ID of the post back control.
      /// </summary>
      /// <param name="page">The page.</param>
      /// <returns></returns>
      public static Control GetPostBackControlId(this Page page, Control hidSourceID = null) {
         if (!page.IsPostBack)
            return null;

         Control control = null;
         string controlName = page.Request.Params["__EVENTTARGET"];
         if (!String.IsNullOrEmpty(controlName)) {
            control = page.FindControl(controlName);
         }
         else {
            //Attempting to find postback when the postback source is a button:
            if (hidSourceID != null && page.Request.Form[hidSourceID.UniqueID] != null && page.Request.Form[hidSourceID.UniqueID] != string.Empty) {
               string ctrlID = page.Request.Form[hidSourceID.UniqueID];
               control = GetControl(page.Master.Controls, ctrlID);
            }            
            if (control == null) {
               foreach (string ctl in page.Request.Form) {
                  Control c = page.FindControl(ctl);
                  if (c is System.Web.UI.WebControls.Button) {
                     control = c;
                     break;
                  }
               }
            }            
         }
         return control;
      }
      public static Control GetControl(ControlCollection controls, string controlToFind) {
         Control foundControl = null;
         foreach (Control ctl in controls) {
            if (ctl.ClientID == controlToFind) {
               return ctl;
            }
            Control searchCtrl = ctl.FindControl(controlToFind);
            if (searchCtrl != null) {
               return searchCtrl;
            }

            if (ctl.Controls.Count > 0)
               GetControl(ctl.Controls, controlToFind);
         }
         return foundControl;
      }
   }
}