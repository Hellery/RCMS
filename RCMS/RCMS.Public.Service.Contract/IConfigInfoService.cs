using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Public.Service.Contract
{
    public interface IConfigInfoService
    {
        /// <summary>
        /// 获取服务配置信息
        /// </summary>
        /// <param name="resMsg"></param>
        /// <returns></returns>
        ResponseMessageWrap<ServiceConfigResponse> GetServiceConfig(NoneRequest resMsg);
    }
}
