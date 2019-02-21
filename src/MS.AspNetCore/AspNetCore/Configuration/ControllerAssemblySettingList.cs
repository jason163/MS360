using MS.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.AspNetCore.Configuration
{
    public class ControllerAssemblySettingList : List<MSControllerAssemblySetting>
    {
        public List<MSControllerAssemblySetting> GetSettings(Type controllerType)
        {
            return this.Where(controllerSetting => controllerSetting.Assembly == controllerType.GetAssembly()).ToList();
        }
    }
}
