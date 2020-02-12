//-----------------------------------------------------------------------
// <copyright file="RouteBusiness.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Class to make the treatment from the routes and step
    /// </summary>
    public class RouteBusiness : IRouteBusiness
    {
        /// <summary>
        /// Route repository interface
        /// </summary>
        private IRouteRepository routeRepository;

        /// <summary>
        /// Step business interface
        /// </summary>
        private IStepBusiness stepBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteBusiness"/> class.
        /// </summary>
        /// <param name="route">Implementation of the route repository</param>
        /// <param name="step">Implementation of the step business</param>
        public RouteBusiness(IRouteRepository route, IStepBusiness step)
        {
            this.routeRepository = route;
            this.stepBusiness = step;
        }

        /// <summary>
        /// Method to insert a route
        /// </summary>
        /// <param name="route">Route object to insert</param>
        /// <returns>Return a boolean if the insertion happened correctly</returns>
        bool IRouteBusiness.AddRoute(Route route)
        {
            return this.routeRepository.AddRoute(route);
        }

        /// <summary>
        /// Method to delete a route
        /// </summary>
        /// <param name="route">Route object to delete</param>
        /// <returns>Return a boolean if the suppression happened correctly</returns>
        bool IRouteBusiness.DeleteRoute(Route route)
        {
            return this.routeRepository.DeleteRoute(route);
        }

        /// <summary>
        /// Method to get a route by its id
        /// </summary>
        /// <param name="id">Id of the route to get</param>
        /// <returns>Return route object corresponding to the id</returns>
        Route IRouteBusiness.GetRouteById(int id)
        {
            return this.routeRepository.GetRouteById(id);
        }

        /// <summary>
        /// Method to get all routes
        /// </summary>
        /// <returns>Return a IEnumerable of Route</returns>
        IEnumerable<Route> IRouteBusiness.GetRoutes()
        {
            return this.routeRepository.GetRoutes();
        }

        /// <summary>   
        /// Method to update a route
        /// </summary>
        /// <param name="route">Route object to update</param>
        /// <returns>Return a boolean if the update happened correctly</returns>
        bool IRouteBusiness.UpdateRoute(Route route)
        {
            return this.routeRepository.UpdateRoute(route);
        }
    }
}
