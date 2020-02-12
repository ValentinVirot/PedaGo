//-----------------------------------------------------------------------
// <copyright file="TeamPage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Team Page code behind
    /// </summary>
    public partial class TeamPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamPage" /> class.
        /// </summary>
        public TeamPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.InitializeComponent();
        }
    }
}
