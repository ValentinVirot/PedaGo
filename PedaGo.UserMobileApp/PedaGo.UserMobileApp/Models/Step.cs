//-----------------------------------------------------------------------
// <copyright file="Step.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Step class
    /// </summary>
    public partial class Step
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Step" /> class.
        /// </summary>
        public Step()
        {
            this.Missions = new HashSet<Mission>();
            this.Routesteps = new HashSet<Routestep>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>Description</c>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets <c>Validation</c>
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Gets or sets <c>CreationDate</c>
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets <c>Name</c>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <c>Lat</c>
        /// </summary>
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets <c>Lng</c>
        /// </summary>
        public double? Lng { get; set; }

        /// <summary>
        /// Gets or sets <c>Missions</c>
        /// </summary>
        public virtual ICollection<Mission> Missions { get; set; }

        /// <summary>
        /// Gets or sets <c>Routesteps</c>
        /// </summary>
        public virtual ICollection<Routestep> Routesteps { get; set; }
    }
}
