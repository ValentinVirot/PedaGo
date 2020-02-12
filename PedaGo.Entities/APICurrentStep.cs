//-----------------------------------------------------------------------
// <copyright file="APICurrentStep.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    /// <summary>
    /// Answer when calling for Current Step from the <c>Xamarin</c> App
    /// </summary>
    public class APICurrentStep
    {
        /// <summary>
        /// Gets or sets Route name
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// Gets or sets Step name
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// Gets or sets Step description
        /// </summary>
        public string StepDescription { get; set; }

        /// <summary>
        /// Gets or sets Step ID
        /// </summary>
        public int StepId { get; set; }
    }
}
