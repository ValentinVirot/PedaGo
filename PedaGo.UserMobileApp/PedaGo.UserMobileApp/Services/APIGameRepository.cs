//-----------------------------------------------------------------------
// <copyright file="APIGameRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using PedaGo.UserMobileApp.Contracts;

    /// <summary>
    /// API implementation of the Authentication Repository interface
    /// </summary>
    public class APIGameRepository : IGameRepository
    {
        /// <summary>
        /// Send picture to Azure, then return status
        /// </summary>
        /// <param name="photo">Photo taken by the player</param>
        /// <returns>True if success, False if something append</returns>
        async Task<bool> IGameRepository.SendValidationPic(Plugin.Media.Abstractions.MediaFile photo)
        {
            try
            {
                HttpContent fileStreamContent = new StreamContent(photo.GetStream());

                fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = CurrentUser.Player.Login + "-" + CurrentUser.CurrentStep.StepId + ".png" };

                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + CurrentUser.Token);

                    formData.Add(fileStreamContent);
                    var response = await client.PostAsync(PedaGoServers.BaseApiUrl + "/api/uploadValidationPhoto", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
