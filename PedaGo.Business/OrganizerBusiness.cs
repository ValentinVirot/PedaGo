//-----------------------------------------------------------------------
// <copyright file="OrganizerBusiness.cs" company="Diiage">
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
    /// Class to make the treatment on the organizer and call the repository
    /// </summary>
    public class OrganizerBusiness : IOrganizerBusiness
    {
        /// <summary>
        /// Organizer repository interface
        /// </summary>
        private IOrganizerRepository organizerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizerBusiness"/> class.
        /// </summary>
        /// <param name="organizerRepo">Implementation of the repository interface for the organizer</param>
        public OrganizerBusiness(IOrganizerRepository organizerRepo)
        {
            this.organizerRepository = organizerRepo;
        }

        /// <summary>
        /// Method to add an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to add</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IOrganizerBusiness.AddOrganizer(Organizer organizer)
        {
            return this.organizerRepository.AddOrganizer(organizer);
        }

        /// <summary>
        /// Method to delete an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        bool IOrganizerBusiness.DeleteOrganizer(Organizer organizer)
        {
            return this.organizerRepository.DeleteOrganizer(organizer);
        }

        /// <summary>
        /// Method to get an organizer by its id
        /// </summary>
        /// <param name="id">Id of the organizer to get</param>
        /// <returns>Return an Organizer object</returns>
        Organizer IOrganizerBusiness.GetOrganizerById(int id)
        {
            return this.organizerRepository.GetOrganizerById(id);
        }

        /// <summary>
        /// Method to get all the organizers
        /// </summary>
        /// <returns>Return an IEnumerable of Organizer</returns>
        IEnumerable<Organizer> IOrganizerBusiness.GetOrganizers()
        {
            return this.organizerRepository.GetOrganizers();
        }

        /// <summary>
        /// Method to update an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to update</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        bool IOrganizerBusiness.UpdateOrganizer(Organizer organizer)
        {
            return this.organizerRepository.UpdateOrganizer(organizer);
        }
    }
}
