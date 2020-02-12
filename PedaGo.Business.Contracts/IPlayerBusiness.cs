//-----------------------------------------------------------------------
// <copyright file="IPlayerBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Player business interface
    /// </summary>
    public interface IPlayerBusiness
    {
        /// <summary>
        /// Returns player depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted player</param>
        /// <returns>Player corresponding to ID</returns>
        public Player GetPlayerById(int id);

        /// <summary>
        /// Returns all players in context
        /// </summary>
        /// <returns>All players in context</returns>
        public IEnumerable<Player> GetPlayers();

        /// <summary>
        /// Get all players created by organizer id
        /// </summary>
        /// <param name="organizerId">Organizer ID</param>
        /// <returns>All players</returns>
        public IEnumerable<Player> GetPlayers(int organizerId);

        /// <summary>
        /// Add player in context
        /// </summary>
        /// <param name="player">Player to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool AddPlayer(Player player);

        /// <summary>
        /// Delete player in context
        /// </summary>
        /// <param name="player">Player to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool DeletePlayer(Player player);

        /// <summary>
        /// Update player in context
        /// </summary>
        /// <param name="player">Player to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool UpdatePlayer(Player player);

        /// <summary>
        /// Returns player depending on the username
        /// </summary>
        /// <param name="username">Username of wanted player</param>
        /// <returns>Profile Picture URL</returns>
        public string GetUserProfilePicture(string username);

        /// <summary>
        /// Returns user details
        /// </summary>
        /// <param name="username">User name of wanted Player</param>
        /// <param name="password">Password of wanted player</param>
        /// <returns>Corresponding Player</returns>
        public Player GetUserDetails(string username, string password);

        /// <summary>
        /// Returns current team of given player
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <returns>Corresponding team</returns>
        public Team GetTeam(int id);

        /// <summary>
        /// Edits a player in context
        /// </summary>
        /// <param name="player">Player to edit</param>
        /// <returns>True is success, false if something happen</returns>
        public bool EditPlayer(Player player);
    }
}
