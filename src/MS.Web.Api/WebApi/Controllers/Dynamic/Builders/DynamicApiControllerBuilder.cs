using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 生产动态api controller 为任意类型
    /// </summary>
    public class DynamicApiControllerBuilder : IDynamicApiControllerBuilder
    {
        private readonly IIocResolver _iocResolver;

        public DynamicApiControllerBuilder(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        /// <summary>
        /// 为指定类型生成一个新的动态Controller
        /// </summary>
        /// <typeparam name="T">被代理对象类型</typeparam>
        /// <param name="serviceName">Api Controller服务名称</param>
        /// <returns></returns>
        public IApiControllerBuilder<T> For<T>(string serviceName)
        {
            return new ApiControllerBuilder<T>(serviceName, _iocResolver);
        }

        public IBatchApiControllerBuilder<T> ForAll<T>(Assembly assembly, string servicePrefix)
        {
            return new BatchApiControllerBuilder<T>(_iocResolver, this, assembly, servicePrefix);
        }
    }
}
