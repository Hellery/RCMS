using RCMS.Public.Entity;
using Rocher.Infrastructure.MyBatis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMS.Public.DataAccess
{
    /// <summary>
    ///应用API
    /// </summary>	
    public class T_AppDataAccess : DataAccessGeneric<T_App>
    {
        public T_AppDataAccess(String sqlMapConfigPath = "SqlMap.config")
            : base(sqlMapConfigPath)
        {

        }
        #region Base Method
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(T_App entity)
        {
            return Insert<long>(entity);
        }
        /// <summary>
        /// 删除[逻辑删除,不作物理删除]
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(long Id)
        {
            return Delete<long>(Id);
        }
        /// <summary>
        /// 删除[逻辑删除,不作物理删除]
        /// </summary>
        /// <param name="Ids">逗号分隔字符串</param>
        /// <returns></returns>
        public int DeleteList(long[] Ids)
        {
            String NewSqlId = DefaultCommand.DeleteList;
            Hashtable Params = new Hashtable();
            Params.Add("Ids", Ids);
            return SqlEntity.Update(GetStatementName(NewSqlId), Params);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">默认键位[Id]</param>
        /// <returns></returns>
        public T_App GetEntity(long Id)
        {
            return GetEntity<long>(Id);
        }

        /// <summary>
        /// 获取数据集合-强实体类型
        /// </summary>
        /// <param name="reqParams"></param>
        /// <returns></returns>
        public IList<T_App> GetList(Hashtable reqParams)
        {
            return GetList<T_App>(reqParams);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public IList<T_App> GetListByPage(Hashtable reqParams, int pageSize, int pageIndex)
        {
            if (reqParams == null)
            {
                reqParams = new Hashtable();
            }
            reqParams.Add("PageIndex", pageIndex);
            reqParams.Add("PageSize", pageSize);
            return GetListByPage<T_App>(reqParams);
        }

        /// <summary>
        /// 获取前N行数据
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="reqParams"></param>
        /// <returns></returns>
        public IList<T_App> GetTop(int topNum, Hashtable reqParams)
        {
            return GetTop<T_App>(topNum, reqParams);
        }
        #endregion

        public T_App Auth(long AppId, String AppSecret)
        {
            Hashtable reqParams = new Hashtable();
            reqParams.Add("AppId", AppId);
            reqParams.Add("AppSecret", AppSecret);
            return SqlEntity.QueryForObject<T_App>(GetStatementName("Auth"), reqParams);
        }
    }
}
