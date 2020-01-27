using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [Authorize(Users ="Testuser2")]
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {

            filterContext.ExceptionHandled = true;

            Logger lu = new Logger();
            //Log the error!!
            lu.eventLog(System.Diagnostics.EventLogEntryType.Error, filterContext.Exception.Message);
            //Write to file
            lu.writeLog(filterContext.Exception);

            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Error");
            /*// OR
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/NotFound.cshtml"
            };*/
        }
    }
}