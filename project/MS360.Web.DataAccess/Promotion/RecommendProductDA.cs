using MS360.Web.Entity.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MS.DataAccess;
using MS.Dependency;

namespace MS360.Web.DataAccess.Promotion
{
    public class RecommendProductDA : IRecommendProductDA
    {
        public List<RecommendProductInfo> GetAllRecommendProductInfo(int CommonStatus = 1)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Seckill_GetAllRecommendProductInfo");

            //DataCommand dataCommand = new DataCommand("Seckill_GetAllRecommendProductInfo");
            cmd.SetParameter("@CommonStatus", DbType.Int32, CommonStatus);
            return cmd.ExecuteEntityList<RecommendProductInfo>();
        }

    }
}
