using MS.Dependency;
using MS360.Web.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS360.Web.DataAccess
{
    public interface IOperationLogDA : ITransientDependency
    {
        void WriteLog(OperationLog log);
    }
}
