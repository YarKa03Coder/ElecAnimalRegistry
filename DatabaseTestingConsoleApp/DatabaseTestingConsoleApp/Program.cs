using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DataAccess.Security;
//using DataAccess.DataAccess;
//using DataAccess.Models;


using WebApiHelper.Models;
using WebApiHelper.HandlingRequests;

namespace DatabaseTestingConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Test hashing
            //string password = "fb802wq6mt";
            //string hash = BCryptHashing.HashPassword(password);

            //Console.WriteLine(hash);
            //Console.WriteLine(BCryptHashing.IsPasswordValid("fb802ywq6mt", hash));
            #endregion

            #region Test user's operation 

            //Console.WriteLine(UserProcessor.UserExists("lala@gmail.com"));

            #endregion

            // Console.WriteLine(UserProcessor.GetUserByLoginInfo("artem.viznuk@gmail.com", "fb802wq6mt").LastName);

            //Console.WriteLine(UserProcessor.GetUserByPetID(4) == null);

            #region Test register user

            //RegisterUserModel me = new RegisterUserModel();
            //me.FirstName = "Grigorii";
            //me.LastName = "Dyachenko";
            //me.Phone = "0957342169";
            //me.Email = "grigorii.dyachenkp@gmail.com";
            //me.Password = "fb802wq6mt";

            //Console.WriteLine(UserProcessor.RegisterUser(me));

            #endregion

            //foreach (PetModel petModel in PetsProcessor.GetUserPetsByEmail("grigorii.dychenko@gmail.com"))
            //{
            //    Console.WriteLine($"PetID:{petModel.UniqueID}, Age:{DateTime.Now.Subtract(petModel.BirthDate).Days} days, AnimalType:{petModel.AnimalType}, BreedType:{petModel.BreedType}");
            //}

            //PetModel pet = new PetModel();
            //pet.BirthDate = new DateTime(2020, 2, 13);

            //Console.WriteLine(pet.AgeInStringFormat);

            //Console.WriteLine(WebApiHelper.HandlingRequests.WebApiHelper.GetBaseAddress());

            List<PetModel> pets = await WebApiHelper.HandlingRequests.WebApiHelper.GetUserPetsByEmailAsync("artem.viznuk@gmail.com");
            foreach (var pet in pets)
            {
                Console.WriteLine($"UniqueID:{pet.UniqueID}, BirthDate:{pet.BirthDate}, Age:{pet.AgeInStringFormat}, AnimalType:{pet.AnimalType}, BreedType:{pet.BreedType}, Gender:{pet.Gender}, ImageUrl:{pet.ImagePath}");
            }

            //FrontendUserModel user = await WebApiHelper.HandlingRequests.WebApiHelper.GetUserByPetIDAsync(4);
            //Console.WriteLine(user.Email);

            //bool user = await WebApiHelper.HandlingRequests.WebApiHelper.UserExistsAsync("grigorii.dyachenko@gmail.com");
            //Console.WriteLine(user);

            //FrontendUserModel user = await WebApiHelper.HandlingRequests.WebApiHelper.LogUserInAsync("grigorii.dyachenko@gmail.com", "fb802wq6mt");
            //Console.WriteLine(user.Phone);

            //RegisterUserModel user = new RegisterUserModel
            //{
            //    FirstName = "Bob",
            //    LastName = "Tabor",
            //    Phone = "0953621478",
            //    Email = "bob.tabor@gmail.com",
            //    Password = "bob2001"
            //};
            //bool registrationSuccessful = await WebApiHelper.HandlingRequests.WebApiHelper.RegisterUserAsync(user);
            //Console.WriteLine(registrationSuccessful);

            Console.ReadLine();
        }
    }
}
