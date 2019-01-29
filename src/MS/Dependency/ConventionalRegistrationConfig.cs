using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 注册器配置信息
    /// </summary>
    public class ConventionalRegistrationConfig
    {
        /// <summary>
        /// 是否自动安装 <see cref="IInterceptor"/> 实现
        /// </summary>
        public bool InstallInstallers { get; set; }

        /// <summary>
        /// Construct
        /// </summary>
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}
