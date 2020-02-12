//-----------------------------------------------------------------------
// <copyright file="IRouteBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business.Contracts
{
    using System.Collections.Generic;
    using PedaGo.Entities;

    /// <summary>
    /// Business interface for the routes
    /// </summary>
    public interface IRouteBusiness
    {
        /// <summary>
        /// Method to insert a route
        /// </summary>
        /// <param name="route">Route object to insert</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        public bool AddRoute(Route route);

        /// <summary>
        /// Method to delete a route
        /// </summary>
        /// <param name="route">Route object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        public bool DeleteRoute(Route route);

        /// <summary>
        /// Method to get a route by its id
        /// </summary>
        /// <param name="id">Id of the route to get</param>
        /// <returns>Return a Route object</returns>
        public Route GetRouteById(int id);

        /// <summary>
        /// Method to get all the routes
        /// </summary>
        /// <returns>Return IEnumerable of Route</returns>
        public IEnumerable<Route> GetRoutes();

        /// <summary>
        /// Method to update a route
        /// </summary>
        /// <param name="route">Route object to update</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        public bool UpdateRoute(Route route);
    }
}
