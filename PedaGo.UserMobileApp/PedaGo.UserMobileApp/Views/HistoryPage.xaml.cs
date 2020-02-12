//-----------------------------------------------------------------------
// <copyright file="HistoryPage.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// History Page code behind
    /// </summary>
    public partial class HistoryPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryPage" /> class
        /// </summary>
        public HistoryPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.InitializeComponent();
        }
    }
}
