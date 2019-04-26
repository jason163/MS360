using MS360.Web.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS360.Web.DataAccess
{
    public interface IOperationLogDA
    {
        void WriteLog(OperationLog log);
    }
}
