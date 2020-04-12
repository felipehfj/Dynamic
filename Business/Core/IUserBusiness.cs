using Domain.Models;
using Domain.Responses;
using Repository.Entities;

namespace Business.Core
{
    public interface IUserBusiness : IBusiness<User>
    {
        IGenericResponse Insert(IGenericModel<UserAddModel> model);
        IGenericResponse SelectAll();
        IGenericResponse GetUserByLoginAndPassword(string login, string password);
    }
}