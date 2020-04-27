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
    public static class PetsProcessor
    {
        public static List<PetModel> GetUserPetsByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(DataConnections.OwnerUAconnectionString);

            connection.Open();


            List<PetModel> pets = new List<PetModel>();

            SqlCommand getPetsByUserEmail = new SqlCommand("dbo.Pets_GetUserPetsByEmail", connection);
            getPetsByUserEmail.CommandType = System.Data.CommandType.StoredProcedure;
            getPetsByUserEmail.Parameters.AddWithValue("@Email", email);

            SqlDataReader petsDataReader = getPetsByUserEmail.ExecuteReader();

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
