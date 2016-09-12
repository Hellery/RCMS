using RFramework.Message;
using RFramework.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCMS.Controllers
{
    /// <summary>
    /// Base-Class for platform
    /// </summary>
    public class AdminController : Controller
    {
        #region For Api
        /// <summary>
        /// 服务API客户端
        /// </summary>
        protected IServiceClient ServiceClient { get { return new ServiceClient(); } }
        /// <summary>
        /// 请求头
        /// </summary>
        protected RequestHeader RequestHeader
        {
            get
            {
                return new RequestHeader
                {
                    Operator =0,
                    IP = Request.UserHostAddress,
                    Channel = "Manage:Web"
                };
            }
        }

        #endregion
    }
}