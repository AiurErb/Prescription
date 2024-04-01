﻿using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using System.Transactions;

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

        public virtual T? GetOne(long id)
        {
            return _connection.Get<T>(id);
        }

        public virtual long Insert(T entity)
        {
            return _connection.Insert<T>(entity);            
        }

        public virtual void Update(T entity)
        {
            _connection.Update<T>(entity);
        }
        public virtual List<U> GetDepend<U>(long id, string foreignKey) where U : class
        {
            string tableName = typeof(U).Name;
            string sql = $"SELECT * FROM {tableName} WHERE {foreignKey} = @id";
            return _connection.Query<U>(sql, new { id = id }).ToList();
        }
    }
}