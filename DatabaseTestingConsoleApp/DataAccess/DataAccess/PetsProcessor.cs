using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

using DataAccess.Models;


namespace DataAccess.DataAccess
{
    /// <summary>
    /// Stores method for working with pet data and database.
    /// </summary>
    public static class PetsProcessor
    {
        /// <summary>
        /// Gets list of user pets who has such email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static List<PetModel> GetUserPetsByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();

            // list of user pets
            List<PetModel> pets = new List<PetModel>();

            SqlCommand getPetsByUserEmail = new SqlCommand("dbo.Pets_GetUserPetsByEmail", connection);
            getPetsByUserEmail.CommandType = System.Data.CommandType.StoredProcedure;
            getPetsByUserEmail.Parameters.AddWithValue("@Email", email);

            // returns list of pets
            SqlDataReader petsDataReader = getPetsByUserEmail.ExecuteReader();

            // generating new instance of PetModel class and adding it to list of pets
            // if there is record to read
            while (petsDataReader.Read())
            {
                pets.Add(new PetModel
                {
                    UniqueID    = (int)petsDataReader[0],
                    BirthDate   = (DateTime)petsDataReader[1],
                    AnimalType  = (string)petsDataReader[2],
                    BreedType   = (string)petsDataReader[3],
                    Gender      = (bool)petsDataReader[4] ? "Male" : "Female",
                    ImagePath   = (string)petsDataReader[5]
                });
            }

            petsDataReader.Close();

            connection.Close();


            return pets;
        }
    }
}
