using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFramework.Message;
using RCMS.Center.Service.Message.Response.ProductCategory;

namespace RCMS.Test.Center
{
    [TestClass]
    public class ProductCategory_Test : TestBase
    {
        [TestMethod]
        public void GetProductCategory_Test()
        {
            var resp = client.Execute<NoneRequest, GetAllResponse>("T.PC.GetAll", new NoneRequest
            {

            });
            Assert.IsTrue(resp.IsSuccess);
        }
    }
}
