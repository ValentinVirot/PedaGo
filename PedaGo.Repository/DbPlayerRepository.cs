//-----------------------------------------------------------------------
// <copyright file="DbPlayerRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PedaGo.Entities;
    using PedaGo.EntityContext;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// This class allow to communicate with the database
    /// </summary>
    public class DbPlayerRepository : IPlayerRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbPlayerRepository" /> class.
        /// </summary>
        /// <param name="scopeSrc">Scope factory interface</param>
        public DbPlayerRepository(IServiceScopeFactory scopeSrc)
        {
            this.scopeFactory = scopeSrc;
        }

        /// <summary>
        /// Return player depending on credentials
        /// </summary>
        /// <param name="username">User name of the player</param>
        /// <param name="password">Password of the player</param>
        /// <returns>Corresponding player</returns>
        Player IPlayerRepository.FindByCredentials(string username, string password)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players.Where(m => m.Login == username && m.Password == password).FirstOrDefault();
        }

        /// <summary>
        /// Add player in context
        /// </summary>
        /// <param name="player">Player to add</param>
        /// <returns>True if done, false if error</returns>
        public bool AddPlayer(Player player)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete player in context
        /// </summary>
        /// <param name="player">Player to delete</param>
        /// <returns>True if done, false if error</returns>
        public bool DeletePlayer(Player player)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Players.Remove(player);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns player by ID
        /// </summary>
        /// <param name="id">ID of wanted player</param>
        /// <returns>Corresponding player</returns>
        public Player GetPlayerById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Returns all player in context
        /// </summary>
        /// <returns>Players in context</returns>
        public IEnumerable<Player> GetPlayers()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players;
        }

        /// <summary>
        /// Get all players created by organizer id
        /// </summary>
        /// <param name="organizerId">Organizer ID</param>
        /// <returns>All players</returns>
        IEnumerable<Player> IPlayerRepository.GetPlayers(int organizerId)
        {
            var players = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players.Where(p => p.OrganizerId == organizerId);

            players.ToList().ForEach(p => p.Password = null);

            return players;
        }

        /// <summary>
        /// Update player in context
        /// </summary>
        /// <param name="player">Player to update</param>
        /// <returns>True if done, false if error</returns>
        public bool UpdatePlayer(Player player)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Players.Update(player);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns player depending on the username
        /// </summary>
        /// <param name="username">Username of wanted player</param>
        /// <returns>Player corresponding to ID</returns>
        Player IPlayerRepository.GetPlayerByUsername(string username)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players.FirstOrDefault(p => p.Login == username);
        }

        /// <summary>
        /// Returns user details
        /// </summary>
        /// <param name="username">User name of wanted Player</param>
        /// <param name="password">Password of wanted player</param>
        /// <returns>Corresponding Player</returns>
        Player IPlayerRepository.GetUserDetails(string username, string password)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Players.FirstOrDefault(p => p.Login == username && p.Password == password);
        }

        /// <summary>
        /// Returns current team of given player
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <returns>Corresponding team</returns>
        Team IPlayerRepository.GetTeam(int id)
        {
            using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
            {
                var currentPlayer = context.Players.FirstOrDefault(x => x.Id == id);

                if (currentPlayer != null)
                {
                    var currentTeam = context.Teams.Include(t => t.Teamplayers).ThenInclude(t => t.Player).FirstOrDefault(t => t.OrganizerId == currentPlayer.OrganizerId && t.Teamplayers.Any(x => x.PlayerId == currentPlayer.Id));

                    if (currentTeam != null)
                    {
                        currentTeam.Teamplayers.ToList().ForEach(p => p.Player.Password = null);

                        return currentTeam;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Edits a player in context
        /// </summary>
        /// <param name="player">Player to edit</param>
        /// <returns>True is success, false if something happen</returns>
        public bool EditPlayer(Player player)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    var oldPlayer = context.Players.Where(x => x.Id == player.Id).FirstOrDefault();

                    if (oldPlayer != null)
                    {
                        oldPlayer.FirstName = player.FirstName;
                        oldPlayer.LastName = player.LastName;
                        oldPlayer.Email = player.Email;
                        oldPlayer.Login = player.Login;

                        if (player.Password != null && player.Password != string.Empty)
                        {
                            oldPlayer.Password = player.Password;
                        }

                        oldPlayer.Picture = player.Picture;

                        context.Players.Update(oldPlayer);
                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
