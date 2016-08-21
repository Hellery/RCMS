using RCMS.Public.DataAccess;
using RCMS.Public.Entity;
using RFramework.Infrastructure.Const;
using RFramework.Infrastructure.RException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Public.DomainService
{
    public class AppService : DomainServiceBase
    {
        private static readonly T_AppDataAccess dao = new T_AppDataAccess();
        /// <summary>
        /// 应用授权
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="AppSecret"></param>
        /// <returns></returns>
        public String Auth(long AppId, String AppSecret)
        {
            string cacheKey = CacheKey.GetApp(AppId);
            T_App app = CacheProvider.Get<T_App>(cacheKey);

            if (app == null || app.AppSecret != AppSecret)
            {
                throw new RException("00003", "授权失败！");
            }
            string token = Guid.NewGuid().ToString("N");
            cacheKey = CacheKey.GetTokenKey(token);
            TimeSpan expiry = new TimeSpan(2, 0, 0);
            CacheProvider.Add<T_App>(cacheKey, app, expiry);
            return token;
        }
    }
}
