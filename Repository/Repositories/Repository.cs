using Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WebShopContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(WebShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await Save();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Skip((pageNumber -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Save() { await _context.SaveChangesAsync(); }
    }
}
