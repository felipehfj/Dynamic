using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Core
{
    public interface IBusiness<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        int Count();
        Task<int> CountAsync();
        bool Delete(T obj);
        bool Exists(params object[] id);
        Task<bool> ExistsAsync(params object[] id);
        T Insert(T obj);
        Task<T> InsertAsync(T obj);
        List<T> Select();
        List<T> Select(Expression<Func<T, bool>> where);
        IQueryable<T> Select(Expression<Func<T, bool>> where, params string[] args);
        IQueryable<T> Select(params string[] args);
        Task<List<T>> SelectAsync();
        Task<List<T>> SelectAsync(Expression<Func<T, bool>> where);
        Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> where, params string[] args);
        Task<IQueryable<T>> SelectAsync(params string[] args);
        T SelectByKey(params object[] id);
        Task<T> SelectByKeyAsync(params object[] id);
        T Update(T obj);
        Task<T> UpdateAsync(T obj);
    }
}