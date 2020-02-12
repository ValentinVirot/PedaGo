//-----------------------------------------------------------------------
// <copyright file="GamePage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Game Page code behind
    /// </summary>
    public partial class GamePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamePage" /> class.
        /// </summary>
        public GamePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            
            this.InitializeComponent();
        }
    }
}
