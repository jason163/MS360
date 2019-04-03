using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace MS.WebApi.Controllers
{
    /// <summary>
    /// 用于创建Api controller
    /// </summary>
    public class MSApiControllerActivator : IHttpControllerActivator
    {
        private readonly IIocResolver _iocResolver;

        public MSApiControllerActivator(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controllerWrapper = _iocResolver.ResolveAsDisposable<IHttpController>(controllerType);
            request.RegisterForDispose(controllerWrapper);

            return controllerWrapper.Object;
        }
    }
}
