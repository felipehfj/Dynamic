using Microsoft.EntityFrameworkCore.Storage;
using Repository.Context;
using Repository.Repos;
using System;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public bool IsDisposed { get; private set; }
        public DynamicContext Context { get; set; }
        public IUserRepository UserRepository { get; }
        public IUserAuthRepository UserAuthRepository { get; }

        public UnitOfWork(DynamicContext context, IUserRepository userRepository, IUserAuthRepository userAuthRepository)
        {
            Context = context;
            UserRepository = userRepository;
            UserAuthRepository = userAuthRepository;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            using (IDbContextTransaction dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //Log Exception Handling message                                          
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task SaveChangesAsync()
        {
            using (IDbContextTransaction dbContextTransaction = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    await Context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //Log Exception Handling message                                          
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
                if (disposing)
                    Context.Dispose();
            IsDisposed = true;
        }
    }
}
