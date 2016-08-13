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

namespace RCMS.Center.Service.Controllers
{
    public class ProductCategoryController : ApiController, IProductCategoryService
    {
        private static readonly ProductCategoryService service = new ProductCategoryService();
        public ResponseMessageWrap<GetAllResponse> GetAll()
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
