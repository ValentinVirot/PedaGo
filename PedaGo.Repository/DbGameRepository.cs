//-----------------------------------------------------------------------
// <copyright file="DbGameRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PedaGo.Entities;
    using PedaGo.EntityContext;
    using PedaGo.Repository.Contracts;
    
    /// <summary>
    /// Class to communicate with the database for the games.
    /// </summary>
    public class DbGameRepository : IGameRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbGameRepository" /> class.
        /// </summary>
        /// <param name="service">Scope factory interface</param>
        public DbGameRepository(IServiceScopeFactory service)
        {
            this.scopeFactory = service;
        }

        /// <summary>
        /// Method to insert a game in the database
        /// </summary>
        /// <param name="game">Game object to insert</param>
        /// <returns>Return a boolean if the suppression happened correctly</returns>
        bool IGameRepository.AddGame(Game game)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Games.Add(game);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete a game in the database
        /// </summary>
        /// <param name="game">Game object to delete</param>
        /// <returns>Return a boolean if the suppression happened correctly</returns>
        bool IGameRepository.DeleteGame(Game game)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to get a game by its id 
        /// </summary>
        /// <param name="id">Id of game to get</param>
        /// <returns>Return a Game object corresponding to the id if success or null if something happened</returns>
        Game IGameRepository.GetGamebyId(int id)
        {
            try
            {
                Game game = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Games.Where(g => g.Id == id).Include(g=>g.Route).FirstOrDefault();
                return game;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Method to get all the games 
        /// </summary>
        /// <returns>Return a IEnumerable of Game corresponding to the id if success or null if something happened</returns>
        IEnumerable<Game> IGameRepository.GetGames()
        {
            try
            {
                IEnumerable<Game> games = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Games.Include(g => g.Transport).Include(g => g.Route).Include(g => g.Plays);
                return games;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
