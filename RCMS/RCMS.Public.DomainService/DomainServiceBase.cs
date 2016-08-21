using RFramework.Cache.Interface;
using RFramework.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RCMS.Public.DomainService
{
    public abstract class DomainServiceBase
    {
        public CacheProvider CacheProvider { get { return BaseProvider.LoadInstance<CacheProvider>("RedisCacheProvider"); } }

        public Logger Logger { get { return LogManager.GetCurrentClassLogger(); } }
    }
}
