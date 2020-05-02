using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
    

using DataAccess.Models;
using DataAccess.Security;

namespace DataAccess.DataAccess
{
    /// <summary>
    /// Stores methods for working with user data and database. 
    /// </summary>
    public static class UserProcessor
    {
        /// <summary>
        /// Writes user's data into database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool RegisterUser(RegisterUserModel user)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();

            // giving all user data needed for registration
            SqlCommand registerUserCommand = new SqlCommand("dbo.Users_RegisterUser", connection);
            registerUserCommand.CommandType = System.Data.CommandType.StoredProcedure;
            registerUserCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            registerUserCommand.Parameters.AddWithValue("@LastName",  user.LastName);
            registerUserCommand.Parameters.AddWithValue("@Phone",     user.Phone);
            registerUserCommand.Parameters.AddWithValue("@Email",     user.Email);
            registerUserCommand.Parameters.AddWithValue("@Hash",      BCryptHashing.HashPassword(user.Password));

            // executing stored procedure, saving number of rows it affected
            int rowsAffected = registerUserCommand.ExecuteNonQuery();


            connection.Close();


            // operation was successful if data was written into database 
            return rowsAffected > 0;
        }


        /// <summary>
        /// Checks if there is user with such email in database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool UserExists(string email)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            SqlCommand getUserByEmailCommand = new SqlCommand("dbo.Users_GetUserByEmail", connection);
            getUserByEmailCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByEmailCommand.Parameters.AddWithValue("@Email", email);

            // checks to know if there is user with such email
            bool userExists = getUserByEmailCommand.ExecuteReader().HasRows;


            connection.Close();


            return userExists;
        }

        /// <summary>
        /// Gets user personal data if he entered email and password correctly.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static FrontendUserModel GetUserByLoginInfo(string email, string password)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();

            // user data to return
            FrontendUserModel user = null;


            SqlCommand getUserByLoginInfoCommand = new SqlCommand("dbo.Users_GetUserByEmail", connection);
            getUserByLoginInfoCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByLoginInfoCommand.Parameters.AddWithValue("@Email", email);

       
            SqlDataReader userDataReader = getUserByLoginInfoCommand.ExecuteReader();

            // if there is user with such email and his password correct then creating new user entity
            while (userDataReader.Read() && BCryptHashing.IsPasswordValid(password, (string)userDataReader[5]))
            {
                user = new FrontendUserModel
                {
                    FirstName = (string)userDataReader[1],
                    LastName = (string)userDataReader[2],
                    Phone = (string)userDataReader[3],
                    Email = (string)userDataReader[4]
                };               
            }

            userDataReader.Close();

            connection.Close();


            return user;
        }

        /// <summary>
        /// Gets user info by his own pet id.
        /// </summary>
        /// <param name="petUniqueID"></param>
        /// <returns></returns>
        public static FrontendUserModel GetUserByPetID(int petUniqueID)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            // user data to return 
            FrontendUserModel user = null;

            SqlCommand getUserByPetIdCommand = new SqlCommand("dbo.Users_GetUserByPetID", connection);
            getUserByPetIdCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByPetIdCommand.Parameters.AddWithValue("@PetUniqueID", petUniqueID);

            SqlDataReader userDataReader = getUserByPetIdCommand.ExecuteReader();

            // if there is user that have pet with such pet id then create new user entity
            while (userDataReader.Read())
            {
                user = new FrontendUserModel
                {
                    FirstName = (string)userDataReader[0],
                    LastName = (string)userDataReader[1],
                    Phone = (string)userDataReader[2],
                    Email = (string)userDataReader[3]
                };                
            }

            userDataReader.Close();

            connection.Close();


            return user;
        }
    }
}
