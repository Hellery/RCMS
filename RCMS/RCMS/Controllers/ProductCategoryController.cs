using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCMS.Controllers
{
    public class ProductCategoryController : AdminController
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}