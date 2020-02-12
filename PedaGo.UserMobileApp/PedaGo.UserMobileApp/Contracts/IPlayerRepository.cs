//-----------------------------------------------------------------------
// <copyright file="IPlayerRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Contracts
{
    using PedaGo.UserMobileApp.Models;

    /// <summary>
    /// Access to authentication data
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Returns URL of user profile picture
        /// </summary>
        /// <param name="username">Username of the user account</param>
        /// <returns>JWToken (string)</returns>
        string GetUserProfilePicture(string username);

        /// <summary>
        /// Returns user details
        /// </summary>
        /// <param name="username">User name of wanted Player</param>
        /// <param name="password">Password of wanted player</param>
        /// <returns>Corresponding Player</returns>
        Player GetUserDetails(string username, string password);

        /// <summary>
        /// Returns current team of given player
        /// </summary>
        /// <param name="userId">Player ID</param>
        /// <returns>Corresponding team</returns>
        Team GetTeam(int userId);
    }
}
