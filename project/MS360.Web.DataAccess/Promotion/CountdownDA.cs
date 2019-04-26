
using MS360.Web.Entity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.DataAccess;
using MS.Dependency;

namespace MS360.Web.DataAccess
{
    public class CountdownDA : ICountdownDA
    {
        public static List<CountdownInfo> GetAllCountDown(int CountdownStatus = 10)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Seckill_GetAllCountDown");

            //DataCommand dataCommand = new DataCommand("Seckill_GetAllCountDown");
            cmd.SetParameter("@CountdownStatus", DbType.Int32, CountdownStatus);
            return cmd.ExecuteEntityList<CountdownInfo>();
        }

        public CountdownInfo LoadCountdown(int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Seckill_LoadCountDown");

            //DataCommand dataCommand = new DataCommand("Seckill_LoadCountDown");
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteEntity<CountdownInfo>();
        }
        public List<CountdownInfo> LoadCountdown(IEnumerable<int> productSysNoList)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Countdown_GetByProductSysNos");

            if (productSysNoList == null || productSysNoList.Count() == 0) return null;
            //DataCommand cmd = new DataCommand("Countdown_GetByProductSysNos");
            cmd.CommandText = cmd.CommandText.Replace("#ProductSysNos#", cmd.SetSafeParameter(string.Join(",", productSysNoList)));
            return cmd.ExecuteEntityList<CountdownInfo>();
        }
    }
}
