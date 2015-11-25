using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blodbanken.CodeEngines;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Security.Principal;
using System.Reflection;

namespace Blodbanken.CodeEngines {
   public class ReplyObject {
      /// <summary>
      /// The status of the request executed at the server side
      /// </summary>
      public bool RequestStatus { get; set; }
      /// <summary>
      /// The ID of the control that via javascript sould get focus, be scrolled to or expanded.
      /// </summary>
      public string FocusID { get; set; }
      /// <summary>
      /// A message we want to send back to the client
      /// </summary>
      public string CustomMessage { get; set; }
      public ReplyObject(bool requestStatus, string focusID, string customMessage) {
         this.RequestStatus = requestStatus;
         this.FocusID = focusID;
         this.CustomMessage = customMessage;
      }
   }
   public static class ConvertTo {
      public static T GetValue<T>(object item) {
         Type myType = typeof(T);
         try {
            return (T)item;
         } catch {

         }
         return default(T);                  
      }
   }
}