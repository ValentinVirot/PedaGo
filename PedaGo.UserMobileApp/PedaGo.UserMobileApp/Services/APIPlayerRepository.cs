//-----------------------------------------------------------------------
// <copyright file="APIPlayerRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Models;
    using RestSharp;

    /// <summary>
    /// API implementation of the Authentication Repository interface
    /// </summary>
    public class APIPlayerRepository : IPlayerRepository
    {
        /// <summary>
        /// Allow easy RestAPI calls
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Returns user details
        /// </summary>
        /// <param name="username">User name of wanted Player</param>
        /// <param name="password">Password of wanted player</param>
        /// <returns>Corresponding Player</returns>
        Player IPlayerRepository.GetUserDetails(string username, string password)
        {
            this.client = new RestClient(PedaGoServers.BaseApiUrl);
            this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

            var request = new RestRequest("/api/getUserDetails", Method.POST);

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            var result = this.client.Execute(request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Player>(result.Content);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns URL of user profile picture
        /// </summary>
        /// <param name="username">Username of the user account</param>
        /// <returns>JWToken (string)</returns>
        string IPlayerRepository.GetUserProfilePicture(string username)
        {
            try
            {
                this.client = new RestClient(PedaGoServers.BaseApiUrl);
                this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

                string pp = null;

                var request = new RestRequest("/api/getUserPp", Method.GET);

                request.AddParameter("username", username);

                var result = this.client.Execute(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    pp = JsonConvert.DeserializeAnonymousType(result.Content, new { profilePicture = string.Empty }).profilePicture;
                }
                else
                {
                    return null;
                }

                return pp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns current team of given player
        /// </summary>
        /// <param name="userId">Player ID</param>
        /// <returns>Corresponding team</returns>
        Team IPlayerRepository.GetTeam(int userId)
        {
            try
            {
                this.client = new RestClient(PedaGoServers.BaseApiUrl);
                this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

                Team team = null;

                var request = new RestRequest("/api/getTeam", Method.GET);

                request.AddParameter("userid", userId);

                var result = this.client.Execute(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    team = JsonConvert.DeserializeObject<Team>(JToken.Parse(result.Content).ToString());
                }
                else
                {
                    return null;
                }

                return team;
            }
            catch
            {
                return null;
            }
        }
    }
}
