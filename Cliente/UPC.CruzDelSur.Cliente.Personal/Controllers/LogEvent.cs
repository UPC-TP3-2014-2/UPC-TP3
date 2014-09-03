using System;
using System.Web.Management;

namespace UPC.CruzDelSur.Cliente.Personal.Controllers
{
    public class LogEvent : WebRequestErrorEvent
    {
        public LogEvent(string message)
            : base(null, null, 100001, new Exception(message))
        {
        }

        public LogEvent(Exception ex)
            : base(null, null, 100001, ex)
        {
        }
    }
}