using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Module
{
    public interface IMSModuleManager
    {
        MSModuleInfo StartupModule { get; }

        IReadOnlyList<MSModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}
