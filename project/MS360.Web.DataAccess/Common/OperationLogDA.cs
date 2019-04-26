
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class OperationLogDA : IOperationLogDA
    {
        public void WriteLog(OperationLog log)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("ControlPanel_InsertOperationLog");

           // DataCommand cmd = new DataCommand("ControlPanel_InsertOperationLog");
            cmd.CommandText = cmd.CommandText.Replace("#BizObjectName#", cmd.SetSafeParameter(log.BizObjectType));
            cmd.SetParameter<OperationLog>(log);
            cmd.ExecuteNonQuery();

        }
    }
}
