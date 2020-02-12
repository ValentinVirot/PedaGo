//-----------------------------------------------------------------------
// <copyright file="APIStepRepository.cs" company="Diiage">
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
    public class APIStepRepository : IStepRepository
    {
        /// <summary>
        /// Allow easy RestAPI calls
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Returns current step of a given user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>APICurrentStep object</returns>
        APICurrentStep IStepRepository.GetCurrentStep(int userId)
        {
            try
            {
                this.client = new RestClient(PedaGoServers.BaseApiUrl);
                this.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", CurrentUser.Token));

                var request = new RestRequest("/api/getCurrentStep", Method.GET);

                request.AddParameter("userid", userId);

                var result = this.client.Execute(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<APICurrentStep>(result.Content);
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
