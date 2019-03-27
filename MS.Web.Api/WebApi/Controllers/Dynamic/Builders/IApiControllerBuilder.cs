using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    public interface IApiControllerBuilder
    {
        /// <summary>
        /// Controller 名称
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// 动态控制器服务接口类型
        /// </summary>
        Type ServiceInterfaceType { get; }

        /// <summary>
        /// 
        /// </summary>
        IFilter[] Filters { get; set; }

        bool IsApiExploreEnabled { get; set; }

        bool ConventionalVerbs { get; set; }
    }

    public interface IApiControllerBuilder<T> : IApiControllerBuilder
    {
        /// <summary>
        /// 增加动作过滤器为动态Controller
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IApiControllerBuilder<T> WithFilters(params IFilter[] filters);

        /// <summary>
        /// 指定方法的定义
        /// </summary>
        /// <param name="methodName">代理类中的方法名</param>
        /// <returns></returns>
        IApiControllerBuilder<T> ForMethod(string methodName);

        IApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action);

        IApiControllerBuilder<T> WithConventionalVerbs();

        IApiControllerBuilder<T> WithApiExplorer(bool isEnabled);

        void Build();

    }
}
