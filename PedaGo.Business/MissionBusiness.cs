//-----------------------------------------------------------------------
// <copyright file="MissionBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business
{
    using System.Collections.Generic;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Business Layer for Missions
    /// </summary>
    public class MissionBusiness : IMissionBusiness
    {
        /// <summary>
        /// Mission repository interface
        /// </summary>
        private IMissionRepository missionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MissionBusiness" /> class.
        /// </summary>
        /// <param name="repository">Implementation of repository</param>
        public MissionBusiness(IMissionRepository repository)
        {
            this.missionRepository = repository;
        }

        /// <summary>
        /// Add mission in context
        /// </summary>
        /// <param name="mission">Mission to add</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IMissionBusiness.AddMission(Mission mission)
        {
            return this.missionRepository.AddMission(mission);
        }

        /// <summary>
        /// Delete mission in context
        /// </summary>
        /// <param name="mission">Mission to delete</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IMissionBusiness.DeleteMission(Mission mission)
        {
            return this.missionRepository.DeleteMission(mission);
        }

        /// <summary>
        /// Returns mission by ID
        /// </summary>
        /// <param name="id">ID of wanted mission</param>
        /// <returns>Corresponding mission</returns>
        Mission IMissionBusiness.GetMissionById(int id)
        {
            return this.missionRepository.GetMissionById(id);
        }

        /// <summary>
        /// Returns all missions in context
        /// </summary>
        /// <returns>All missions in context</returns>
        IEnumerable<Mission> IMissionBusiness.GetMissions()
        {
            return this.missionRepository.GetMissions();
        }

        /// <summary>
        /// Update mission in context
        /// </summary>
        /// <param name="mission">Mission to update</param>
        /// <returns>True if successful, false if it isn't</returns>
        bool IMissionBusiness.UpdateMission(Mission mission)
        {
            return this.missionRepository.DeleteMission(mission);
        }
    }
}
