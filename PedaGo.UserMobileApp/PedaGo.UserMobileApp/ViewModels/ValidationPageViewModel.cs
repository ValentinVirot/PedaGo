//-----------------------------------------------------------------------
// <copyright file="ValidationPageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using System;
    using System.IO;
    using System.Net.Http;
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Services;
    using Prism.Commands;
    using Prism.Mvvm;
    using RestSharp;
    using Xamarin.Forms;

    /// <summary>
    /// ValidationPage view Model
    /// </summary>
    public class ValidationPageViewModel : BindableBase
    {
        /// <summary>
        /// Image that will be showed in view, taken by user
        /// </summary>
        private ImageSource takenPhoto;

        /// <summary>
        /// Game repository interface
        /// </summary>
        private IGameRepository gameRepo;

        /// <summary>
        /// Photo taken by the user
        /// </summary>
        private Plugin.Media.Abstractions.MediaFile photo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationPageViewModel" /> class.
        /// </summary>
        /// <param name="game">Game repository interface</param>
        public ValidationPageViewModel(IGameRepository game)
        {
            this.gameRepo = game;
            this.TakePhoto = new DelegateCommand(this.TakePicture);
            this.ValidatePhoto = new DelegateCommand(this.ValidatePicture);
        }

        /// <summary>
        /// Gets command <c>binded</c> to Take a photo, from the View
        /// </summary>
        public DelegateCommand TakePhoto { get; private set; }

        /// <summary>
        /// Gets command <c>binded</c> to validate photo, from the View
        /// </summary>
        public DelegateCommand ValidatePhoto { get; private set; }

        /// <summary>
        /// Gets or sets image <c>binded</c> in the view
        /// </summary>
        public ImageSource TakenPhoto
        {
            get => this.takenPhoto;
            set => this.SetProperty(ref this.takenPhoto, value);
        }

        /// <summary>
        /// Method called to Take a Picture
        /// </summary>
        private async void TakePicture()
        {
            this.photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            this.TakenPhoto = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        /// <summary>
        /// Method called 
        /// </summary>
        private async void ValidatePicture()
        {
            if (this.photo != null)
            {
                var status = await this.gameRepo.SendValidationPic(this.photo);
                
                if (status == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Validation en cours", "Votre photo à bien été envoyée vers notre serveur, la validation sera faite prochainement !", "Ok!");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur est survenue lors de l'envoi de la photo vers nos serveurs, veuillez rééssayer ultérieurement.", "Fermer");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Vous devez d'abord prendre une photo !", "Fermer");
            }
        }
    }
}
