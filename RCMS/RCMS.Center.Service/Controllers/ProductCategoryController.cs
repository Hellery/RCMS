using RCMS.Center.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RCMS.Center.Service.Message.Response.ProductCategory;
using RFramework.Message;
using RCMS.Center.DomainService;
using System.Web.Http.Cors;

namespace RCMS.Center.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductCategoryController : ApiController, IProductCategoryService
    {
        private static readonly ProductCategoryService service = new ProductCategoryService();
        [HttpPost]
        public ResponseMessageWrap<GetAllResponse> GetAll(NoneRequest reqMsg)
        {
            var categoryList = service.GetAll();
            return new ResponseMessageWrap<GetAllResponse>
            {
                Body = new GetAllResponse
                {
                    CategoryList = categoryList
                }
            };
        }
    }
}
