using Repository.Entities;
using Repository.Repos;
using Repository.Services;

namespace Business.Core
{
    public class UserAuthBusiness : BaseBusiness<UserAuth>, IUserAuthBusiness
    {
        public IUnitOfWork UnitOfWork { get; }
        public IUserAuthRepository UserAuthRepository { get; }
        public UserAuthBusiness(IUserAuthRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UserAuthRepository = repository;
        }
    }
}
