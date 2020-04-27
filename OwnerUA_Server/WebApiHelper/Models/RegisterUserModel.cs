using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper.Models
{
    /// <summary>
    /// Represents data needed for user registration.
    /// </summary>
    public class RegisterUserModel : FrontendUserModel
    {
        /// <summary>
        /// User's password needed for successful registration or authentication.
        /// </summary>
        public string Password { get; set; }
    }
}
