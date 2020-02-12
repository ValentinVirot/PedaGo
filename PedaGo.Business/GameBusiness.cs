//-----------------------------------------------------------------------
// <copyright file="GameBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business
{
    using System.Collections.Generic;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;
    
    /// <summary>
    /// Class to make the treatment from the games
    /// </summary>
    public class GameBusiness : IGameBusiness
    {
        /// <summary>
        /// Game repository interface
        /// </summary>
        private IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBusiness"/> class.
        /// </summary>
        /// <param name="game">Implementation of the game repository</param>
        public GameBusiness(IGameRepository game)
        {
            this.gameRepository = game;
        }

        /// <summary>
        /// Method to insert a game
        /// </summary>
        /// <param name="game">Game object to insert</param>
        /// <returns>Return a boolean if the insertion happened correctly</returns>
        bool IGameBusiness.AddGame(Game game)
        {
            return this.gameRepository.AddGame(game);
        }

        /// <summary>
        /// Method to delete a game
        /// </summary>
        /// <param name="game">Game object to delete</param>
        /// <returns>Return a boolean if the insertion happened correctly</returns>
        bool IGameBusiness.DeleteGame(Game game)
        {
            return this.gameRepository.DeleteGame(game);
        }

        /// <summary>
        /// Method to get a game by its id
        /// </summary>
        /// <param name="id">Id of game to get</param>
        /// <returns>Return game object corresponding to the id</returns>
        Game IGameBusiness.GetGamebyId(int id)
        {
            return this.gameRepository.GetGamebyId(id);
        }

        /// <summary>
        /// Method to get all the games
        /// </summary>
        /// <returns>Return IEnumerable of Game</returns>
        IEnumerable<Game> IGameBusiness.GetGames()
        {
            return this.gameRepository.GetGames();
        }
    }
}
