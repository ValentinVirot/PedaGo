//-----------------------------------------------------------------------
// <copyright file="DbMissionRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PedaGo.Entities;
    using PedaGo.EntityContext;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// This class make the communication with the database
    /// </summary>
    public class DbMissionRepository : IMissionRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbMissionRepository" /> class.
        /// </summary>
        /// <param name="scopeSrc">Scope factory interface</param>
        public DbMissionRepository(IServiceScopeFactory scopeSrc)
        {
            this.scopeFactory = scopeSrc;
        }

        /// <summary>
        /// Add mission in context
        /// </summary>
        /// <param name="mission">Mission to add</param>
        /// <returns>True if done, false if error</returns>
        public bool AddMission(Mission mission)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Missions.Add(mission);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete mission in context
        /// </summary>
        /// <param name="mission">Mission to delete</param>
        /// <returns>True if done, false if error</returns>
        public bool DeleteMission(Mission mission)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Missions.Remove(mission);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Return mission depending on the ID
        /// </summary>
        /// <param name="id">ID of wanted Mission</param>
        /// <returns>Mission corresponding</returns>
        public Mission GetMissionById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Missions.Where(m => m.Id == id).Include(m => m.Trials).ThenInclude(t => t.Answers).FirstOrDefault();
        }

        /// <summary>
        /// Returns all missions in context
        /// </summary>
        /// <returns>Missions in context</returns>
        public IEnumerable<Mission> GetMissions()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Missions.Include(m => m.Trials).ThenInclude(t => t.Answers);
        }

        /// <summary>
        /// Update mission in context
        /// </summary>
        /// <param name="mission">Mission to update</param>
        /// <returns>True if done, false if error</returns>
        public bool UpdateMission(Mission mission)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Missions.Update(mission);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
