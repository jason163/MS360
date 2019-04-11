using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method)]
    public class RemoteServiceAttribute : Attribute
    {
    }
}
