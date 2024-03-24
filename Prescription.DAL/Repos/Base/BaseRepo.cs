using Microsoft.Data.SqlClient;
using Dapper.Contrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Prescription.DAL.Entities.Base;
//using Prescription.Models;

namespace Prescription.DAL.Repos.Base
{
    public abstract class BaseRepo<T>: IBaseRepo<T> where T: DbEntity, new()
    {
        private SqlConnection _connection;
        public BaseRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Delete(T entity)
        {
            _connection.Delete<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }

        public T? GetOne(int id)
        {
            return _connection.Get<T>(id);
        }

        public void Insert(T entity)
        {
           _connection.Insert<T>(entity);
        }

        public void Update(T entity)
        {
            _connection.Update<T>(entity);
        }
    }
}
