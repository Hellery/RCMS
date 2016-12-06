using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCMS.Controllers
{
    public class AgentController : AdminController
    {
        /// <summary>
        /// 代理API
        /// </summary>
        /// <param name="fullCode"></param>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public String Api(String fullCode, String reqMsg)
        {
            return SendApi(fullCode, reqMsg);
        }

        private String SendApi(String fullCode, String reqMsg)
        {
            var jObj = new JObject();
            if (reqMsg != null)
            {
                jObj = JObject.Parse(reqMsg);
            }

            jObj["Header"] = JToken.FromObject(RequestHeader);
            var resp = ServiceClient.Execute(fullCode, jObj.ToString());
            Response.ContentType = "application/json";
            return resp;
        }


    }
}