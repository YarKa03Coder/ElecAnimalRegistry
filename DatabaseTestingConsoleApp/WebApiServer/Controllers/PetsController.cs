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
    /// Requests that manipulate pets data.
    /// </summary>
    public class PetsController : ApiController
    {
        /// <summary>
        /// Gets list of user pets by his email.
        /// </summary>
        /// <param name="email">User's email to be searched in database.</param>
        /// <returns>Returns list of user pets.</returns>
        [Route("api/pets/GetUserPetsByEmail/{email}")]
        [HttpGet]
        public List<PetModel> GetUserPetsByEmail(string email)
        {
            return PetsProcessor.GetUserPetsByEmail(email);
        }
    }
}
