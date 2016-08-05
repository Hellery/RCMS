using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCMS.Controllers
{
    public class HomeController : AdminController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}