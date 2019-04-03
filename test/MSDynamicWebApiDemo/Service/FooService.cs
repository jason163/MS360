using MS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDynamicWebApiDemo.Service
{
    public interface IFooService : IApplicationService
    {
        string Do();

        string GetString(int i);
    }

    public class FooService : IFooService
    {
        public string Do()
        {
            return "Hello World";
        }

        public string GetString(int i)
        {
            return (i + 1).ToString();
        }
    }
}
