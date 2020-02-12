//-----------------------------------------------------------------------
// <copyright file="APIClient.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    /// <summary>
    /// Client object, used when getting Token from the Authentication route (API)
    /// </summary>
    public class APIClient
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
    }
}
