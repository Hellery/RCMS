using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFramework.Message;

namespace RCMS.Test
{
    [TestClass]
    public class Public_Test : TestBase
    {
        [TestMethod]
        public void GetAll_Test()
        {
            var resp = client.Execute<AuthRequest, AuthResponse>("T.P.Auth", new AuthRequest
            {
                AppId= 900001,
                AppSercet= "88B2A59E-E1FB-4A0B-ABEB-485ACB316549",
            });
        }
    }
}
