using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using WebApiHelper.Models;

namespace WebApiHelper.HandlingRequests
{
    /// <summary>
    /// Stores methods for sending requests to server.
    /// </summary>
    public static class WebApiHelper
    {
        private const string IP = "192.168.1.100";
        private const int PORT  = 8080;

        private static HttpClient client = new HttpClient();


        /// <summary>
        /// Address of http server.
        /// </summary>
        public static string BaseAddress { get => $"http://{IP}:{PORT}"; }


        /// <summary>
        /// Request that registers new user in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<bool> RegisterUserAsync(RegisterUserModel user)
        {
            bool registrationSuccessful = false;

            HttpRequestMessage request = new HttpRequestMessage();

            request.RequestUri = new Uri($"{BaseAddress}/api/users/RegisterUser/");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();

                registrationSuccessful = (json == "true");
            }

            return registrationSuccessful;
        }

        /// <summary>
        /// Request provides user personal information 
        /// if he enters email and password correctly.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<FrontendUserModel> LogUserInAsync(string email, string password)
        {
            FrontendUserModel user = null;

            HttpRequestMessage request = new HttpRequestMessage();

            request.RequestUri = new Uri($"{BaseAddress}/api/users/LogUserIn/{email}/{password}/");
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<FrontendUserModel>(json);
            }

            return user;
        }

        /// <summary>
        /// Request provides user personal information
        /// if one of his pet ids is entered correctly.
        /// </summary>
        /// <param name="uniquePetID"></param>
        /// <returns></returns>
        public static async Task<FrontendUserModel> GetUserByPetIDAsync(int uniquePetID)
        {
            FrontendUserModel user = null;

            HttpRequestMessage request = new HttpRequestMessage();

            request.RequestUri = new Uri($"{BaseAddress}/api/users/GetUserByPetID/{uniquePetID}/");
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<FrontendUserModel>(json);
            }

            return user;
        }

        /// <summary>
        /// Request that returns list of user pets
        /// if his email is entered correctly.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task<List<PetModel>> GetUserPetsByEmailAsync(string email)
        {
            List<PetModel> pets = new List<PetModel>();

            HttpRequestMessage request = new HttpRequestMessage();
        
            request.RequestUri = new Uri($"{BaseAddress}/api/pets/GetUserPetsByEmail/{email}/");
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();

                foreach (var pet in JArray.Parse(json))
                {
                    pets.Add(JsonConvert.DeserializeObject<PetModel>(pet.ToString()));
                }               
            }

            return pets;
        }

        /// <summary>
        /// Request checks if there is user with such email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task<bool> UserExistsAsync(string email)
        {
            bool userFound = false;

            HttpRequestMessage request = new HttpRequestMessage();

            request.RequestUri = new Uri($"{BaseAddress}/api/users/UserExists/{email}/");
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();

                userFound = (json == "true");
            }

            return userFound;
        }

    }
}
