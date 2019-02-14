using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration
{
    /// <summary>
    /// 自定义配置信息提供者接口,所有自定义配置信息提供者需要实现此接口
    /// </summary>
    public interface ICustomConfigProvider
    {
        Dictionary<string, object> GetConfig(CustomConfigProviderContext customConfigProviderContext);
    }
}
