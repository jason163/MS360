using System;
using System.Collections.Generic;
using System.Text;
using MS.DataAccess.Configuration;

namespace MS.DataAccess.DbProvider
{
    public interface IDbConfigProvider
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        DBConfig ConfigSetting();
    }
}
