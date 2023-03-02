using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Account.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace Account.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataBaseContext _context;
        public GenericRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
