//-----------------------------------------------------------------------
// <copyright file="Transport.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Transport class
    /// </summary>
    public partial class Transport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transport" /> class.
        /// </summary>
        public Transport()
        {
            this.Games = new HashSet<Game>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>Libelle</c>
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Gets or sets <c>Description</c>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets <c>Games</c>
        /// </summary>
        public virtual ICollection<Game> Games { get; set; }
    }
}
