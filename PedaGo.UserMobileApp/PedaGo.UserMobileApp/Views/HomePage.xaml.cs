//-----------------------------------------------------------------------
// <copyright file="HomePage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Home page c# code
    /// </summary>
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class
        /// </summary>
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.InitializeComponent();
        }
    }
}
