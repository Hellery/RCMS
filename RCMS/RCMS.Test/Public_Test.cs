using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFramework.Message;
using RCMS.Public.DomainService;

namespace RCMS.Test
{
    [TestClass]
    public class Public_Test //: TestBase
    {
        private static readonly AppService appservice = new AppService();
        //[TestMethod]
        //public void GetAll_Test()
        //{
        //    var resp = client.Execute<AuthRequest, AuthResponse>("T.P.Auth", new AuthRequest
        //    {
        //        AppId= 800002,
        //        AppSecret= "88B2A59E-E1FB-4A0B-ABEB-485ACB316549",
        //    });
        //}

        [TestMethod]
        public void AuthService_Test()
        {
            var resp = appservice.Auth(800002, "88B2A59E-E1FB-4A0B-ABEB-485ACB316549");
        }
    }
}
