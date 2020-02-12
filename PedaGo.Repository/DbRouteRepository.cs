//-----------------------------------------------------------------------
// <copyright file="DbRouteRepository.cs" company="Diiage">
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
    /// Class to communicate with the database for the routes
    /// </summary>
    public class DbRouteRepository : IRouteRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbRouteRepository" /> class.
        /// </summary>
        /// <param name="service">Scope factory interface</param>
        public DbRouteRepository(IServiceScopeFactory service)
        {
            this.scopeFactory = service;
        }

        /// <summary>
        /// Method to insert a route in the database
        /// </summary>
        /// <param name="route">Route object to insert</param>
        /// <returns>Return a boolean if the insertion happened correctly</returns>
        bool IRouteRepository.AddRoute(Route route)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Routes.Add(route);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete a route in the database
        /// </summary>
        /// <param name="route">Route object to delete</param>
        /// <returns>Return a boolean if the suppression happened correctly</returns>
        bool IRouteRepository.DeleteRoute(Route route)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Routes.Remove(route);
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
        /// Method to get a route by its id
        /// </summary>
        /// <param name="id">Id of the route to get</param>
        /// <returns>Return a Route object corresponding to the id</returns>
        Route IRouteRepository.GetRouteById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Routes.Where(r => r.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Method to get all the routes
        /// </summary>
        /// <returns>Return a IEnumerable of Route</returns>
        IEnumerable<Route> IRouteRepository.GetRoutes()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Routes.Include(r => r.Routesteps).ThenInclude(rs => rs.Step);
        }

        /// <summary>
        /// Method to update a route in the database
        /// </summary>
        /// <param name="route">Route object to update</param>
        /// <returns>Return a boolean if the update happened correctly</returns>
        bool IRouteRepository.UpdateRoute(Route route)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Routes.Update(route);
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
