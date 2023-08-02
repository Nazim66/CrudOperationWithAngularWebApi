using Assignment_Web_API.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _applicationDbContext { get; set; }
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> FindAll() => _applicationDbContext.Set<T>().AsNoTracking();
        public void Create(T entity) => _applicationDbContext.Set<T>().Add(entity);
        public void Update(T entity) => _applicationDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => _applicationDbContext.Set<T>().Remove(entity);
    }
}
