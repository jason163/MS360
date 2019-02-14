using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration.Startup
{
    public class ModuleConfigurations : IModuleConfigurations
    {
        public IMSStartupConfiguration MSConfiguration { get; private set; }

        public ModuleConfigurations(IMSStartupConfiguration msConfiguration)
        {
            MSConfiguration = msConfiguration;
        }
    }
}
