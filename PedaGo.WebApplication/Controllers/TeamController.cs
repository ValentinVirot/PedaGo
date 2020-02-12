//-----------------------------------------------------------------------
// <copyright file="TeamController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    /// <summary>
    /// API Controller Partial Class
    /// </summary>
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// Gets Team depending on given user ID
        /// </summary>
        /// <param name="userid">User ID</param>
        /// <returns>HttpResponse with Team serialized as content</returns>
        [HttpGet("getTeam"), Authorize]
        public IActionResult GetTeam(int userid)
        {
            return this.Ok(JsonConvert.SerializeObject(this.playerBusiness.GetTeam(userid), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
    }
}