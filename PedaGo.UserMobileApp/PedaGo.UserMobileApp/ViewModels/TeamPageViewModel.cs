//-----------------------------------------------------------------------
// <copyright file="TeamPageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Models;
    using PedaGo.UserMobileApp.Services;
    using Prism.Mvvm;

    /// <summary>
    /// ViewModel attached to Team Page
    /// </summary>
    public class TeamPageViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamPageViewModel" /> class.
        /// </summary>
        /// <param name="playerRepo">Player Repository interface</param>
        public TeamPageViewModel(IPlayerRepository playerRepo)
        {
            var team = playerRepo.GetTeam(CurrentUser.Player.Id);
            var players = team.Teamplayers.Select(t => t.Player).ToList();

            players.Where(x => x.Picture == null || x.Picture == string.Empty).ToList().ForEach(p => p.Picture = PedaGoServers.DefaultProfilePic);

            this.Players = new List<TeamViewModel>();

            players.ForEach(p =>
            {
                if (p.Id == team.CaptainId)
                {
                    this.Players.Add(new TeamViewModel { Name = p.FirstName + " " + p.LastName + " (capitaine)", Url = p.Picture, IsCaptain = true });
                }
                else
                {
                    this.Players.Add(new TeamViewModel { Name = p.FirstName + " " + p.LastName, Url = p.Picture, IsCaptain = false });
                }
            });
        }

        /// <summary>
        /// Gets or sets the list of Players
        /// </summary>
        public List<TeamViewModel> Players { get; set; }
    }
}
