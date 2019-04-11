using MS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAspNetCoreDemo.AppService
{
    public interface IFooService : IApplicationService
    {
        string Get();

        string GetString(int i);
    }

    public class FooService : IFooService
    {
        public string Get()
        {
            return "Hello World";
        }

        public string GetString(int i)
        {
            return (i + 1).ToString();
        }
    }
}
