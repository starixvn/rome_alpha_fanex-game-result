// ************************************************************************************
// <copyright file="AppSession.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Core.Web
{
    using System;
    using System.Web;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AppSession
    {
        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>The language.</value>
        public static string Language
        {
            get
            {
                var objSessionCulture = HttpContext.Current.Session["culture"];
                return objSessionCulture == null ? string.Empty : Convert.ToString(objSessionCulture);
            }
        }
    }
}
