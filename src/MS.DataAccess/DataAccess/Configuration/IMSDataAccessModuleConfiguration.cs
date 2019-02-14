using System;
using System.Collections.Generic;
using System.Text;

namespace MS.DataAccess.Configuration
{
    public interface IMSDataAccessModuleConfiguration
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        string ConfigPath { get; set; }
    }
}
