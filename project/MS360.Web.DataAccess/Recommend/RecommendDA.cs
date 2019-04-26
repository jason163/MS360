using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class RecommendDA : IRecommendDA
    {
        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="pageID">页面ID</param>
        /// <param name="pageType">页面类型</param>
        /// <param name="positionID">广告位ID</param>
        /// <returns>广告信息列表</returns>
        public List<PageRecommendInfo> GetBannerInfoByPositionID(int? pageID, PageType pageType, BannerPosition? positionID)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>();
            dataCommand.CreateCommand("Content_GetBannerInfoByPositionID");

            ///DataCommand dataCommand = new DataCommand("Content_GetBannerInfoByPositionID");

            dataCommand.SetParameter("@PageID", DbType.AnsiStringFixedLength, pageID);
            dataCommand.SetParameter("@PageType", DbType.Int32, pageType);
            dataCommand.SetParameter("@PositionID", DbType.String, positionID);

            List<PageRecommendInfo> entitys = dataCommand.ExecuteEntityList<PageRecommendInfo>();
            return entitys;
        }
    }
}
