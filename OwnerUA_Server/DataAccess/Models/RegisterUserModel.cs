using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Represents data needed for registration.
    /// </summary>
    public class RegisterUserModel : FrontendUserModel
    {
        /// <summary>
        /// User's password.
        /// </summary>
        public string Password { get; set; }
    }
}
