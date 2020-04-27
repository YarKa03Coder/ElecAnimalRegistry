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
    /// <summary>
    /// Requests that manipulate users data.
    /// </summary>
    public class UsersController : ApiController
    {
        /// <summary>
        /// Writes new user data into database.
        /// </summary>
        /// <param name="user">User data needed to register him.</param>
        /// <returns>Boolean value if operation is successful.</returns>
        [Route("api/users/RegisterUser/")]
        [HttpPost]
        public bool RegisterUser(RegisterUserModel user)
        {
            return UserProcessor.RegisterUser(user);
        }


        /// <summary>
        /// Checks if there is user with such email.
        /// </summary>
        /// <param name="email">User's email to find out if exists such user in database.</param>
        /// <returns>Boolean value if operation is successful.</returns>
        [Route("api/users/UserExists/{email}")]
        [HttpGet]
        public bool UserExists(string email)
        {
            return UserProcessor.UserExists(email);
        }


        /// <summary>
        /// If user owns some pet, we can get information about user by pet id.
        /// </summary>
        /// <param name="uniquePetID">Identificator of each pet in Ukraine.</param>
        /// <returns>Returns user data to be displayed on screen.</returns>
        [Route("api/users/GetUserByPetID/{uniquePetID}")]
        [HttpGet]
        public FrontendUserModel GetUserByPetID(int uniquePetID)
        {
            return UserProcessor.GetUserByPetID(uniquePetID);
        }

        /// <summary>
        /// Gets user personal information if email and password are entered correctly.
        /// </summary>
        /// <param name="email">User's email he enters to log in successfully.</param>
        /// <param name="password">User's password he enters to log in successfully.</param>
        /// <returns>Returns user data to be displayed on screen.</returns>
        [Route("api/users/LogUserIn/{email}/{password}")]
        [HttpGet]
        public FrontendUserModel LogUserIn(string email, string password)
        {
            return UserProcessor.GetUserByLoginInfo(email, password);
        }

    }
}
