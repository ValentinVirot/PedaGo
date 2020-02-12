//-----------------------------------------------------------------------
// <copyright file="APIMissionRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Models;
    using RestSharp;

    /// <summary>
    /// API implementation of the Authentication Repository interface
    /// </summary>
    public class APIMissionRepository : IMissionRepository
    {
        /// <summary>
        /// Allow easy RestAPI calls
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Returns all Mission stored in context
        /// </summary>
        /// <returns>All Missions</returns>
        IEnumerable<Mission> IMissionRepository.GetAll()
        {
            try
            {
                this.client = new RestClient(PedaGoServers.BaseApiUrl);
                this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

                var request = new RestRequest("/api/getMissions", Method.GET);

                var result = this.client.Execute(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Mission>>(JToken.Parse(result.Content).ToString());
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
