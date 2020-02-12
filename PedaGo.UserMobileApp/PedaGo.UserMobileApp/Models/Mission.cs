//-----------------------------------------------------------------------
// <copyright file="Mission.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Mission class
    /// </summary>
    public partial class Mission
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mission" /> class.
        /// </summary>
        public Mission()
        {
            this.Trials = new HashSet<Trial>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>StepId</c>
        /// </summary>
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or sets <c>Description</c>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets <c>Score</c>
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// Gets or sets <c>Time</c>
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// Gets or sets <c>Name</c>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <c>Step</c>
        /// </summary>
        public virtual Step Step { get; set; }

        /// <summary>
        /// Gets or sets <c>Trials</c>
        /// </summary>
        public virtual ICollection<Trial> Trials { get; set; }
    }
}
