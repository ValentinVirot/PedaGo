//-----------------------------------------------------------------------
// <copyright file="IGameRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Contracts
{
    using System.Threading.Tasks;

    /// <summary>
    /// Access to authentication data
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Send picture to Azure, then return status
        /// </summary>
        /// <param name="photo">Photo taken by the player</param>
        /// <returns>True if success, False if something append</returns>
        Task<bool> SendValidationPic(Plugin.Media.Abstractions.MediaFile photo);
    }
}
