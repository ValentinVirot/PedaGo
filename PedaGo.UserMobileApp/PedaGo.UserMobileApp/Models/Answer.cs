//-----------------------------------------------------------------------
// <copyright file="Answer.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Answer class
    /// </summary>
    public partial class Answer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Answer" /> class.
        /// </summary>
        public Answer()
        {
            this.Teamanswers = new HashSet<Teamanswer>();
            this.Trials = new HashSet<Trial>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>TrialId</c>
        /// </summary>
        public int? TrialId { get; set; }

        /// <summary>
        /// Gets or sets <c>Libelle</c>
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Gets or sets <c>Picture</c>
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets <c>Trial</c>
        /// </summary>
        public virtual Trial Trial { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamanswers</c>
        /// </summary>
        public virtual ICollection<Teamanswer> Teamanswers { get; set; }

        /// <summary>
        /// Gets or sets <c>Trials</c>
        /// </summary>
        public virtual ICollection<Trial> Trials { get; set; }
    }
}
