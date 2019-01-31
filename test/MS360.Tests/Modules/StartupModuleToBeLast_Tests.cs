using MS;
using MS.Module;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MS360.Tests.Modules
{
    public class StartupModuleToBeLast_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void StartupModule_ShouldBe_LastModule()
        {
            //Arrange
            var bootstrapper = MSBootStrapper.Create<MyStartupModule>(options =>
            {
                options.IocManager = LocalIocManager;
            });
            bootstrapper.Initialize();

            //Act
            var modules = bootstrapper.IocManager.Resolve<IMSModuleManager>().Modules;

            //Assert
            modules.Count.ShouldBe(4);

            modules.Any(m => m.Type == typeof(MSKernelModule)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyStartupModule)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyModule1)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyModule2)).ShouldBeTrue();

            var startupModule = modules.Last();

            startupModule.Type.ShouldBe(typeof(MyStartupModule));
        }

        [DependsOn(typeof(MyModule1), typeof(MyModule2))]
        public class MyStartupModule : MSModule { }

        public class MyModule1 : MSModule { }

        public class MyModule2 : MSModule { }
    }
}
