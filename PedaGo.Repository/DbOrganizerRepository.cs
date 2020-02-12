//-----------------------------------------------------------------------
// <copyright file="DbOrganizerRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using PedaGo.Entities;
    using PedaGo.EntityContext;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Class to communicate with the database for the organizer
    /// </summary>
    public class DbOrganizerRepository : IOrganizerRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbOrganizerRepository"/> class.
        /// </summary>
        /// <param name="service">ScopeFactory interface</param>
        public DbOrganizerRepository(IServiceScopeFactory service)
        {
            this.scopeFactory = service;
        }

        /// <summary>
        /// Method to add an organizer in the database
        /// </summary>
        /// <param name="organizer">Organizer object to add</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IOrganizerRepository.AddOrganizer(Organizer organizer)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Organizers.Add(organizer);
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
        /// Method to delete an organizer from the database
        /// </summary>
        /// <param name="organizer">Organizer object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        bool IOrganizerRepository.DeleteOrganizer(Organizer organizer)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Organizers.Remove(organizer);
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
        /// Method to get an organizer by its id from the database
        /// </summary>
        /// <param name="id">Id of the organizer to get</param>
        /// <returns>Return an Organizer object</returns>
        Organizer IOrganizerRepository.GetOrganizerById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Organizers.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Method to get all the organizers from the database
        /// </summary>
        /// <returns>Return an IEnumerable of Organizer</returns>
        IEnumerable<Organizer> IOrganizerRepository.GetOrganizers()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Organizers;
        }

        /// <summary>
        /// Method to update an organizer in the database
        /// </summary>
        /// <param name="organizer">Organizer object to get</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        bool IOrganizerRepository.UpdateOrganizer(Organizer organizer)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Organizers.Update(organizer);
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
