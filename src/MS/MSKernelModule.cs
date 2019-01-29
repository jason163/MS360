using MS.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS
{
    /// <summary>
    /// MSModule 核心
    /// </summary>
    public sealed class MSKernelModule : MSModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
