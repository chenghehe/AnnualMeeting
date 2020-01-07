using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Client, Duration = int.MaxValue)]
        public ActionResult Error()
        {
            return View();
        }
    }
}