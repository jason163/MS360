using System;
using System.Collections.Generic;
using System.Text;

namespace MS.DataAccess.Configuration
{
    /// <summary>
    /// DataAccess 模块配置信息
    /// </summary>
    public class MSDataAccessModuleConfiguration : IMSDataAccessModuleConfiguration
    {
        public string ConfigPath { get; set; }

        public MSDataAccessModuleConfiguration()
        {
            ConfigPath = @"Configuration\Data";
        }
    }
}
