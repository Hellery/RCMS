using RFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Center.Service.Message.Request.ProductCategory
{
    public class MoveCategoryRequest : RequestMessage
    {
        public long CategoryId { get; set; }

        public String TargetCategoryCode { get; set; }

        public int MoveType { get; set; }
    }
}
