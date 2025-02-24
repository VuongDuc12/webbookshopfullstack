using Microsoft.EntityFrameworkCore;
using Web.Server.Models;
using System.Linq.Expressions;

namespace Web.Server.Data;
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context){
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id){
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async  Task AddAsync(T entity){
             _context.Set<T>().Add(entity);
             await _context.SaveChangesAsync();

        }
         public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }
    }


