using Rocher.Infrastructure.MyBatis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Public.Entity
{
    /// <summary>
    ///应用API
    /// </summary>	
    public class T_App
    {
        /// <summary>
        /// 应用Id
        /// </summary>		
        public long AppId { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>		
        public string AppName { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>		
        public string AppSecret { get; set; }

        /// <summary>
        /// 应用描述
        /// </summary>		
        public string AppDesc { get; set; }

        /// <summary>
        /// 应用状态
        /// </summary>		
        public int AppStatus { get; set; }

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
