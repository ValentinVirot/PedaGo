//-----------------------------------------------------------------------
// <copyright file="IStepBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Step Business interface
    /// </summary>
    public interface IStepBusiness
    {
        /// <summary>
        /// Method to get a Step by its id
        /// </summary>
        /// <param name="id">Id of the Step</param>
        /// <returns>Return a Step Object</returns>
        public Step GetStepById(int id);

        /// <summary>
        /// Method to get all the steps
        /// </summary>
        /// <returns>return a IEnumerable of Steps</returns>
        public IEnumerable<Step> GetSteps();

        /// <summary>
        /// Method to add a step
        /// </summary>
        /// <param name="step">Step object to add</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool AddStep(Step step);

        /// <summary>
        /// Method to add multiple steps
        /// </summary>
        /// <param name="steps">List of Step</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool AddSteps(List<Step> steps);

        /// <summary>
        /// Method to delete a step
        /// </summary>
        /// <param name="step">Step object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        public bool DeleteStep(Step step);

        /// <summary>
        /// Method to update a step
        /// </summary>
        /// <param name="step">Step object to update</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        public bool UpdateStep(Step step);

        /// <summary>
        /// Returns current step of a given user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>APICurrentStep object</returns>
        public APICurrentStep GetCurrentStep(int id);
    }
}
