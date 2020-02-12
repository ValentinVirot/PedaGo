//-----------------------------------------------------------------------
// <copyright file="AuthController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using System;
    using System.Diagnostics;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.IdentityModel.Tokens;
    using PedaGo.Entities;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Authentication Controller, called whenever a client needs some authentication
    /// </summary>
    [Route("[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Azure subscription TenantId
        /// </summary>
        private readonly string tenantId;

        /// <summary>
        /// Azure AD ApplicationId
        /// </summary>
        private readonly string clientId;

        /// <summary>
        /// Azure AD Application Service Principal password
        /// </summary>
        private readonly string clientSecret;

        /// <summary>
        /// Immersive Reader resource subdomain
        /// </summary>
        private readonly string subdomain;

        /// <summary>
        /// IConfiguration, injected
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// Allows access to Player data, injected
        /// </summary>
        private IPlayerRepository playerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController" /> class.
        /// </summary>
        /// <param name="configuration">IConfiguration interface, injected (from Startup)</param>
        /// <param name="playerRepo">Player repository interface, injected (from Startup)</param>
        public AuthController(IConfiguration configuration, IPlayerRepository playerRepo)
        {
            this.playerRepo = playerRepo;
            this.config = configuration;

            this.tenantId = this.config["TenantId"];
            this.clientId = this.config["ClientId"];
            this.clientSecret = this.config["ClientSecret"];
            this.subdomain = this.config["Subdomain"];

            if (string.IsNullOrWhiteSpace(this.tenantId))
            {
                throw new ArgumentNullException("TenantId is null! Did you add that info to secrets.json?");
            }

            if (string.IsNullOrWhiteSpace(this.clientId))
            {
                throw new ArgumentNullException("ClientId is null! Did you add that info to secrets.json?");
            }

            if (string.IsNullOrWhiteSpace(this.clientSecret))
            {
                throw new ArgumentNullException("ClientSecret is null! Did you add that info to secrets.json?");
            }

            if (string.IsNullOrWhiteSpace(this.subdomain))
            {
                throw new ArgumentNullException("Subdomain is null! Did you add that info to secrets.json?");
            }
        }

        /// <summary>
        /// Gets token and subdomain directly from Azure, depending on credentials in secret file
        /// </summary>
        /// <returns>Result containing token and subdomain</returns>
        [HttpGet, Route("getIRToken"), EnableCors("PedaGoPolicy")]
        public async Task<JsonResult> GetIrToken()
        {
            try
            {
                string tokenResult = await this.GetTokenAsync();

                return new JsonResult(new { token = tokenResult, subdomain = this.subdomain });
            }
            catch (Exception e)
            {
                string message = "Unable to acquire Azure AD token. Check the debugger for more information.";
                Debug.WriteLine(message, e);
                return new JsonResult(new { error = message });
            }
        }

        /// <summary>
        /// Generates an JWToken whenever a client call this route
        /// </summary>
        /// <param name="clientSrc">Client that wants a token</param>
        /// <returns>Status code, if Ok, token in string</returns>
        [AllowAnonymous, HttpPost, Route("getToken"), EnableCors("PedaGoPolicy")]
        public IActionResult GetToken([FromForm]APIClient clientSrc)
        {
            IActionResult response = Unauthorized();
            var client = this.CheckAuthentication(clientSrc);

            if (client != null)
            {
                var auth = new APIAuth();

                auth.UserId = client.UserId;
                auth.Token = this.GenerateJsonWebToken();
                response = this.Ok(auth);
            }

            return response;
        }

        /// <summary>
        /// Get an Azure AD authentication token
        /// </summary>
        /// <returns>Access Token</returns>
        private async Task<string> GetTokenAsync()
        {
            string authority = $"https://login.windows.net/{tenantId}";
            const string Resource = "https://cognitiveservices.azure.com/";

            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential clientCredential = new ClientCredential(this.clientId, this.clientSecret);

            AuthenticationResult authResult = await authContext.AcquireTokenAsync(Resource, clientCredential);

            return authResult.AccessToken;
        }

        /// <summary>
        /// Check if client is in the authorized list
        /// </summary>
        /// <param name="clientSrc">Client to check</param>
        /// <returns>APIClient (null if not in list, object if in list)</returns>
        private APIClient CheckAuthentication(APIClient clientSrc)
        {
            APIClient client = null;

            if ((clientSrc.Username != null && clientSrc.Username != string.Empty) && (clientSrc.Password != null && clientSrc.Password != string.Empty))
            {
                var player = this.playerRepo.FindByCredentials(clientSrc.Username, clientSrc.Password);

                if (player != null)
                {
                    client = clientSrc;
                    client.UserId = player.Id;
                }
            }

            return client;
        }

        /// <summary>
        /// Generates a JWToken
        /// </summary>
        /// <returns>Token string</returns>
        private string GenerateJsonWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this.config["Jwt:Issuer"], this.config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}