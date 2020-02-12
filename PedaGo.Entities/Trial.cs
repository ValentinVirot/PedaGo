//-----------------------------------------------------------------------
// <copyright file="Trial.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Trial class
    /// </summary>
    public partial class Trial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trial" /> class.
        /// </summary>
        public Trial()
        {
            this.Answers = new HashSet<Answer>();
            this.Teamanswers = new HashSet<Teamanswer>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>TypeId</c>
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// Gets or sets <c>MissionId</c>
        /// </summary>
        public int? MissionId { get; set; }

        /// <summary>
        /// Gets or sets <c>CorrectAnswerId</c>
        /// </summary>
        public int? CorrectAnswerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Score</c>
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// Gets or sets <c>Libelle</c>
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Gets or sets <c>CorrectAnswer</c>
        /// </summary>
        public virtual Answer CorrectAnswer { get; set; }

        /// <summary>
        /// Gets or sets <c>Mission</c>
        /// </summary>
        public virtual Mission Mission { get; set; }

        /// <summary>
        /// Gets or sets <c>Type</c>
        /// </summary>
        public virtual Type Type { get; set; }

        /// <summary>
        /// Gets or sets <c>Answers</c>
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamanswers</c>
        /// </summary>
        public virtual ICollection<Teamanswer> Teamanswers { get; set; }
    }
}
