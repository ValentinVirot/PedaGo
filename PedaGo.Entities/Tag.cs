//-----------------------------------------------------------------------
// <copyright file="Tag.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Tag class
    /// </summary>
    public partial class Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag" /> class.
        /// </summary>
        public Tag()
        {
            this.Routetags = new HashSet<Routetag>();
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
        /// Gets or sets <c>Color</c>
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets <c>Name</c>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <c>Routetags</c>
        /// </summary>
        public virtual ICollection<Routetag> Routetags { get; set; }
    }
}
