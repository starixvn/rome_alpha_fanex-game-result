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
    using Constants;

    /// <summary>
    /// Class KenoResultController.
    /// </summary>
    public class KenoResultController : BaseController
    {
        private readonly IKenoGameService _gameService;

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
            ViewBag.language = Request["language"];
            ViewBag.customerId = Request["customerid"];
            ViewBag.productId = Request["productId"];

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

            var objProductId = Request["productId"];

            var userId = string.IsNullOrEmpty(objUserId) ? 0 : Convert.ToInt32(objUserId);
            var productId = string.IsNullOrEmpty(objProductId) ? 0 : Convert.ToInt32(objProductId);

            var resultUrl = GetResultUrl(productId) +
                BuildParam(resultDate, action, language, userId, productId);

            return Redirect(resultUrl);
        }

        /// <summary>
        /// Extend token.
        /// </summary>
        ///<param name="userId">The user identifier.</param>
        /// <returns>Result of extend action.</returns>
        [HttpPost]
        public JsonResult ExtendToken(int userId, int productId)
        {
            var result = _gameService.ExtendToken(userId, productId);
            return Json(result);
        }

        /// <summary>
        /// Builds the parameter.
        /// </summary>
        /// <param name="resultDate">The result date.</param>
        /// <param name="action">The action.</param>
        /// <param name="language">The language.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>KENO URL to get result.</returns>
        private string BuildParam(
            string resultDate,
            string action,
            string language,
            int userId,
            int productId)
        {
            string container = Request.Url.ToString();
            var param = new StringBuilder();

            param.Append("?Authorization=" + _gameService.GetAuthorizationKey(userId, productId));
            param.Append("&cust=" + KenoSection.Instance.GameName);
            param.Append("&siteID=" + KenoSection.Instance.SiteIds);
            param.Append("&action=" + action);
            param.Append("&lang=" + GetVendorLanguage(language));
            param.Append("&date=" + resultDate);
            param.Append("&st=B");
            param.Append("&redirectURL=" + HttpUtility.UrlEncode(container));

            return param.ToString();
        }

        private string GetResultUrl(int productId)
        {
            if (productId == 28)
            {
                return KenoSection.Instance.LotteryResultUrl;
            }

            return KenoSection.Instance.KenoResultUrl;
        }

        private string GetVendorLanguage(string languageKey)
        {
            var language = languageKey.ToLowerInvariant();

            switch (language)
            {
                case "ct":
                    return "ch";
                case "cs":
                    return "cs";
                case "th":
                    return "th";
                case "j":
                    return "jp";
                case "ko":
                    return "ko";
                case "vi":
                    return "vn";
                default:
                    return "en";
            }
        }
    }
}
