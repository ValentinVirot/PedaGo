//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Player class
    /// </summary>
    public partial class Player
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        public Player()
        {
            this.Messages = new HashSet<Message>();
            this.Teams = new HashSet<Team>();
            this.Teamplayers = new HashSet<Teamplayer>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>FirstName</c>
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets <c>LastName</c>
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets <c>Login</c>
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets <c>Password</c>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets <c>Email</c>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets <c>Picture</c>
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets <c>OrganizerId</c>
        /// </summary>
        public int? OrganizerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Organizer</c>
        /// </summary>
        public virtual Organizer Organizer { get; set; }

        /// <summary>
        /// Gets or sets <c>Messages</c>
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }

        /// <summary>
        /// Gets or sets <c>Teams</c>
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamplayers</c>
        /// </summary>
        public virtual ICollection<Teamplayer> Teamplayers { get; set; }
    }
}
