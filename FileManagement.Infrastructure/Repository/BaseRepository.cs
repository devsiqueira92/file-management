using FileManagement.Domain.RepositoryInterface;
using FileManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FileManagement.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly FileManagementContext _db;
        internal DbSet<T> dbSet;
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
