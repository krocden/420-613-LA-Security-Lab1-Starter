using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            //throw new Exception();
            return View();
        }

        public ActionResult ServerError()
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);
            }


            ViewBag.CurrentURL = Request.QueryString["asperrorpath"];
            return View();
        }
        public ActionResult Index()
        {
            //throw new Exception();
            return View();
        }
    }
}