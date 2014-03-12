// ************************************************************************************
// <copyright file="AreaRegister.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ************************************************************************************
// <history>
//     <change who="steven.nguyen">Create/Run StyleCop.</change>
// </history>
// ************************************************************************************

namespace Fanex.Game.Core.Web.AppStart
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AreaRegister : AreaRegistration
    {
        private readonly List<string> _controllers = new List<string>();

        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <value>The name of the area.</value>
        /// <returns>The name of the area to register.</returns>
        public override string AreaName
        {
            get { return "Game"; }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        protected virtual string ModuleName
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets the module name space.
        /// </summary>
        /// <value>The module name space.</value>
        protected virtual string ModuleNameSpace
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            if (!string.IsNullOrWhiteSpace(this.ModuleName) && !string.IsNullOrWhiteSpace(this.ModuleNameSpace))
            {
                var areaName = AreaName + "_" + ModuleName;
                if (context.Routes != null && context.Routes[areaName] != null)
                {
                    return;
                }

                var controllers = new[] { ModuleNameSpace };

                context.MapRoute(
                    areaName,
                    AreaName + "/" + ModuleName + "/{controller}/{action}/{id}/{uplineId}/{groupName}",
                    new
                        {
                            action = "Index",
                            id = UrlParameter.Optional,
                            uplineId = UrlParameter.Optional,
                            groupName = UrlParameter.Optional
                        },
                        controllers);
            }
        }

        /// <summary>
        /// Registers the controller.
        /// </summary>
        /// <param name="context">The context.</param>
        protected void RegisterController(AreaRegistrationContext context)
        {
        }

        /// <summary>
        /// Registers the controller.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        protected void RegisterController(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName))
            {
                return;
            }

            _controllers.Add(controllerName);
        }
    }
}
