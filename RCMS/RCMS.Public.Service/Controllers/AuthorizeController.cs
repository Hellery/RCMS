using RCMS.Public.DomainService;
using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RCMS.Public.Service.Controllers
{
    public class AuthorizeController : ApiController
    {
        private readonly static AppService service = new AppService();
        [HttpPost]
        public ResponseMessageWrap<AuthResponse> Auth(AuthRequest reqMsg)
        {
            String Token = service.Auth(reqMsg.AppId, reqMsg.AppSecret);
            var resp = new ResponseMessageWrap<AuthResponse>
            {
                Body = new AuthResponse
                {
                    Token = Token
                }
            };
            return resp;
        }
    }
}
