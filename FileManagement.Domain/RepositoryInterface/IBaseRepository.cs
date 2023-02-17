﻿using System.Linq.Expressions;

namespace FileManagement.Domain.RepositoryInterface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string[] includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string[] includes = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task SaveAsync();
    }
}
