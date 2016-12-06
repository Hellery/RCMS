using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFramework.Message;
using RCMS.Center.Service.Message.Response.ProductCategory;
using RCMS.Center.DomainService;
using RCMS.Public.DomainService;

namespace RCMS.Test.Center
{
    [TestClass]
    public class ProductCategory_Test : TestBase
    {
        private static readonly ProductCategoryService service = new ProductCategoryService();
    
        [TestMethod]
        public void GetProductCategory_Test()
        {
            var resp = client.Execute<NoneRequest, GetAllResponse>("T.PC.GetAll", new NoneRequest
            {

            });
            Assert.IsTrue(resp.IsSuccess);
        }

        [TestMethod]
        public void GetAllCategoryService_Test()
        {
            var categoryList = service.GetAll();
        }

      
    }
}
