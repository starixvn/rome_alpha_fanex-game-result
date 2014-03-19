// -----------------------------------------------------------------------
// <copyright file="KenoSection.cs" company="Nexcel">
// Steven.Nguyen
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Game.Keno.Configurations
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Keno config section.
    /// </summary>
    public class KenoSection : ConfigurationSection
    {
        private static KenoSection _instance;

       /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Error when parsing configuration section CustomerSetting - Keno.</exception>
        public static KenoSection Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (KenoSection)ConfigurationManager.GetSection("Game/Keno");
                    }
                    catch (Exception e)
                    {
                        throw new ConfigurationErrorsException("Error when parsing configuration section CustomerSetting - Keno.", e);
                    }
                }

                return _instance;
            }
        }

        [ConfigurationProperty("kenoResultUrl", IsRequired = false)]
        public string KenoResultUrl
        {
            get
            {
                return (string)base["kenoResultUrl"];
            }
        }

        [ConfigurationProperty("authenticateUrl", IsRequired = false)]
        public string AuthenticateUrl
        {
            get
            {
                return (string)base["authenticateUrl"];
            }
        }

        [ConfigurationProperty("extendTokenUrl", IsRequired = false)]
        public string ExtendTokenUrl
        {
            get
            {
                return (string)base["extendTokenUrl"];
            }
        }

        [ConfigurationProperty("vendor", IsRequired = false)]
        public string Vendor
        {
            get
            {
                return (string)base["vendor"];
            }
        }

        [ConfigurationProperty("vendorKey", IsRequired = false)]
        public string VendorKey
        {
            get
            {
                return (string)base["vendorKey"];
            }
        }

        [ConfigurationProperty("siteId", IsRequired = false)]
        public string SiteId
        {
            get
            {
                return (string)base["siteId"];
            }
        }

        [ConfigurationProperty("gameName", IsRequired = false)]
        public string GameName
        {
            get
            {
                return (string)base["gameName"];
            }
        }
    }
}
