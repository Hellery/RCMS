using RCMS.Center.DomainService;
using RCMS.Center.Service.Message.Response.ProductCategory;
using RFramework.Message;
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

        public JsonResult GetAll()
        {
            var respBody = ServiceClient.Execute<NoneRequest, GetAllResponse>("T.PC.GetAll",new NoneRequest{ }).Body;
            ResponseMessage resp = new ResponseMessage
            {
               Body = respBody
            };
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}