using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using NTier_Architecture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> _set;
        public ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }




        public void Add(T entity)
        {
            _set.Add(entity);
            
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return _set;
        }

        public T GetT(Expression<Func<T, bool>> predicate) => _set.Where(predicate).FirstOrDefault();
    }
}
