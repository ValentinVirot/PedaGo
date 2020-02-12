//-----------------------------------------------------------------------
// <copyright file="CurrentUser.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    using PedaGo.UserMobileApp.Models;

    /// <summary>
    /// Static class, contains current user data.
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public static string Token { get; set; }

        /// <summary>
        /// Gets or sets Player
        /// </summary>
        public static Player Player { get; set; }

        /// <summary>
        /// Gets or sets current step (from the API)
        /// </summary>
        public static APICurrentStep CurrentStep { get; set; }
    }
}
