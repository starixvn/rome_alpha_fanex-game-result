// ************************************************************************************
// <copyright file="LogExtension.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Core.Extensions
{
    using System;
    using Fanex.Logging;

    /// <summary>
    /// Log extension class.
    /// </summary>
    public class LogExtension
    {
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The exception object.</param>
        public static void LogError(Exception ex)
        {
            LogService.Error(ex.Message, ex);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="errorMsg">The error MSG.</param>
        public static void LogError(string errorMsg)
        {
            LogService.Error(errorMsg);
        }
    }
}
