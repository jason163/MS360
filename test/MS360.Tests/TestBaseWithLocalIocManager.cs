using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS360.Tests
{
    public abstract class TestBaseWithLocalIocManager : IDisposable
    {
        protected IIocManager LocalIocManager;

        public TestBaseWithLocalIocManager()
        {
            LocalIocManager = new IocManager();
        }

        public virtual void Dispose()
        {
            LocalIocManager.Dispose();
        }
    }
}
