using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos.Base
{
    public interface IBaseRepo<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetOne(int id);
        IEnumerable<T> GetAll();
    }
}
