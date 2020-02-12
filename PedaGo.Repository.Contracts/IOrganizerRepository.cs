//-----------------------------------------------------------------------
// <copyright file="IOrganizerRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Interface for the organizer repository
    /// </summary>
    public interface IOrganizerRepository
    {
        /// <summary>
        /// Method to get an organizer by its id
        /// </summary>
        /// <param name="id">Id of the organizer to get</param>
        /// <returns>Return an Organizer object</returns>
        public Organizer GetOrganizerById(int id);

        /// <summary>
        /// Method to get all the organizers
        /// </summary>
        /// <returns>Return an IEnumerable of Organizer</returns>
        public IEnumerable<Organizer> GetOrganizers();

        /// <summary>
        /// Method to add an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to add</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool AddOrganizer(Organizer organizer);

        /// <summary>
        /// Method to delete an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        public bool DeleteOrganizer(Organizer organizer);

        /// <summary>
        /// Method to update an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to get</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        public bool UpdateOrganizer(Organizer organizer);
    }
}
