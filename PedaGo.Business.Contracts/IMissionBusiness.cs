//-----------------------------------------------------------------------
// <copyright file="IMissionBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Mission business interface
    /// </summary>
    public interface IMissionBusiness
    {
        /// <summary>
        /// Returns mission by ID
        /// </summary>
        /// <param name="id">ID of wanted mission</param>
        /// <returns>Corresponding mission</returns>
        public Mission GetMissionById(int id);

        /// <summary>
        /// Returns all missions in context
        /// </summary>
        /// <returns>All missions in context</returns>
        public IEnumerable<Mission> GetMissions();

        /// <summary>
        /// Add mission in context
        /// </summary>
        /// <param name="mission">Mission to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool AddMission(Mission mission);

        /// <summary>
        /// Delete mission in context
        /// </summary>
        /// <param name="mission">Mission to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool DeleteMission(Mission mission);

        /// <summary>
        /// Update mission in context
        /// </summary>
        /// <param name="mission">Mission to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        public bool UpdateMission(Mission mission);
    }
}
