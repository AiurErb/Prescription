using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Interfaces;
using System.Data;
using System.Transactions;

namespace Prescription.DAL.Repos
{
    public class RepoBase<T> : IRepoBase<T> where T : class
    {
        protected IDbConnection _connection;

        public RepoBase(IDbConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(T entity)
        {
            return _connection.Delete<T>(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            var output = await _connection.GetAllAsync<T>();
            return output.ToList();
        }

        public virtual T? GetOne(long id)
        {
            return _connection.Get<T>(id);
        }

        public virtual long Insert(T entity)
        {
            return _connection.Insert<T>(entity);            
        }

        public virtual bool Update(T entity)
        {
            return _connection.Update<T>(entity);
        }
        public virtual List<U> GetDepend<U>(long id, string foreignKey) where U : class
        {
            string tableName = typeof(U).Name;
            string sql = $"SELECT * FROM {tableName} WHERE {foreignKey} = @id";
            return _connection.Query<U>(sql, new { id = id }).ToList();
        }
        public virtual async Task<List<T>> GetPage(int pageNumber, int pageSize)
        {
            int offset = (pageNumber - 1) * pageSize;
            string sql = $@"
                SELECT * FROM dbo.{typeof(T).Name} 
                OFFSET @Offset ROWS FETCH NEXT @PageSize";
            var param = new
            {
                Offset = offset,
                pageSize = pageSize,
            };
            return _connection.Query<T>(sql, param).ToList();
        }
    }
}