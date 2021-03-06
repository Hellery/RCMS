﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFramework.Cache.Interface;
using RFramework.Provider;
using RCMS.Public.Entity;

namespace RCMS.Test.Provider
{
    [TestClass]
    public class Cache_Test// : TestBase
    {
        public CacheProvider CacheProvider
        {
            get
            {
                return BaseProvider.LoadInstance<CacheProvider>("RedisCacheProvider");
            }
        }

        [TestMethod]
        public void CacheProvider_Test()
        {
            string CacheKey = RFramework.Const.CacheKey.GetApp(800002);
            CacheProvider.Add<T_App>(CacheKey, new T_App
            {
                AppId=800002,
                AppSecret= "88B2A59E-E1FB-4A0B-ABEB-485ACB316549",
                AppName="后台",
                AppStatus=1
            },new TimeSpan(300,1,1,1));
            Assert.IsTrue(true);

            // CacheKey = RFramework.Const.CacheKey.GetApp(800008);
            //CacheProvider.Add<T_App>(CacheKey, new T_App
            //{
            //    AppId = 800008,
            //    AppSecret = "C2456C1B-FF7D-4688-B346-D242A50A6138",
            //    AppName = "后台",
            //    AppStatus = 1
            //});
            //Assert.IsTrue(true);
        }
    }
}
