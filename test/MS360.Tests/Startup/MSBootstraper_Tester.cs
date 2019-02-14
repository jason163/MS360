using MS;
using MS.Module;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MS360.Tests.Startup
{
    public class MSBootstraper_Tester : TestBaseWithLocalIocManager
    {
        private readonly MSBootStrapper _bootstrapper;

        public MSBootstraper_Tester()
        {
            _bootstrapper = MSBootStrapper.Create<MyTestModule>(options =>
            {
                options.IocManager = LocalIocManager;
            });
        }

        [Fact]
        public void Should_Initialize_Bootstrapper()
        {
            _bootstrapper.Initialize();
        }
    }

    [DependsOn(typeof(MyOtherModule))]
    [DependsOn(typeof(MyAnotherModule))]
    public class MyTestModule : MyEventCounterModuleBase
    {
        private readonly MyOtherModule _otherModule;

        public MyTestModule(MyOtherModule otherModule)
        {
            _otherModule = otherModule;
        }

        public override void PreInitialize()
        {
            base.PreInitialize();
            _otherModule.PreInitializeCount.ShouldBe(1);
            _otherModule.CallMeOnStartup();
        }

        public override void Initialize()
        {
            base.Initialize();
            _otherModule.InitializeCount.ShouldBe(1);
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
            _otherModule.PostInitializeCount.ShouldBe(1);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            _otherModule.ShutdownCount.ShouldBe(0); //Depended module should be shutdown after this module
        }
    }

    public class MyOtherModule : MyEventCounterModuleBase
    {
        public int CallMeOnStartupCount { get; private set; }

        public void CallMeOnStartup()
        {
            CallMeOnStartupCount++;
        }
    }

    public class MyAnotherModule : MyEventCounterModuleBase
    {

    }

    public abstract class MyEventCounterModuleBase : MSModule
    {
        public int PreInitializeCount { get; private set; }

        public int InitializeCount { get; private set; }

        public int PostInitializeCount { get; private set; }

        public int ShutdownCount { get; private set; }

        public override void PreInitialize()
        {
            IocManager.ShouldNotBe(null);
            Configuration.ShouldNotBe(null);
            PreInitializeCount++;
        }

        public override void Initialize()
        {
            InitializeCount++;
        }

        public override void PostInitialize()
        {
            PostInitializeCount++;
        }

        public override void Shutdown()
        {
            ShutdownCount++;
        }
    }
}
