//-----------------------------------------------------------------------
// <copyright file="StepBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business
{
    using System;
    using System.Collections.Generic;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Class to make the treatment and call the repository to use data
    /// </summary>
    public class StepBusiness : IStepBusiness
    {
        /// <summary>
        /// Step Repository interface
        /// </summary>
        private IStepRepository stepRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepBusiness" /> class.
        /// </summary>
        /// <param name="step">Implementation of the Step Repository</param>
        public StepBusiness(IStepRepository step)
        {
            this.stepRepository = step;
        }

        /// <summary>
        /// Method to insert a step
        /// </summary>
        /// <param name="step">Step object to insert</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IStepBusiness.AddStep(Step step)
        {
            step.CreationDate = DateTime.Now;
            return this.stepRepository.AddStep(step);
        }

        /// <summary>
        /// Method to insert multiple steps
        /// </summary>
        /// <param name="steps">List of Step</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IStepBusiness.AddSteps(List<Step> steps)
        {
            return this.stepRepository.AddSteps(steps);
        }

        /// <summary>
        /// Method to delete a step
        /// </summary>
        /// <param name="step">Step object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        bool IStepBusiness.DeleteStep(Step step)
        {
            return this.stepRepository.DeleteStep(step);
        }

        /// <summary>
        /// Method to get a step by its id
        /// </summary>
        /// <param name="id">Id of the step to get</param>
        /// <returns>Return a Step object</returns>
        Step IStepBusiness.GetStepById(int id)
        {
            return this.stepRepository.GetStepById(id);
        }

        /// <summary>
        /// Method to get all the steps
        /// </summary>
        /// <returns>Return a IEnumerable of Step</returns>
        IEnumerable<Step> IStepBusiness.GetSteps()
        {
            return this.stepRepository.GetSteps();
        }

        /// <summary>
        /// Method to update a step
        /// </summary>
        /// <param name="step">Step object to update</param>
        /// <returns>Return a boolean if the update correctly</returns>
        bool IStepBusiness.UpdateStep(Step step)
        {
            return this.stepRepository.UpdateStep(step);
        }

        /// <summary>
        /// Returns current step of a given user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>APICurrentStep object</returns>
        APICurrentStep IStepBusiness.GetCurrentStep(int id)
        {
            return this.stepRepository.GetCurrentStep(id);
        }
    }
}
