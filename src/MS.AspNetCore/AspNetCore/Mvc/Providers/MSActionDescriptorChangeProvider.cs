using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MS.AspNetCore.Mvc.Providers
{
    /// <summary>
    /// 提供自定义提供器来使用<see cref="ActionDescriptor"/> 集合缓存无效
    /// </summary>
    public class MSActionDescriptorChangeProvider : IActionDescriptorChangeProvider
    {
        public static MSActionDescriptorChangeProvider Instance => new MSActionDescriptorChangeProvider();

        public CancellationTokenSource TokenSource { get; private set; }

        public bool HasChanged { get; set; }

        /// <summary>
        /// 获取<see cref="ActionDescriptor"/>实例缓存失效的信号
        /// </summary>
        /// <returns></returns>
        public IChangeToken GetChangeToken()
        {
            TokenSource = new CancellationTokenSource();
            return new CancellationChangeToken(TokenSource.Token);
        }
    }
}
