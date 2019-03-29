using MS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    public interface IApiControllerActionBuilder
    {
        /// <summary>
        /// 当前Action关联的Controller builder
        /// </summary>
        IApiControllerBuilder Controller { get; }

        string ActionName { get; }

        MethodInfo Method { get; }

        /// <summary>
        /// 获取当前HttpVerb
        /// </summary>
        HttpVerb? Verb { get; set; }

        bool IsApiExplorerEnabled { get; set; }

        IFilter[] Filters { get; set; }

        bool DontCreate { get; set; }
    }

    /// <summary>
    /// 定义动态API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiControllerActionBuilder<T> : IApiControllerActionBuilder
    {
        /// <summary>
        /// 定义方法的Http Verb
        /// </summary>
        /// <param name="verb"></param>
        /// <returns></returns>
        IApiControllerActionBuilder<T> WithVerb(HttpVerb verb);

        /// <summary>
        /// 是否启用API Explorer
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        IApiControllerActionBuilder<T> WithApiExplorer(bool isEnabled);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        IApiControllerActionBuilder<T> ForMethod(string methodName);

        /// <summary>
        /// 告诉构建器不对方法创建Action
        /// </summary>
        /// <returns></returns>
        IApiControllerBuilder<T> DontCreateAction();

        void Build();

        IApiControllerActionBuilder<T> WithFilters(params IFilter[] filters);
    }
}
