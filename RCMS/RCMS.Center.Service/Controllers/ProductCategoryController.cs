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
    /// <summary>
    /// 产品分类控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductCategoryController : ApiController, IProductCategoryService
    {
        private static readonly ProductCategoryService service = new ProductCategoryService();

        /// <summary>
        /// 获取所有产品分类
        /// </summary>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
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
