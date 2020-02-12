//-----------------------------------------------------------------------
// <copyright file="Administrator.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Administrator class
    /// </summary>
    public partial class Administrator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator" /> class.
        /// </summary>
        public Administrator()
        {
            this.Organizers = new HashSet<Organizer>();
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
        /// Gets or sets <c>Organizers</c>
        /// </summary>
        public virtual ICollection<Organizer> Organizers { get; set; }
    }
}
