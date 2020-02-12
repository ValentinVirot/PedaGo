//-----------------------------------------------------------------------
// <copyright file="IMissionRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Mission repository interface
    /// </summary>
    public interface IMissionRepository
    {
        /// <summary>
        /// Return mission depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted Mission</param>
        /// <returns>Mission corresponding</returns>
        public Mission GetMissionById(int id);

        /// <summary>
        /// Returns all missions in context
        /// </summary>
        /// <returns>Missions in context</returns>
        public IEnumerable<Mission> GetMissions();

        /// <summary>
        /// Add mission in context
        /// </summary>
        /// <param name="mission">Mission to add</param>
        /// <returns>True if done, false if error</returns>
        public bool AddMission(Mission mission);

        /// <summary>
        /// Delete mission in context
        /// </summary>
        /// <param name="mission">Mission to delete</param>
        /// <returns>True if done, false if error</returns>
        public bool DeleteMission(Mission mission);

        /// <summary>
        /// Update mission in context
        /// </summary>
        /// <param name="mission">Mission to update</param>
        /// <returns>True if done, false if error</returns>
        public bool UpdateMission(Mission mission);
    }
}
