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
    public class PetsController : ApiController
    {
        [Route("api/pets/GetUserPetsByEmail/{email}")]
        [HttpGet]
        public List<PetModel> GetUserPetsByEmail(string email)
        {
            return PetsProcessor.GetUserPetsByEmail(email);
        }
    }
}
