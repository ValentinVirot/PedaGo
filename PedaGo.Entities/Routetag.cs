//-----------------------------------------------------------------------
// <copyright file="Routetag.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    /// <summary>
    /// <c>Routetag</c> class
    /// </summary>
    public partial class Routetag
    {
        /// <summary>
        /// Gets or sets <c>RouteId</c>
        /// </summary>
        public int RouteId { get; set; }

        /// <summary>
        /// Gets or sets <c>TagId</c>
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Gets or sets <c>Route</c>
        /// </summary>
        public virtual Route Route { get; set; }

        /// <summary>
        /// Gets or sets <c>Tag</c>
        /// </summary>
        public virtual Tag Tag { get; set; }
    }
}
