//-----------------------------------------------------------------------
// <copyright file="Type.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Type class
    /// </summary>
    public partial class Type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Type" /> class.
        /// </summary>
        public Type()
        {
            this.Trials = new HashSet<Trial>();
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
        /// Gets or sets <c>Trials</c>
        /// </summary>
        public virtual ICollection<Trial> Trials { get; set; }
    }
}
