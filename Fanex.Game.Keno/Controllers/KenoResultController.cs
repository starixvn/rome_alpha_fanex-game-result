// ************************************************************************************
// <copyright file="KenoResultController.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Keno.Controllers
{

    using System;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Business;
    using Configurations;

    /// <summary>
    /// Class KenoResultController.
    /// </summary>
    public class KenoResultController : BaseController
    {
        private readonly IKenoGameService _gameService;

        public KenoResultController()
            : this(null)
        {
            var instance = string.Empty;
        }

        public KenoResultController(IKenoGameService kenoGameService)
        {
            _gameService = kenoGameService ?? new KenoGameService();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Action Result.</returns>
        public ActionResult Index()
        {
            ViewBag.date = Request["date"];
            ViewBag.language= Request["language"];
            ViewBag.customerId = Request["customerid"];
            return View(@"~\Areas\Game\Views\Keno\Result.cshtml");
        }

        /// <summary>
        /// Results the detail.
        /// </summary>
        /// <returns>Page that load the KENO result.</returns>
        public ActionResult ResultDetail()
        {
            string resultDate = Request["date"], action = "R", language = Request["language"];
            var objUserId = Request["customerid"];
            var userId = string.IsNullOrEmpty(objUserId)? 0 : Convert.ToInt32(objUserId);

            var kenoResultUrl = KenoSection.Instance.KenoResultUrl + BuildParam(resultDate, action, language, userId);
            return Redirect(kenoResultUrl);
        }

        /// <summary>
        /// Builds the parameter.
        /// </summary>
        /// <param name="resultDate">The result date.</param>
        /// <param name="action">The action.</param>
        /// <param name="language">The language.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>KENO URL to get result.</returns>
        private string BuildParam(string resultDate, string action, string language, int userId)
        {
            string container = Request.Url + "?cust=" + KenoSection.Instance.GameName +
                "&action=R&siteID=" + KenoSection.Instance.SiteId + "&lang=" + language + "&date=" + resultDate;
            var param = new StringBuilder();
            param.Append("?Authorization=" + _gameService.GetAuthorizationKey(userId));
            param.Append("&cust=" + KenoSection.Instance.GameName);
            param.Append("&siteID=" + KenoSection.Instance.SiteId);
            param.Append("&action=" + action);
            param.Append("&lang=" + language);
            param.Append("&date=" + resultDate);
            param.Append("&redirectURL=" + HttpUtility.UrlEncode(container));
            return param.ToString();
        }
    }
}
