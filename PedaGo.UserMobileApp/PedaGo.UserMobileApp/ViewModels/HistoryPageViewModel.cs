//-----------------------------------------------------------------------
// <copyright file="HistoryPageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using PedaGo.UserMobileApp.Models;
    using Prism.Mvvm;

    /// <summary>
    /// ViewModel History Page (page to see the history of the route of the user)
    /// </summary>
    public class HistoryPageViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryPageViewModel" /> class.
        /// </summary>
        public HistoryPageViewModel()
        {
            var games = new List<Play>
            {
                new Play
                {
                    Game = new Game
                    {
                        Route = new Route
                        {
                            Name = "Routes des grands vins",
                            Distance = 42
                        }
                    },
                    Time = new System.TimeSpan(1, 14, 53)
                },

                new Play
                {
                    Game = new Game
                    {
                        Route = new Route
                        {
                            Name = "Direction les Toënes!",
                            Distance = 1
                        }
                    },
                    Time = new System.TimeSpan(0, 10, 12)
                },
                new Play
                {
                    Game = new Game
                    {
                        Route = new Route
                        {
                            Name = "Ruée des fadas",
                            Distance = 25
                        }
                    },
                    Time = new System.TimeSpan(0, 35, 44)
                }
            };

            this.Games = new List<HistoryViewModel>();

            games.ForEach(x => this.Games.Add(new HistoryViewModel(x.Game.Route.Name, (int)x.Game.Route.Distance, (TimeSpan)x.Time)));
        }

        /// <summary>
        /// Gets or sets list of games
        /// </summary>
        public List<HistoryViewModel> Games { get; set; }
    }
}
