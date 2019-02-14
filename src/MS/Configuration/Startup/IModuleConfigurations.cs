using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration.Startup
{
    /// <summary>
    /// 用于模块配置；为接口创建扩展方法
    /// </summary>
    public interface IModuleConfigurations
    {
        /// <summary>
        /// 获取MS配置对象
        /// </summary>
        IMSStartupConfiguration MSConfiguration { get; }
    }
}
