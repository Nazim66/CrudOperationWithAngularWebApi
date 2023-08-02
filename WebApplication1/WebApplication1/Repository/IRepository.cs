using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
