// ************************************************************************************
// <copyright file="IKenoGameService.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Keno.Business
{
    using Fanex.Game.Keno.Models;

    /// <summary>
    /// Interface IKenoGameService.
    /// </summary>
    public interface IKenoGameService
    {
        /// <summary>
        /// Gets the authorization key.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Authorization key for specific system.</returns>
        string GetAuthorizationKey(int userId, int productId);

        AuthorizationResult ExtendToken(int userId, int productId);
    }
}