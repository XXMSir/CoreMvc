using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace XuDal.IDal
{
    public interface IBaseDal<T> where T : class
    {
        void Add(T t);
        void AddRange(IEnumerable<T> t);
        void Delete(T t);
        void Delete(IEnumerable<T> t);
        void Delete(Expression<Func<T, bool>> whereLambda);
        void Update(T t);
        int GetCount(Expression<Func<T, bool>> whereLambda);
        int ExecuteSql(string sql, SqlParameter parameter = null);
        IEnumerable<TR> SqlQuery<TR>(string sql);
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// </summary>
        bool SaveChanges();
    }
}
