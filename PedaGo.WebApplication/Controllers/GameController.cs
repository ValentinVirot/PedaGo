//-----------------------------------------------------------------------
// <copyright file="GameController.cs" company="Diiage">
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
    /// API Controller partial class
    /// </summary>
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// Get a game by its id
        /// </summary>
        /// <param name="id">Id of the route to get</param>
        /// <returns>Return the game corresponding to the id</returns>
        [HttpGet("getGame/{id}"), Authorize]
        public IActionResult GetGameById(int id)
        {
            return this.Ok(JsonConvert.SerializeObject(this.gameBusiness.GetGamebyId(id), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Get all the games
        /// </summary>
        /// <returns>Return all the games</returns>
        [HttpGet("getGames"), Authorize]
        public IActionResult GetGames()
        {
            return this.Ok(JsonConvert.SerializeObject(this.gameBusiness.GetGames(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Add a game
        /// </summary>
        /// <param name="game">Game object to add</param>
        /// <returns>IActionResult depending on the result</returns>
        [HttpPost("addGame"), Authorize]
        public IActionResult AddGame(Game game)
        {
            if (this.gameBusiness.AddGame(game))
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
