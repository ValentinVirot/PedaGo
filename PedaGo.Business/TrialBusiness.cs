//-----------------------------------------------------------------------
// <copyright file="TrialBusiness.cs" company="Diiage">
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
    /// Business layer for Trials
    /// </summary>
    public class TrialBusiness : ITrialBusiness
    {
        /// <summary>
        /// Trial repository interface
        /// </summary>
        private ITrialRepository trialRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBusiness" /> class.
        /// </summary>
        /// <param name="trial">Implementation of the Trial Repository</param>
        public TrialBusiness(ITrialRepository trial)
        {
            this.trialRepository = trial;
        }

        /// <summary>
        /// Add trial in context
        /// </summary>
        /// <param name="trial">Trial to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool ITrialBusiness.AddTrial(Trial trial)
        {
            return this.trialRepository.AddTrial(trial);
        }

        /// <summary>
        /// Delete trial in context
        /// </summary>
        /// <param name="trial">Trial to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool ITrialBusiness.DeleteTrial(Trial trial)
        {
            return this.trialRepository.DeleteTrial(trial);
        }

        /// <summary>
        /// Returns all trials in context
        /// </summary>
        /// <returns>All Trials in context</returns>
        IEnumerable<Trial> ITrialBusiness.GetTrials()
        {
            return this.trialRepository.GetTrials();
        }

        /// <summary>
        /// Update trial in context
        /// </summary>
        /// <param name="trial">Trial to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool ITrialBusiness.UpdateTrial(Trial trial)
        {
            return this.trialRepository.UpdateTrial(trial);
        }

        /// <summary>
        /// Returns trial depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted Trial</param>
        /// <returns>Trial corresponding to ID</returns>
        Trial ITrialBusiness.GetTrialById(int id)
        {
            return this.trialRepository.GetTrialById(id);
        }
    }
}
