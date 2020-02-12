//-----------------------------------------------------------------------
// <copyright file="APIAuthRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    using Newtonsoft.Json;
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Models;
    using RestSharp;

    /// <summary>
    /// API implementation of the Authentication Repository interface
    /// </summary>
    public class APIAuthRepository : IAuthRepository
    {
        /// <summary>
        /// Allow easy RestAPI calls
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Calls our API to get JWToken
        /// </summary>
        /// <param name="username">Username of the player</param>
        /// <param name="password">Password of the player</param>
        /// <returns>JWToken (string)</returns>
        string IAuthRepository.GetToken(string username, string password)
        {
            try
            {
                string token = null;

                this.client = new RestClient(PedaGoServers.BaseApiUrl);
                this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

                var request = new RestRequest("/auth/getToken", Method.POST);

                request.AddParameter("Username", username);
                request.AddParameter("Password", password);

                var result = this.client.Execute(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    token = JsonConvert.DeserializeObject<APIAuth>(result.Content).Token;
                }
                else
                {
                    return null;
                }

                return token;
            }
            catch
            {
                return null;
            }
        }
    }
}
