using Repository.Context;
using Repository.Repos;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IUnitOfWork
    {
        DynamicContext Context { get; set; }
        bool IsDisposed { get; }
        IUserAuthRepository UserAuthRepository { get; }
        IUserRepository UserRepository { get; }

        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
