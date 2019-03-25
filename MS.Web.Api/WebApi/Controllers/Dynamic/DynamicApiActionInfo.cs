using MS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// 存储Controller中Action信息
    /// </summary>
    public class DynamicApiActionInfo
    {
        /// <summary>
        /// 控制器中Action名称
        /// </summary>
        public string ActionName { get; private set; }

        /// <summary>
        /// 被动态调用的方法
        /// </summary>
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// 调用方式
        /// </summary>
        public HttpVerb Verb { get; private set; }

        /// <summary>
        /// 动态方法的过滤条件
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// 动态API方法能被探测
        /// </summary>
        public bool? IsApiExplorerEnabled { get; set; }

        /// <summary>
        /// 构造函数  <see cref="DynamicApiActionInfo"/>.
        /// </summary>
        /// <param name="actionName">方法名</param>
        /// <param name="verb">调用方式</param>
        /// <param name="method">调用方法信息</param>
        /// <param name="filters">过滤条件</param>
        /// <param name="isApiExplorerEnabled">是否被探测</param>
        public DynamicApiActionInfo(
            string actionName,
            HttpVerb verb,
            MethodInfo method,
            IFilter[] filters = null,
            bool? isApiExplorerEnabled = null)
        {
            ActionName = actionName;
            Verb = verb;
            Method = method;
            IsApiExplorerEnabled = isApiExplorerEnabled;
            Filters = filters ?? new IFilter[] { }; 
        }
    }
}
