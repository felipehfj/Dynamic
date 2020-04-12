using Repository.Context;
using Repository.Entities;

namespace Repository.Repos
{
    public class UserAuthRepository : Repository<UserAuth>, IUserAuthRepository
    {
        public DynamicContext Context { get; }
        public UserAuthRepository(DynamicContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
