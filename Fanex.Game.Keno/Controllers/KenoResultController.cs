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
    using System.Collections.Generic;
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
        private readonly Dictionary<int, string> GamesName = new Dictionary<int, string>
        {
            { ProductIdConstants.Lottery, KenoSection.Instance.LotteryGameName},
            { ProductIdConstants.Keno, KenoSection.Instance.KenoGameName},
            { ProductIdConstants.TableGames, KenoSection.Instance.TableGamesGameName}
        };

        private readonly Dictionary<int, string> ResultUrls = new Dictionary<int, string>
        {
            { ProductIdConstants.Lottery, KenoSection.Instance.LotteryResultUrl},
            { ProductIdConstants.Keno, KenoSection.Instance.KenoResultUrl},
            { ProductIdConstants.TableGames, KenoSection.Instance.TableGamesResultUrl}
        };

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

        public ActionResult ResultDetail()
        {
            string resultDate = Request["date"], action = "R", language = Request["language"];
            var objUserId = Request["customerid"];
            var objProductId = Request["productId"];
            var userId = string.IsNullOrEmpty(objUserId) ? 0 : Convert.ToInt32(objUserId);
            var productId = string.IsNullOrEmpty(objProductId) ? 0 : Convert.ToInt32(objProductId);
            var device = Request["device"];

            var resultUrl = GetResultUrl(productId);
            resultUrl = resultUrl + (resultUrl.Contains("?") ? "&" : "?") + BuildParam(resultDate, action, language, userId, productId, device);
            if (KenoSection.Instance.IsDebug == "1")
            {
                throw new Exception("Result URL Request UserID:" + userId + Environment.NewLine +
                        "Request URL:" + resultUrl + Environment.NewLine);
            }

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

        private string BuildParam(
            string resultDate,
            string action,
            string language,
            int userId,
            int productId,
            string device)
        {
            string container = Request.Url.ToString();
            var param = new StringBuilder();

            param.Append("Authorization=" + _gameService.GetAuthorizationKey(userId, productId));
            param.Append("&cust=" + GetGameName(productId));
            param.Append("&siteID=" + KenoSection.Instance.SiteId);
            param.Append("&action=" + action);
            param.Append("&lang=" + GetVendorLanguage(language));
            param.Append("&date=" + resultDate);
            param.Append("&st=B");
            if (!string.IsNullOrEmpty(device))
            {
                param.Append("&app=" + device);
            }

            param.Append("&redirectURL=" + HttpUtility.UrlEncode(container));

            return param.ToString();
        }

        private string GetResultUrl(int productId)
            => ResultUrls[productId];

        private string GetGameName(int productId)
            => GamesName[productId];

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
