using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Represents data needed for displaying user information.
    /// </summary>
    public class FrontendUserModel
    {
        /// <summary>
        /// User's firstname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's lastname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User's email.
        /// </summary>
        public string Email { get; set; }
    }
}
