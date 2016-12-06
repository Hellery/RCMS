using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using RFramework.Message;
using RCMS.Public.Service.Contract;
using RCMS.Infrastruture.Utilities;

namespace RCMS.Public.Service.Controllers
{

    public class ConfigInfoController : ApiController, IConfigInfoService
    {
        [HttpGet]
        [HttpPost]
        public ResponseMessageWrap<ServiceConfigResponse> GetServiceConfig(NoneRequest resMsg)
        {
            return new ResponseMessageWrap<ServiceConfigResponse>
            {
                Body = ServiceLoader.Instance.ServiceConfig
            };
        }
    }

    public class ServiceLoader
    {
        /// <summary>
        /// 服务配置默认值
        /// </summary>
        private string configPath = "Config/Services.xml";

        public ServiceConfigResponse ServiceConfig { get; private set; }

        /// <summary>
        /// 服务配置路径
        /// </summary>
        public String ServiceConfigPath
        {
            get { return configPath; }
            set { configPath = value; }
        }
        #region Singleton
        private static ServiceLoader instance;
        private static readonly object syncLock = new object();

        private ServiceLoader()
        {
            LoadService(configPath);
        }

        public static ServiceLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new ServiceLoader();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 重置实例
        /// </summary>
        public void Reset()
        {
            LoadService(configPath);
        }
        #endregion
        /// <summary>
        /// 加载服务配置文件
        /// </summary>
        /// <param name="configPath"></param>
        private void LoadService(string configPath)
        {
            string fullPath;
            if (configPath.IndexOf(":") > 0)
            {
                fullPath = configPath;
            }
            else
            {
                fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configPath);
            }
            ServiceConfig = XMLHelper.DeserializeByFilePath<ServiceConfigResponse>(fullPath);

        }

        /// <summary>
        /// 获取服务Api
        /// </summary>
        /// <param name="FullCode"></param>
        /// <returns></returns>
        public String GetApiUrl(String FullCode)
        {
            var services = ServiceConfig.Services;
            string[] codes = FullCode.Split('.');
            if (codes.Length != 4)
            {
                throw new ArgumentException("参数[FullCode]不合法！");
            }
            string serviceCode = codes[0] + "." + codes[1];
            ServiceConfigResponse.Service serviceItem = services.Single(m => m.Code == serviceCode);

            string controllerCode = codes[2];
            ServiceConfigResponse.Controller controllerItem = serviceItem.Controllers.Single(m => m.Code == controllerCode);

            string actionCode = codes[3];
            ServiceConfigResponse.Action actionItem = controllerItem.Actions.Single(m => m.Code == actionCode);

            string strApi = String.Format("{0}/{1}/{2}", serviceItem.Host, controllerItem.Name, actionItem.Name);
            return strApi;
        }

    }

}
