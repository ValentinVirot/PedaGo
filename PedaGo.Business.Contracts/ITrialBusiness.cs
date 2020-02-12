//-----------------------------------------------------------------------
// <copyright file="ITrialBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Trial business interface
    /// </summary>
    public interface ITrialBusiness
    {
        /// <summary>
        /// Returns trial depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted Trial</param>
        /// <returns>Trial corresponding to ID</returns>
        public Trial GetTrialById(int id);

        /// <summary>
        /// Returns all trials in context
        /// </summary>
        /// <returns>All Trials in context</returns>
        public IEnumerable<Trial> GetTrials();

        /// <summary>
        /// Add trial in context
        /// </summary>
        /// <param name="trial">Trial to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool AddTrial(Trial trial);

        /// <summary>
        /// Update trial in context
        /// </summary>
        /// <param name="trial">Trial to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool UpdateTrial(Trial trial);

        /// <summary>
        /// Delete trial in context
        /// </summary>
        /// <param name="trial">Trial to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool DeleteTrial(Trial trial);
    }
}
