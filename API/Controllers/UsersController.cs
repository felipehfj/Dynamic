using Business.Core;
using Domain.Models;
using Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        
        private ILogger<UsersController> Logger { get; }
        private IUserBusiness UserBusiness { get; }
        private IGenericResponse GenericResponse { get; set; }


        public UsersController(ILogger<UsersController> logger
            , IUserBusiness userBusiness
            , IGenericResponse response)
        {
            Logger = logger;
            UserBusiness = userBusiness;
            GenericResponse = response;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            GenericResponse = UserBusiness.SelectAll();

            if (GenericResponse.Success)
                return Ok(GenericResponse.Data);
            return BadRequest(GenericResponse);
        }

        [HttpPost]
        public ActionResult<UserModel> Post(UserAddModel model)
        {
            if (ModelState.IsValid)
            {
                var r = UserBusiness.Insert(model);
                if (r.Success)
                {
                    return Ok(r.Data);
                }
                else
                {
                    return BadRequest(r);
                }
            }
            else
            {
                GenericResponse.Data = ModelState;
                GenericResponse.ErrorMessage = ModelState.Values.ToString();
                GenericResponse.Success = false;                
                return BadRequest(GenericResponse);
            }

        }
    }
}
