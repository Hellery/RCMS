using RCMS.Center.DataAccess;
using RCMS.Center.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RCMS.Center.DomainService
{
    public class ProductCategoryService
    {
        private static readonly T_ProductCategoryDataAccess dao = new T_ProductCategoryDataAccess();

        #region Base Method
        public IList<T_ProductCategory> GetAll()
        {
            return dao.GetList<T_ProductCategory>(null);
        }
        /// <summary>
        /// 添加同级分类
        /// </summary>
        /// <param name="currentCode">当前选择的分类Code</param>
        /// <param name="categoryName"></param>
        /// <param name="sortId"></param>
        /// <returns></returns>
        public long Add(String currentCode, String categoryName, long sortId)
        {
            try
            {
                dao.BeginTransaction();
                T_ProductCategory entity = new T_ProductCategory();
                entity.CategoryName = categoryName;
                entity.SortId = sortId;
                entity.CategoryCode = String.Empty;

                long Id = dao.Insert<long>(entity);
                if (currentCode.IndexOf('-') > 0)
                {
                    string[] codes = currentCode.Split('-');
                    entity.CategoryCode = currentCode.Substring(0, currentCode.LastIndexOf('-')) + "-" + Id.ToString();
                    entity.ParentId = long.Parse(codes[codes.Length - 2]);
                }
                else
                {
                    entity.CategoryCode = Id.ToString();
                    entity.CategoryLevel = 0;
                }
                entity.CategoryLevel = entity.CategoryCode.Split('-').Length;
                entity.Id = Id;
                dao.Update(entity);
                dao.CommitTransaction();
                return Id;
            }
            catch (Exception ex)
            {
                dao.RollBackTransaction();
                throw ex;
            }
        }

        public long AddChild(String currentCode, String categoryName, long sortId)
        {
            try
            {
                dao.BeginTransaction();
                T_ProductCategory entity = new T_ProductCategory();
                entity.CategoryName = categoryName;
                entity.SortId = sortId;
                entity.CategoryCode = String.Empty;
                long Id = dao.Insert<long>(entity);

                string[] codes = currentCode.Split('-');
                entity.CategoryCode = currentCode + "-" + Id;

                entity.CategoryLevel = codes.Length;
                entity.ParentId = long.Parse(codes[codes.Length - 1]);
                dao.Update(entity);
                dao.CommitTransaction();
                return Id;
            }
            catch (Exception ex)
            {
                dao.RollBackTransaction();
                throw ex;
            }
        }
        /// <summary>
        /// 移动分类节点
        /// </summary>
        /// <param name="categoryId">当前选择移动的分类</param>
        /// <param name="targetCategoryCode">移动到目标分类的Code</param>
        /// <param name="moveType">移动类型:之前:1  | 之后: 2| 下级: 3</param>
        public int Move(long categoryId, string targetCategoryCode, int moveType)
        {
            var entity_old = dao.GetEntity<long>(categoryId);

            string[] codes = targetCategoryCode.Split('-');

            switch (moveType)
            {
                case 1:
                case 2:
                    {
                        entity_old.CategoryLevel = codes.Length;

                        if (entity_old.CategoryLevel == 1)
                        {
                            entity_old.CategoryCode = entity_old.Id.ToString();
                            entity_old.ParentId = 0;
                        }
                        else
                        {
                            string targetId = codes[codes.Length - 1];
                            entity_old.CategoryCode = targetCategoryCode.Replace(targetId, entity_old.Id.ToString());
                            entity_old.ParentId = long.Parse(codes[codes.Length - 2]);
                        }
                        break;
                    }
                case 3:
                    {
                        entity_old.CategoryLevel = codes.Length + 1;
                        entity_old.CategoryCode = targetCategoryCode + "-" + entity_old.Id;
                        string targetId = codes[codes.Length - 1];
                        entity_old.ParentId = long.Parse(targetId);
                        break;
                    }
                default: { break; }
            }
            return dao.Update(entity_old);
        }

        public int Delete(long Id)
        {
            return dao.Delete<long>(Id);
        }

        public int Update(long categoryId, String categoryName, long sortId)
        {
            var entity_old = dao.GetEntity<long>(categoryId);
            entity_old.CategoryName = categoryName;
            entity_old.SortId = sortId;
            return dao.Update(entity_old);
        }
        #endregion
    }
}
