using RCMS.Center.Service.Message.Response.ProductCategory;
using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Center.Service.Contract
{
    public interface IProductCategoryService
    {
         // Here Need:  Install-Package RFramework.Message
        ResponseMessageWrap<GetAllResponse> GetAll();
    }
}
