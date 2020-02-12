//-----------------------------------------------------------------------
// <copyright file="StepController.cs" company="Diiage">
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
        /// Gets a step by its id
        /// </summary>
        /// <param name="id">Id of the step</param>
        /// <returns>Step linked to the Id</returns>
        [HttpGet("getStep/{id}"), Authorize]
        public IActionResult GetStepById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.stepBusiness.GetStepById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Get all steps 
        /// </summary>
        /// <returns>Return all steps</returns>
        [HttpGet("getSteps"), Authorize]
        public IActionResult GetSteps()
        {
            return this.Ok(JsonConvert.SerializeObject(this.stepBusiness.GetSteps(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add a step
        /// </summary>
        /// <param name="step">Step object to add</param>
        /// <returns>IActionResult depending on the result</returns>
        [HttpPost("addStep"), Authorize]
        public IActionResult AddStep(Step step)
        {
            if (this.stepBusiness.AddStep(step))
            {
                return this.Ok();
            }
            else
            {
                return this.Problem();
            }
        }

        /// <summary>
        /// Returns current step of a user
        /// </summary>
        /// <param name="userid">ID of wanted user</param>
        /// <returns>IAction result with a APICurrentStep object</returns>
        [HttpGet("getCurrentStep"), Authorize]
        public IActionResult GetCurrentStep(int userid)
        {
            return this.Ok(this.stepBusiness.GetCurrentStep(userid));
        }
    }
}