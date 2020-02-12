//-----------------------------------------------------------------------
// <copyright file="DbTrialRepository.cs" company="Diiage">
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
    /// This class allows to communicate with the database
    /// </summary>
    public class DbTrialRepository : ITrialRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTrialRepository" /> class.
        /// </summary>
        /// <param name="scopeSrc">Scope factory interface</param>
        public DbTrialRepository(IServiceScopeFactory scopeSrc)
        {
            this.scopeFactory = scopeSrc;
        }

        /// <summary>
        /// Add trial in context
        /// </summary>
        /// <param name="trial">Trial to add</param>
        /// <returns>True if done, false if error</returns>
        public bool AddTrial(Trial trial)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Trials.Add(trial);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception ex)
            {
                var e = ex;
                return false;
            }
        }

        /// <summary>
        /// Delete trial in context
        /// </summary>
        /// <param name="trial">Trial to delete</param>
        /// <returns>True if done, false if error</returns>
        public bool DeleteTrial(Trial trial)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Trials.Remove(trial);
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
        /// Returns all trials in context
        /// </summary>
        /// <returns>Trials in context</returns>
        public IEnumerable<Trial> GetTrials()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Trials;
        }

        /// <summary>
        /// Returns trial by ID
        /// </summary>
        /// <param name="id">ID of wanted trial</param>
        /// <returns>Corresponding trial</returns>
        public Trial GetTrialById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Trials.Where(t => t.Id == id).Include(t => t.Answers).Include(t => t.CorrectAnswer).Include(t => t.Type).FirstOrDefault();
        }

        /// <summary>
        /// Update trial in context
        /// </summary>
        /// <param name="trial">Trial to update</param>
        /// <returns>True if done, false if error</returns>
        public bool UpdateTrial(Trial trial)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Trials.Update(trial);
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
