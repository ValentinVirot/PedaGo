//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System;

    /// <summary>
    /// Message class
    /// </summary>
    public partial class Message
    {
        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>PlayerId</c>
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets <c>OrganizerId</c>
        /// </summary>
        public int OrganizerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Content</c>
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <c>FromOrganiser</c>
        /// </summary>
        public bool FromOrganiser { get; set; }

        /// <summary>
        /// Gets or sets <c>Date</c>
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets <c>Organizer</c>
        /// </summary>
        public virtual Organizer Organizer { get; set; }

        /// <summary>
        /// Gets or sets <c>Player</c>
        /// </summary>
        public virtual Player Player { get; set; }
    }
}
