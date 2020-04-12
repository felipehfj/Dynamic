using Repository.Repos;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Core
{
    public class BaseBusiness<T> : IBusiness<T> where T : class
    {
        public IRepository<T> Repository { get; }
        public IUnitOfWork UnitOfWork { get; }

        public BaseBusiness(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }
        public virtual int Count()
        {
            try
            {
                return Repository.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual bool Delete(T obj)
        {
            try
            {
                return Repository.Delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual bool Exists(params object[] id)
        {
            try
            {
                return Repository.Exists(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T Insert(T obj)
        {
            try
            {
                return Repository.Insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual List<T> Select()
        {
            try
            {
                return Repository.Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual List<T> Select(Expression<Func<T, bool>> where)
        {
            try
            {
                return Repository.Select(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IQueryable<T> Select(Expression<Func<T, bool>> where, params string[] args)
        {
            try
            {
                return Repository.Select(where, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IQueryable<T> Select(params string[] args)
        {
            try
            {
                return Repository.Select(args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T SelectByKey(params object[] id)
        {
            try
            {
                return Repository.SelectByKey(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T Update(T obj)
        {
            try
            {
                return Repository.Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<int> CountAsync()
        {
            try
            {
                return await Repository.CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<bool> ExistsAsync(params object[] id)
        {
            try
            {
                return await Repository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> InsertAsync(T obj)
        {
            try
            {
                return await Repository.InsertAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<List<T>> SelectAsync()
        {
            try
            {
                return await Repository.SelectAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<List<T>> SelectAsync(Expression<Func<T, bool>> where)
        {
            try
            {
                return await Repository.SelectAsync(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> where, params string[] args)
        {
            try
            {
                return await Repository.SelectAsync(where, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<IQueryable<T>> SelectAsync(params string[] args)
        {
            try
            {
                return await Repository.SelectAsync(args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> SelectByKeyAsync(params object[] id)
        {
            try
            {
                return await Repository.SelectByKeyAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> UpdateAsync(T obj)
        {
            try
            {
                return await Repository.UpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
