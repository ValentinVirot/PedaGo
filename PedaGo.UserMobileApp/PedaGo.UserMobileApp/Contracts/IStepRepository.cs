//-----------------------------------------------------------------------
// <copyright file="IStepRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Contracts
{
    using PedaGo.UserMobileApp.Models;

    /// <summary>
    /// Access to mission data
    /// </summary>
    public interface IStepRepository
    {
        /// <summary>
        /// Returns current step of a given user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>APICurrentStep object</returns>
        APICurrentStep GetCurrentStep(int userId);
    }
}
