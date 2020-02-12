//-----------------------------------------------------------------------
// <copyright file="Routestep.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// <c>Routestep</c> class
    /// </summary>
    public partial class Routestep
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Routestep" /> class.
        /// </summary>
        public Routestep()
        {
            this.Teamroutes = new HashSet<Teamroute>();
        }

        /// <summary>
        /// Gets or sets <c>RouteId</c>
        /// </summary>
        public int RouteId { get; set; }

        /// <summary>
        /// Gets or sets <c>StepId</c>
        /// </summary>
        public int StepId { get; set; }

        /// <summary>
        /// Gets or sets <c>Order</c>
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// Gets or sets <c>Route</c>
        /// </summary>
        public virtual Route Route { get; set; }

        /// <summary>
        /// Gets or sets <c>Step</c>
        /// </summary>
        public virtual Step Step { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamroutes</c>
        /// </summary>
        public virtual ICollection<Teamroute> Teamroutes { get; set; }
    }
}
