using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Interfaces
{
    public interface IRepoBase<T> where T : class
    {
        T? GetOne(long id);
        Task<List<T>> GetAll(bool filter);
        long Insert(T item);
        bool Update(T item);
        bool Delete(T item);

    }
}
