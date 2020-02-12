//-----------------------------------------------------------------------
// <copyright file="LoginPage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Login Page c# code
    /// </summary>
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class
        /// </summary>
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.InitializeComponent();
        }
    }
}
