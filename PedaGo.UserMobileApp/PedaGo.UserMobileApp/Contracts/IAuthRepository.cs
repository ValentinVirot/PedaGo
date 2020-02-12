//-----------------------------------------------------------------------
// <copyright file="IAuthRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Contracts
{
    /// <summary>
    /// Access to authentication data
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Returns JWToken based on username and password
        /// </summary>
        /// <param name="username">Username of the user account</param>
        /// <param name="password">Password of the user account</param>
        /// <returns>JWToken (string)</returns>
        string GetToken(string username, string password);
    }
}
