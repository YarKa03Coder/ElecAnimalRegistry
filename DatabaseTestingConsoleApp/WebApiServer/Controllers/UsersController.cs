using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DataAccess.Models;
using DataAccess.DataAccess;


namespace WebApiServer.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/RegisterUser/")]
        [HttpPost]
        public bool RegisterUser(RegisterUserModel user)
        {
            return UserProcessor.RegisterUser(user);
        }


        [Route("api/users/UserExists/{email}")]
        [HttpGet]
        public bool UserExists(string email)
        {
            return UserProcessor.UserExists(email);
        }


        [Route("api/users/GetUserByPetID/{uniquePetID}")]
        [HttpGet]
        public FrontendUserModel GetUserByPetID(int uniquePetID)
        {
            return UserProcessor.GetUserByPetID(uniquePetID);
        }

        [Route("api/users/LogUserIn/{email}/{password}")]
        [HttpGet]
        public FrontendUserModel LogUserIn(string email, string password)
        {
            return UserProcessor.GetUserByLoginInfo(email, password);
        }

    }
}
