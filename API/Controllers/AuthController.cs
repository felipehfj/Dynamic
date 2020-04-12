using API.Services;
using AutoMapper;
using Business.Core;
using Domain.Models;
using Domain.Models.Auth;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> Logger { get; }
        private IMapper Mapper { get; }
        private IUserBusiness UserBusiness { get; }
        private Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        private IGenericResponse GenericResponse { get; set; }

        
        public AuthController(ILogger<AuthController> logger
            , IUserBusiness userBusiness
            , IGenericResponse response
            , Microsoft.Extensions.Configuration.IConfiguration configuration
            , IMapper mapper)
        {
            Logger = logger;
            UserBusiness = userBusiness;
            GenericResponse = response;
            Configuration = configuration;
            Mapper = mapper;
        }
        
        [HttpPost]
        public ActionResult Authenticate(LoginModel model)
        {
            GenericResponse = UserBusiness.GetUserByLoginAndPassword(model.Login, model.Password);

            if (GenericResponse.Success)
            {
                var user = (UserModel)GenericResponse.Data;
                var userTokenModel = Mapper.Map<UserTokenModel>(user);
                userTokenModel.Audience = model.Audience;

                var token = TokenService.GenerateToken(userTokenModel, Configuration);

                return Ok(token);

            }
            else
            {
                return BadRequest(GenericResponse);
            }
        }
    }
}