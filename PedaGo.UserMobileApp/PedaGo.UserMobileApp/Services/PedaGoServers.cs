//-----------------------------------------------------------------------
// <copyright file="PedaGoServers.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    /// <summary>
    /// Contains our servers URL, shared in all app
    /// </summary>
    public static class PedaGoServers
    {
        /// <summary>
        /// Base API URL
        /// </summary>
        private static string baseApiUrl = "http://192.168.1.48:55429";

        /// <summary>
        /// Default profile picture
        /// </summary>
        private static string defaultProfilePic = "https://www.acep.org/static/globalassets/resources/images/edda_images/genericM250.jpg";

        /// <summary>
        /// Gets or sets Base API URL
        /// </summary>
        public static string BaseApiUrl { get => baseApiUrl; set => baseApiUrl = value; }

        /// <summary>
        /// Gets or sets Default profile Picture
        /// </summary>
        public static string DefaultProfilePic { get => defaultProfilePic; set => defaultProfilePic = value; }
    }
}
