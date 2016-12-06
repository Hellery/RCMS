using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Center.Entity
{
    public class T_ProductCategory
    {
        /// <summary>
        /// Id
        /// </summary>		
        public long Id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>		
        public string CategoryName { get; set; }

        /// <summary>
        /// 分类级别
        /// </summary>		
        public int CategoryLevel { get; set; }

        /// <summary>
        /// 父级分类
        /// </summary>		
        public long ParentId { get; set; }

        /// <summary>
        /// 分类树
        /// </summary>		
        public string CategoryCode { get; set; }

        /// <summary>
        /// 序号
        /// </summary>		
        public long SortId { get; set; }

        /// <summary>
        /// 逻辑删除位
        /// </summary>		
        public bool IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>		
        public long Creator { get; set; }
    }
}
