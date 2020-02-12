//-----------------------------------------------------------------------
// <copyright file="PlayerBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business
{
    using System.Collections.Generic;
    using System.Linq;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// This class allows to do the treatment of the data and call the repository to work with them
    /// </summary>
    public class PlayerBusiness : IPlayerBusiness
    {
        /// <summary>
        /// Player repository interface
        /// </summary>
        private IPlayerRepository playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBusiness" /> class.
        /// </summary>
        /// <param name="playerRepo">Implementation of the repository</param>
        public PlayerBusiness(IPlayerRepository playerRepo)
        {
            this.playerRepository = playerRepo;
        }

        /// <summary>
        /// Add player in context
        /// </summary>
        /// <param name="player">Player to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IPlayerBusiness.AddPlayer(Player player)
        {
            return this.playerRepository.AddPlayer(player);
        }

        /// <summary>
        /// Delete player in context
        /// </summary>
        /// <param name="player">Player to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IPlayerBusiness.DeletePlayer(Player player)
        {
            return this.playerRepository.DeletePlayer(player);
        }

        /// <summary>
        /// Returns player depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted player</param>
        /// <returns>Player corresponding to ID</returns>
        Player IPlayerBusiness.GetPlayerById(int id)
        {
            return this.playerRepository.GetPlayerById(id);
        }

        /// <summary>
        /// Returns all players in context
        /// </summary>
        /// <returns>All players in context</returns>
        IEnumerable<Player> IPlayerBusiness.GetPlayers()
        {
            return this.playerRepository.GetPlayers();
        }

        /// <summary>
        /// Get all players created by organizer id
        /// </summary>
        /// <param name="organizerId">Organizer ID</param>
        /// <returns>All players</returns>
        IEnumerable<Player> IPlayerBusiness.GetPlayers(int organizerId)
        {
            return this.playerRepository.GetPlayers(organizerId);
        }

        /// <summary>
        /// Update player in context
        /// </summary>
        /// <param name="player">Player to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IPlayerBusiness.UpdatePlayer(Player player)
        {
            return this.playerRepository.UpdatePlayer(player);
        }

        /// <summary>
        /// Returns player depending on the username
        /// </summary>
        /// <param name="username">Username of wanted player</param>
        /// <returns>Profile Picture URL</returns>
        string IPlayerBusiness.GetUserProfilePicture(string username)
        {
            var player = this.playerRepository.GetPlayerByUsername(username);

            if (player == null)
            {
                return string.Empty;
            }
            else
            {
                return player.Picture;
            }
        }

        /// <summary>
        /// Returns user details
        /// </summary>
        /// <param name="username">User name of wanted Player</param>
        /// <param name="password">Password of wanted player</param>
        /// <returns>Corresponding Player</returns>
        public Player GetUserDetails(string username, string password)
        {
            var player = this.playerRepository.GetUserDetails(username, password);

            if (player != null)
            {
                player.Password = null;
                return player;
            }
            else
            {
                return player;
            }
        }

        /// <summary>
        /// Returns current team of given player
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <returns>Corresponding team</returns>
        public Team GetTeam(int id)
        {
            return this.playerRepository.GetTeam(id);
        }

        /// <summary>
        /// Edits a player in context
        /// </summary>
        /// <param name="player">Player to edit</param>
        /// <returns>True is success, false if something happen</returns>
        bool IPlayerBusiness.EditPlayer(Player player)
        {
            return this.playerRepository.EditPlayer(player);
        }
    }
}
