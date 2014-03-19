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
    using System.IO;
    using System.Net;
    using System.Text;
    using Fanex.Game.Core.Extensions;
    using Fanex.Game.Keno.Configurations;
    using Fanex.Game.Keno.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Keno game service.
    /// </summary>
    public class KenoGameService : IKenoGameService
    {
        /// <summary>
        /// Gets the authorization key.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Authorization key.</returns>
        public string GetAuthorizationKey(int userId)
        {
            string authorizationKey;
            try
            {
                string authorizationUrl = KenoSection.Instance.AuthenticateUrl;
                string vendor = KenoSection.Instance.Vendor;
                string vendorKey = KenoSection.Instance.VendorKey;
                authorizationUrl = string.Format(authorizationUrl, vendor, vendorKey,  userId);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authorizationUrl);

                request.Method = "Get";
                request.Accept = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                response.Close();
                AuthorizationResult authorizationResult = JsonConvert.DeserializeObject<AuthorizationResult>(output.ToString());

                string errorCode = Convert.ToString(authorizationResult.ErrorCode);

                if (!errorCode.Equals("0"))
                {
                   throw new Exception("AuthorizationKeno Error UserID:" + userId + Environment.NewLine + "ErrorCode:" + errorCode + Environment.NewLine +
                                    "ErrorMsg:" + authorizationResult.ErrorMsg);
                   
                }
                authorizationKey = authorizationResult.Data.Authorization;
            }
            catch (Exception ex)
            {
                throw ex;
                //authorizationKey = @"h4P4!IAAAAP6x4u6g98eXN0GiWUYfhwLOARG8aWK2pZXZYBPS_Nvt4QAAAAGmGJuF358Vh5615NgIFpIFa0kZCajNE-76B9yiSs6uZ5aPoqS_cmWY2pUO_AA_aQt0LRc-HRAMUZJODFoj8ReHT2zGN6O9K3uRD_aAzlaex9xE4JhuZUZHVgqAmheR89Pqya1dZEgSXqUm7CweCq21-RXrR8JQqu3dc1jLTI_Kax9c8udzXYKtaV0Vr9JkM4OBLcNl2dErheQy5LtoKhbIgQSk1eXrfdLXRorXV3IVeigdgXVvcgDh3IIqzPPGMI1l5RXzqeQtMaJQNSkRuC5PfccqAQ3aYcPRlmKCUCojcg";
            }
            
            return authorizationKey;
        }

        /// <summary>
        /// Extend token service.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Result of extend token.</returns>
        public AuthorizationResult ExtendToken(int userId)
        {
            AuthorizationResult extendTokenResult = new AuthorizationResult();
            try
            {
                string extendTokenUrl = KenoSection.Instance.ExtendTokenUrl;
                string vendor = KenoSection.Instance.Vendor;
                string vendorKey = KenoSection.Instance.VendorKey;
                extendTokenUrl = string.Format(extendTokenUrl, vendor, vendorKey, userId);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(extendTokenUrl);

                request.Method = "Get";
                request.Accept = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                response.Close();
                extendTokenResult = JsonConvert.DeserializeObject<AuthorizationResult>(output.ToString());

                string errorCode = Convert.ToString(extendTokenResult.ErrorCode);

                if (!errorCode.Equals("0"))
                {
                    throw new Exception("Extend Token Error UserID:" + userId + Environment.NewLine + "ErrorCode:" + errorCode + Environment.NewLine +
                                     "ErrorMsg:" + extendTokenResult.ErrorMsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return extendTokenResult;
        }
    }
}