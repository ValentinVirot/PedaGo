//-----------------------------------------------------------------------
// <copyright file="AzureController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
    using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;

    /// <summary>
    /// API controller
    /// </summary>
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// Calls Azure Computer Vision services, and returns tags associated from image (given by URL)
        /// </summary>
        /// <param name="url">URL of the image to search tags for</param>
        /// <returns>IActionResult with tags</returns>
        [HttpPost("gettagsfromurl"), Authorize]
        public async Task<IActionResult> GetTagsFromUrl([FromForm]string url)
        {
            List<VisualFeatureTypes> features = new List<VisualFeatureTypes>()
            {
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.Description,
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Adult,
                VisualFeatureTypes.Color,
                VisualFeatureTypes.Brands,
                VisualFeatureTypes.Objects
            };

            ImageAnalysis results = await this.computerVisionClient.AnalyzeImageAsync(url, features);

            var tagList = results.Tags.Select(x => x.Name).ToList();

            return this.Ok(results);
        }

        /// <summary>
        /// Gets picture from <c>Xamarin</c> and upload it into Azure Container
        /// </summary>
        /// <param name="file">Source file</param>
        /// <returns>ActionResult (Ok if done, Problem if something append)</returns>
        [HttpPost("uploadValidationPhoto"), Authorize]
        public IActionResult UploadValidationPhoto(IFormFile file)
        {
            if (file.Length > 0)
            {
                try
                {
                    CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.Azure.Storage.Auth.StorageCredentials(this.config["Azure:AccountName"], this.config["Azure:SharedKey"]), true);

                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(this.config["Azure:ContainerName"]);

                    CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(file.FileName);

                    blockBlob.UploadFromStream(file.OpenReadStream());

                    var pictureURL = blockBlob.StorageUri.PrimaryUri.ToString();

                    return this.Ok();
                }
                catch
                {
                    return this.Problem();
                }
            }
            else
            {
                return this.Problem();
            }
        }
    }
}