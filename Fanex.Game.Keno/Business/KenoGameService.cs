// ************************************************************************************
// <copyright file="KenoGameService.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Keno.Business
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using Fanex.Game.Core.Extensions;
    using Fanex.Game.Keno.Configurations;
    using Fanex.Game.Keno.Constants;
    using Fanex.Game.Keno.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Keno game service.
    /// </summary>
    public class KenoGameService : IKenoGameService
    {
        private readonly Dictionary<int, int> VendorProduct = new Dictionary<int, int>
        {
            {ProductIdConstants.Keno,1},
            {ProductIdConstants.Lottery,28},
            {ProductIdConstants.TableGames,40},
        };

        /// <summary>
        /// Gets the authorization key.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Authorization key.</returns>
        public string GetAuthorizationKey(int userId, int productId)
        {
            string authorizationUrl = KenoSection.Instance.AuthenticateUrl;
            string vendor = KenoSection.Instance.Vendor;
            string vendorKey = KenoSection.Instance.VendorKey;
            authorizationUrl = string.Format(authorizationUrl, vendor, vendorKey, userId, GetVendorProduct(productId));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authorizationUrl);

            request.Method = "Get";
            request.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();

            var apiResponse = output.ToString();
            AuthorizationResult authorizationResult = JsonConvert.DeserializeObject<AuthorizationResult>(apiResponse);

            string errorCode = Convert.ToString(authorizationResult.ErrorCode);

            if (!errorCode.Equals("0"))
            {
                throw new Exception("AuthorizationKeno Error UserID:" + userId + Environment.NewLine +
                    "ErrorCode:" + errorCode + Environment.NewLine +
                    "ErrorMsg:" + authorizationResult.ErrorMsg + Environment.NewLine +
                    "Request URL:" + authorizationUrl + Environment.NewLine +
                    "API Response: " + apiResponse);
            }

            return authorizationResult.Data.Authorization;
        }

        /// <summary>
        /// Extend token service.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Result of extend token.</returns>
        public AuthorizationResult ExtendToken(int userId, int productId)
        {
            AuthorizationResult extendTokenResult = new AuthorizationResult();
            string extendTokenUrl = KenoSection.Instance.ExtendTokenUrl;
            string vendor = KenoSection.Instance.Vendor;
            string vendorKey = KenoSection.Instance.VendorKey;
            extendTokenUrl = string.Format(extendTokenUrl, vendor, vendorKey, userId, GetVendorProduct(productId));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(extendTokenUrl);

            request.Method = "Get";
            request.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();

            var apiResponse = output.ToString();
            extendTokenResult = JsonConvert.DeserializeObject<AuthorizationResult>(apiResponse);

            string errorCode = Convert.ToString(extendTokenResult.ErrorCode);

            if (!errorCode.Equals("0"))
            {
                throw new Exception("Extend Token Error UserID:" + userId + Environment.NewLine +
                    "ErrorCode:" + errorCode + Environment.NewLine +
                    "ErrorMsg:" + extendTokenResult.ErrorMsg + Environment.NewLine +
                    "Request URL:" + extendTokenUrl + Environment.NewLine +
                    "API Response: " + apiResponse);
            }

            return extendTokenResult;
        }

        private int GetVendorProduct(int productId)
            => VendorProduct[productId];
    }
}