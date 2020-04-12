using AutoMapper;
using Domain.Models;
using Domain.Responses;
using Repository.Entities;
using Repository.Repos;
using Repository.Services;
using System.Collections.Generic;
using System.Linq;

namespace Business.Core
{
    public class UserBusiness : BaseBusiness<User>, IUserBusiness
    {
        public IUnitOfWork UnitOfWork { get; }
        public IUserRepository UserRepository { get; }
        public IMapper Mapper { get; }
        public IGenericResponse Response { get; set; }
        public UserBusiness(IUserRepository repository
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IGenericResponse genericResponse) : base(repository, unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UserRepository = repository;
            Mapper = mapper;
            Response = genericResponse;
        }

        public IGenericResponse Insert(IGenericModel<UserAddModel> model)
        {
            try
            {
                var r = Mapper.Map<User>(model);
                var ret = UnitOfWork.UserRepository.Insert(r);
                UnitOfWork.SaveChanges();

                Response.Data = Mapper.Map<UserModel>(ret);
            }
            catch (System.Exception ex)
            {
                Response.Data = ex;
                Response.ErrorMessage = ex.Message;
                Response.Success = false;
            }
            return Response;
        }

        public IGenericResponse SelectAll()
        {
            try
            {
                var ret = UnitOfWork.UserRepository.Select(new string[] { "UserAuths" });
                var n = Mapper.ProjectTo<UserModel>(ret.AsQueryable());

                Response.Data = n;
            }
            catch (System.Exception ex)
            {
                Response.Data = ex;
                Response.ErrorMessage = ex.Message;
                Response.Success = false;
            }
            return Response;
        }

        public IGenericResponse GetUserByLoginAndPassword(string login, string password)
        {
            try
            {
                var user = UnitOfWork.UserRepository.Select(c => c.Login == login).FirstOrDefault();

                if (user != null)
                {
                    var userAuth = UnitOfWork.UserAuthRepository.Select(c => c.UserId == user.Id && c.Password == password && c.IsActive == true).FirstOrDefault();

                    if(userAuth != null)
                    {
                        Response.Data = Mapper.Map<UserModel>(user);
                    }
                    else
                    {
                        Response.Success = false;
                        Response.ErrorMessage = $"Invalid credentials";
                    }
                }
                else
                {
                    Response.Success = false;
                    Response.ErrorMessage = $"Invalid User";
                }
            }
            catch (System.Exception ex)
            {
                Response.Data = ex;
                Response.ErrorMessage = ex.Message;
                Response.Success = false;
            }
            return Response;
        }
    }
}
