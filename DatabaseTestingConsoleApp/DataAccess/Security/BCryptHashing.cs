using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace DataAccess.Security
{
    /// <summary>
    /// Stores methods needed to work with hashes 
    /// </summary>
    static class BCryptHashing
    {
        /// <summary>
        /// Generate hash from user's password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
        }

        /// <summary>
        /// Compares user's password and hash in database.
        /// If user's password valid - allow user to log in.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsPasswordValid(string password, string hash)
        {
            return BCryptHelper.CheckPassword(password, hash);
        }
    }
}
