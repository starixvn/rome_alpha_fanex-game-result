// ************************************************************************************
// <copyright file="AuthorizationResult.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Keno.Models
{
    using System;

    /// <summary>
    /// Class Authorization Result.
    /// </summary>
    [Serializable]
    public class AuthorizationResult
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data that contains authorization key.</value>
        public AuthorizationData Data { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error MSG.
        /// </summary>
        /// <value>The error MSG.</value>
        public string ErrorMsg { get; set; }
    }
}