using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using XuMvc;

namespace XuDal.Dal
{
    public class BaseDal<T> where T : class, new()
    {
        /// <summary>
        /// IDbConnection(Dapper使用)
        /// </summary>
        protected readonly IDbConnection _dbConnection;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected readonly XuModel.Db.XuDbContext _db;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="_db"></param>
        public BaseDal(XuModel.Db.XuDbContext db, IDbConnection dbConnection)
        {
            _db = db;
            _dbConnection = dbConnection;
        }
        public void Add(T t)
        {
            _db.Set<T>().Add(t);
        }
        public void AddRange(IEnumerable<T> t)
        {
            _db.AddRange(t);
        }
        public void Delete(T t)
        {
            _db.Set<T>().Remove(t);
        }
        public void Delete(IEnumerable<T> t)
        {
            _db.Set<T>().RemoveRange(t);
        }
        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            _db.Set<T>().RemoveRange(_db.Set<T>().Where(whereLambda));
        }
        public int GetCount(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Count(whereLambda);
        }
        public void Update(T t)
        {
            _db.Set<T>().Update(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return _db.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _db.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public int ExecuteSql(string sql, SqlParameter parameter = null)
        {
            if (parameter == null)
                return _db.Database.ExecuteSqlCommand(sql);
            else
                return _db.Database.ExecuteSqlCommand(sql, parameter);
        }
        public IEnumerable<TR> SqlQuery<TR>(string sql)
        {

            return _dbConnection.Query<TR>(sql);

        }
        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
