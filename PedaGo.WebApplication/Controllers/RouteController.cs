//-----------------------------------------------------------------------
// <copyright file="RouteController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using PedaGo.Entities;

    /// <summary>
    /// API Controller Partial Class
    /// </summary>
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// Get a route by its id
        /// </summary>
        /// <param name="id">Id of the route to get</param>
        /// <returns>Return the Route corresponding to the id</returns>
        [HttpGet("getRoute/{id}"), Authorize]
        public IActionResult GetRouteById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.routeBusiness.GetRouteById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Get all routes
        /// </summary>
        /// <returns>Return all the routes</returns>
        [HttpGet("getRoutes"), Authorize]
        public IActionResult GetRoutes()
        {
            return this.Ok(JsonConvert.SerializeObject(this.routeBusiness.GetRoutes(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add a route
        /// </summary>
        /// <param name="route">Route object to add</param>
        /// <returns>IActionResult depending on the result</returns>
        [HttpPost("addRoute"), Authorize]
        public IActionResult AddRoute(Route route)
        {
            if (this.routeBusiness.AddRoute(route))
            {
                return this.Ok();
            }
            else
            {
                return this.Problem();
            }
        }
    }
}