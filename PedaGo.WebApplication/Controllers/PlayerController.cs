//-----------------------------------------------------------------------
// <copyright file="PlayerController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using PedaGo.Entities;

    /// <summary>
    /// API Controller Partial Class
    /// </summary>
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// Add player in context
        /// </summary>
        /// <param name="player">Player to Add</param>
        /// <returns>IActionResult depending on result</returns>
        [HttpPost("addPlayer"), Authorize]
        public IActionResult AddPlayer(Player player)
        {
            if (this.playerBusiness.AddPlayer(player))
            {
                return this.Ok();
            }
            else
            {
                return this.Problem();
            }
        }

        /// <summary>
        /// Return user details
        /// </summary>
        /// <param name="clientSrc">User credentials</param>
        /// <returns>IActionResult with Player serialized as content</returns>
        [Authorize, HttpPost, Route("getUserDetails"), EnableCors("PedaGoPolicy")]
        public IActionResult GetUserDetails([FromForm]APIClient clientSrc)
        {
            return this.Ok(this.playerBusiness.GetUserDetails(clientSrc.Username, clientSrc.Password));
        }

        /// <summary>
        /// Gets user profile picture URL
        /// </summary>
        /// <param name="username">Username of corresponding user</param>
        /// <returns>IActionResult with PP URL serialized in Content</returns>
        [HttpGet("getUserPp"), Authorize]
        public IActionResult GetUserPp(string username)
        {
            return this.Ok(new { profilePicture = this.playerBusiness.GetUserProfilePicture(username) });
        }

        /// <summary>
        /// Get a player by Id
        /// </summary>
        /// <param name="id">Id of the player</param>
        /// <returns>Player attached to Id</returns>
        [HttpGet("getPlayer/{id}"), Authorize]
        public IActionResult GetPlayerById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.playerBusiness.GetPlayerById(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Gets all players in context
        /// </summary>
        /// <returns>All players</returns>
        [HttpGet("getPlayers"), Authorize]
        public IActionResult GetPlayers()
        {
            return this.Ok(JsonConvert.SerializeObject(this.playerBusiness.GetPlayers(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Get all players created by organizer id
        /// </summary>
        /// <param name="id">Organizer ID</param>
        /// <returns>All players</returns>
        [HttpGet("getPlayersByOrganizerId"), AllowAnonymous, EnableCors("PedaGoPolicy")]
        public IActionResult GetPlayersByOrganizerId(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.playerBusiness.GetPlayers(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Edits a player in context
        /// </summary>
        /// <param name="player">Player to edit</param>
        /// <returns>True is success, false if something happen</returns>
        [HttpPost("editPlayer"), Authorize]
        public IActionResult EditPlayer(Player player)
        {
            if (this.playerBusiness.EditPlayer(player))
            {
                return this.Ok();
            }
            else
            {
                return this.Problem();
            }
        }

        /// <summary>
        /// Delete a player in context
        /// </summary>
        /// <param name="player">Player to delete</param>
        /// <returns>Ok if success, Problem if something happen</returns>
        [HttpPost("deletePlayer"), Authorize]
        public IActionResult DeletePlayer(Player player)
        {
            if (this.playerBusiness.DeletePlayer(player))
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