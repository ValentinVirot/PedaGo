//-----------------------------------------------------------------------
// <copyright file="StatisticPage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Statistic Page code behind
    /// </summary>
    public partial class StatisticPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticPage" /> class.
        /// </summary>
        public StatisticPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            
            this.InitializeComponent();
        }
    }
}
