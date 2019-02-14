using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration
{
    /// <summary>
    /// 自定义配置提供者上下文
    /// </summary>
    public class CustomConfigProviderContext
    {
        public IIocResolver IocResolver { get; }

        public CustomConfigProviderContext(IIocResolver iocResolver)
        {
            IocResolver = iocResolver;
        }
    }
}
