using Castle.DynamicProxy;
using MS.WebApi.Controllers.Dynamic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MS.WebApi.Controllers.Dynamic.Interceptors
{
    /// <summary>
    /// 动态Api 拦截器,会拦截所有action的调用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MSDynamicApiControllerInterceptor<T> : IInterceptor
    {
        /// <summary>
        /// 被代理的真实对象实例
        /// </summary>
        private readonly T _proxiedObject;

        public MSDynamicApiControllerInterceptor(T proxiedObject)
        {
            _proxiedObject = proxiedObject;
        }

        public void Intercept(IInvocation invocation)
        {
            if (DynamicApiControllerActionHelper.IsMethodOfType(invocation.Method, typeof(T)))
            {
                try
                {
                    invocation.ReturnValue = invocation.Method.Invoke(_proxiedObject, invocation.Arguments);
                }catch(TargetInvocationException targetInvocation)
                {
                    if(targetInvocation.InnerException != null)
                    {
                        ExceptionDispatchInfo.Capture(targetInvocation.InnerException).Throw();
                    }
                    throw;
                }
            }
            else
            {
                // 正常调用api controller的方法
                invocation.Proceed();
            }
        }
    }
}
