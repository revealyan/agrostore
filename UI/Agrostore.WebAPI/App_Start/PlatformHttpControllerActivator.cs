using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;

namespace Agrostore.WebAPI.App_Start
{
    public class PlatformHttpControllerActivator : IHttpControllerActivator
    {
        #region core
        private IPlatform _platform;
        private bool _isDisposed = false;
        #endregion

        #region init
        public PlatformHttpControllerActivator(IPlatform platform)
        {
            _platform = platform;
        }
        #endregion

        #region IHttpControllerActivator
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)Activator.CreateInstance(controllerType, controllerType.GetConstructors()[0].GetParameters().Select(x => _platform.GetModules().FirstOrDefault(y => y.GetInterfaceTypes().Any(z => z == x.ParameterType))).ToArray());
        }
        #endregion
    }
}