using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Extension;
using System.Collections.Immutable;

namespace MS.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// 存储管理动态API对象信息
    /// </summary>
    public class DynamicApiControllerManager : ISingletonDependency
    {
        private readonly IDictionary<string, DynamicApiControllerInfo> _dynamicApiControllers;

        public DynamicApiControllerManager()
        {
            _dynamicApiControllers = new Dictionary<string, DynamicApiControllerInfo>();
        }

        public void Register(DynamicApiControllerInfo controllerInfo)
        {
            _dynamicApiControllers[controllerInfo.ServiceName] = controllerInfo;
        }

        public DynamicApiControllerInfo FindOrNull(string controllerName)
        {
            return _dynamicApiControllers.GetOrDefault(controllerName);
        }

        public IReadOnlyList<DynamicApiControllerInfo> GetAll()
        {
            return _dynamicApiControllers.Values.ToImmutableList();
        }
    }
}
