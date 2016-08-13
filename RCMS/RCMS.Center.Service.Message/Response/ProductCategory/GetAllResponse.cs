using RCMS.Center.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Center.Service.Message.Response.ProductCategory
{
    public class GetAllResponse
    {
        public IList<T_ProductCategory> CategoryList { get; set; }
    }
}
