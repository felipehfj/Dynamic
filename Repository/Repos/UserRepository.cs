using Repository.Context;
using Repository.Entities;

namespace Repository.Repos
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public DynamicContext Context { get; }
        public UserRepository(DynamicContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
