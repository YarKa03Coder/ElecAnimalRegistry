using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace DataAccess.Security
{
    static class BCryptHashing
    {
        public static string HashPassword(string password)
        {
            return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
        }

        public static bool IsPasswordValid(string password, string hash)
        {
            return BCryptHelper.CheckPassword(password, hash);
        }
    }
}
