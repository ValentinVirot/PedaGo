//-----------------------------------------------------------------------
// <copyright file="TrialController.cs" company="Diiage">
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
        /// Gets Trial depending on given ID
        /// </summary>
        /// <param name="id">ID of wanted trial</param>
        /// <returns>HttpResponse with content</returns>
        [HttpGet("getTrial/{id}"), Authorize]
        public IActionResult GetTrialByID(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.trialBusiness.GetTrialById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Get all trials in context
        /// </summary>
        /// <returns>Trials stored in context</returns>
        [HttpGet("getTrials"), Authorize]
        public IActionResult GetTrials()
        {
            return this.Ok(JsonConvert.SerializeObject(this.trialBusiness.GetTrials(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add trial in context
        /// </summary>
        /// <param name="trial">Trial to add</param>
        /// <returns>IActionResult depending on result</returns>
        [HttpPost("addTrial"), Authorize]
        public IActionResult AddTrial(Trial trial)
        {
            if (this.trialBusiness.AddTrial(trial))
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