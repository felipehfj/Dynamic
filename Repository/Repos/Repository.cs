using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DynamicContext Context { get; }

        public DbSet<T> DBSet { get; }

        public Repository(DynamicContext context)
        {
            Context = context;
        }
        public virtual int Count()
        {
            try
            {
                return Context.Set<T>().Count();
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
                return await Context.Set<T>().CountAsync();
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
                Context.Set<T>().Remove(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<bool> DeleteAsync(T obj)
        {
            try
            {
                await Task.Run(() => Context.Set<T>().Remove(obj));
                return true;
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
                return Context.Set<T>().Find(id) != null;
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
                return await Context.Set<T>().FindAsync(id) != null;
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
                Context.Set<T>().Add(obj);

                return obj;
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
                await Context.Set<T>().AddAsync(obj);

                return obj;
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
                var ret = Context.Set<T>().Find(id);

                return ret;
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
                var ret = await Context.Set<T>().FindAsync(id);

                return ret;
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
                var @return = Context.Set<T>().ToList();

                return @return;
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
                var @return = await Context.Set<T>().ToListAsync();

                return @return;
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
                var @return = Context.Set<T>().Where(where).ToList();

                return @return;
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
                var @return = await Context.Set<T>().Where(where).ToListAsync();

                return @return;
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
                var argsList = args.ToList().AsEnumerable();
                var @return = Context.Set<T>().Include(argsList).Where(where).AsQueryable();

                return @return;
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
                var argsList = args.ToList().AsEnumerable();
                var @return = await Task.Run(() => Context.Set<T>().Include(argsList).Where(where).AsQueryable());

                return @return;
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
                var argsList = args.ToList().AsEnumerable();
                var @return = Context.Set<T>().Include(argsList).AsQueryable();

                return @return;
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
                var argsList = args.ToList().AsEnumerable();
                var @return = await Task.Run(() => Context.Set<T>().Include(argsList).AsQueryable());

                return @return;
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
                Context.Set<T>().Update(obj);
                return obj;
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
                await Task.Run(() => Context.Set<T>().Update(obj));

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
