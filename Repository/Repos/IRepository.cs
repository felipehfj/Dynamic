using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DBSet { get; }
        int Count();
        bool Delete(T obj);
        bool Exists(params object[] id);
        T Insert(T obj);
        T Update(T obj);
        T SelectByKey(params object[] id);
        List<T> Select();
        List<T> Select(Expression<Func<T, bool>> where);
        IQueryable<T> Select(Expression<Func<T, bool>> where, params string[] args);
        IQueryable<T> Select(params string[] args);
        Task<int> CountAsync();
        Task<bool> ExistsAsync(params object[] id);
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> SelectByKeyAsync(params object[] id);
        Task<List<T>> SelectAsync();
        Task<List<T>> SelectAsync(Expression<Func<T, bool>> where);
        Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> where, params string[] args);
        Task<IQueryable<T>> SelectAsync(params string[] args);
    }
}
