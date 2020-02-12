//-----------------------------------------------------------------------
// <copyright file="OrganizerController.cs" company="Diiage">
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
        /// Get all the organizers
        /// </summary>
        /// <returns>Return all the organizers</returns>
        [HttpGet("getOrganizers"), Authorize]
        public IActionResult GetOrganizers()
        {
            return this.Ok(JsonConvert.SerializeObject(this.organizerBusiness.GetOrganizers(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add an organizer
        /// </summary>
        /// <param name="organizer">Organizer object to add</param>
        /// <returns>Return IActionResult depending on the result</returns>
        [HttpPost("addOrganizer")]
        public IActionResult AddOrganizer(Organizer organizer)
        {
            if (this.organizerBusiness.AddOrganizer(organizer))
            {
                return this.Ok();
            }
            else
            {
                return this.Problem();
            }
        }

        /// <summary>
        /// Get an organizer by its id
        /// </summary>
        /// <param name="id">Id of the organizer to get</param>
        /// <returns>Return the organizer corresponding to the id</returns>
        [HttpGet("getOrganizer/{id}")]
        public IActionResult GetOrganizerById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.organizerBusiness.GetOrganizerById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
    }
}