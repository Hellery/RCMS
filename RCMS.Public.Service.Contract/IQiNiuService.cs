using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Public.Service.Contract
{
    public interface IQiNiuService
    {
        ResponseMessage GetToken();
    }
}
