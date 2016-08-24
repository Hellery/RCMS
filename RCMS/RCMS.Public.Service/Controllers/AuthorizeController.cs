using RCMS.Public.DomainService;
using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RCMS.Public.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
