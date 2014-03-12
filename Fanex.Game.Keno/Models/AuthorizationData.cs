// ************************************************************************************
// <copyright file="AuthorizationData.cs" company="Nexcel Solutions Vietnam">
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
    /// Class Authorization Data.
    /// </summary>
    [Serializable]
    public class AuthorizationData
    {
        /// <summary>
        /// Gets or sets the authorization.
        /// </summary>
        /// <value>The authorization.</value>
        public string Authorization { get; set; }
    }
}