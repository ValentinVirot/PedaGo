//-----------------------------------------------------------------------
// <copyright file="MissionController.cs" company="Diiage">
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
        /// Gets mission by Id
        /// </summary>
        /// <param name="id">Id of the mission to query</param>
        /// <returns>Mission corresponding to ID</returns>
        [HttpGet("getMission/{id}"), Authorize]
        public IActionResult GetMissionById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.missionBusiness.GetMissionById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Gets all missions stored in our Context
        /// </summary>
        /// <returns>HttpResponse with content</returns>
        [HttpGet("getMissions"), Authorize]
        public IActionResult GetMissions()
        {
            return this.Ok(JsonConvert.SerializeObject(this.missionBusiness.GetMissions(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add mission in context
        /// </summary>
        /// <param name="mission">Mission to add</param>
        /// <returns>IActionResult depending on result</returns>
        [HttpPost("addMission"), Authorize]
        public IActionResult AddMission(Mission mission)
        {
            if (this.missionBusiness.AddMission(mission))
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