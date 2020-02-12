//-----------------------------------------------------------------------
// <copyright file="IGameRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Interface of game repository
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Method to insert a game
        /// </summary>
        /// <param name="game">Game object to insert</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool AddGame(Game game);

        /// <summary>
        /// Method to delete a game
        /// </summary>
        /// <param name="game">Game object to delete</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool DeleteGame(Game game);

        /// <summary>
        /// Method to get a game by its id 
        /// </summary>
        /// <param name="id">Id of game to get</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public Game GetGamebyId(int id);

        /// <summary>
        /// Method to get all the games 
        /// </summary>
        /// <returns>Return IEnumerable of Game</returns>
        public IEnumerable<Game> GetGames();
    }
}
