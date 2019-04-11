using MS.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.AspNetCore.Configuration
{
    public class ControllerAssemblySettingList : List<MSControllerAssemblySetting>
    {
        /// <summary>
        /// 获取Controller对应程序集的配置信息
        /// </summary>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public List<MSControllerAssemblySetting> GetSettings(Type controllerType)
        {
            return this.Where(controllerSetting => controllerSetting.Assembly == controllerType.GetAssembly()).ToList();
        }
    }
}
