// ************************************************************************************
// <copyright file="BaseController.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************


namespace Fanex.Game.Core.Web.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// Base controller class.
    /// </summary>
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = AppSession.Language;

            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = "zh-CN"; 
            }
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            base.OnActionExecuting(filterContext);
        }
    }
}
