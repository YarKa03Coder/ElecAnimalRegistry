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
    public static class UserProcessor
    {
        public static bool RegisterUser(RegisterUserModel user)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            SqlCommand registerUserCommand = new SqlCommand("dbo.Users_RegisterUser", connection);
            registerUserCommand.CommandType = System.Data.CommandType.StoredProcedure;
            registerUserCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            registerUserCommand.Parameters.AddWithValue("@LastName",  user.LastName);
            registerUserCommand.Parameters.AddWithValue("@Phone",     user.Phone);
            registerUserCommand.Parameters.AddWithValue("@Email",     user.Email);
            registerUserCommand.Parameters.AddWithValue("@Hash",      BCryptHashing.HashPassword(user.Password));

            int rowsAffected = registerUserCommand.ExecuteNonQuery();


            connection.Close();


            return rowsAffected > 0;
        }

        public static bool UserExists(string email)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            SqlCommand getUserByEmailCommand = new SqlCommand("dbo.Users_GetUserByEmail", connection);
            getUserByEmailCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByEmailCommand.Parameters.AddWithValue("@Email", email);

            bool userExists = getUserByEmailCommand.ExecuteReader().HasRows;


            connection.Close();


            return userExists;
        }

        public static FrontendUserModel GetUserByLoginInfo(string email, string password)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            FrontendUserModel user = null;

            SqlCommand getUserByLoginInfoCommand = new SqlCommand("dbo.Users_GetUserByEmail", connection);
            getUserByLoginInfoCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByLoginInfoCommand.Parameters.AddWithValue("@Email", email);

            SqlDataReader userDataReader = getUserByLoginInfoCommand.ExecuteReader();

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

        public static FrontendUserModel GetUserByPetID(int petUniqueID)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            FrontendUserModel user = null;

            SqlCommand getUserByPetIdCommand = new SqlCommand("dbo.Users_GetUserByPetID", connection);
            getUserByPetIdCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getUserByPetIdCommand.Parameters.AddWithValue("@PetUniqueID", petUniqueID);

            SqlDataReader userDataReader = getUserByPetIdCommand.ExecuteReader();

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
