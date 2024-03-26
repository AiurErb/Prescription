using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;

namespace Prescription.DAL.Repos
{
    public class RepoBase<T> where T : class
    {
        protected SqlConnection _connection;

        public void Delete(T entity)
        {
            _connection.Delete<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }

        public T? GetOne(long id)
        {
            return _connection.Get<T>(id);
        }

        public long Insert(T entity)
        {
            return _connection.Insert<T>(entity);
        }

        public void Update(T entity)
        {
            _connection.Update<T>(entity);
        }
    }
}