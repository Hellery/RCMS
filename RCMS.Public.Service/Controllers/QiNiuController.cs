using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qiniu.RS;
using System.Web.Http.Cors;
using RFramework.Message;
using RCMS.Public.Service.Contract;
using RFramework.Filter;
using System.Web.Http.Description;

namespace RCMS.Public.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QiNiuController : ApiController,IQiNiuService
    {
        static QiNiuController()
        {
            Qiniu.Conf.Config.Init();
        }

        /// <summary>
        /// 七牛云存储访问获取token 
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [NoneToken]
        [HttpPost]
        [HttpGet]
        public ResponseMessage GetToken()
        {
            var policy = new PutPolicy("i4ta");
            string token = policy.Token();
            return new RFramework.Message.ResponseMessage {
                Body=new { uptoken=token}
            };
        }
    }
}
