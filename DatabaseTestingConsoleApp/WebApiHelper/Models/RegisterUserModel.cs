using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper.Models
{
    public class RegisterUserModel : FrontendUserModel
    {
        public string Password { get; set; }
    }
}
