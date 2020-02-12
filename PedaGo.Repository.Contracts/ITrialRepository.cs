//-----------------------------------------------------------------------
// <copyright file="ITrialRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Trial repository interface
    /// </summary>
    public interface ITrialRepository
    {
        /// <summary>
        /// Returns trial by ID
        /// </summary>
        /// <param name="id">ID of wanted trial</param>
        /// <returns>Corresponding trial</returns>
        public Trial GetTrialById(int id);

        /// <summary>
        /// Returns all trials in context
        /// </summary>
        /// <returns>Trials in context</returns>
        public IEnumerable<Trial> GetTrials();

        /// <summary>
        /// Add trial in context
        /// </summary>
        /// <param name="trial">Trial to add</param>
        /// <returns>True if done, false if error</returns>
        public bool AddTrial(Trial trial);

        /// <summary>
        /// Update trial in context
        /// </summary>
        /// <param name="trial">Trial to update</param>
        /// <returns>True if done, false if error</returns>
        public bool UpdateTrial(Trial trial);

        /// <summary>
        /// Delete trial in context
        /// </summary>
        /// <param name="trial">Trial to delete</param>
        /// <returns>True if done, false if error</returns>
        public bool DeleteTrial(Trial trial);
    }
}
