//-----------------------------------------------------------------------
// <copyright file="IMissionRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Contracts
{
    using System.Collections.Generic;
    using PedaGo.UserMobileApp.Models;

    /// <summary>
    /// Access to mission data
    /// </summary>
    public interface IMissionRepository
    {
        /// <summary>
        /// Returns all missions in context
        /// </summary>
        /// <returns>IEnumerable missions</returns>
        IEnumerable<Mission> GetAll();
    }
}
