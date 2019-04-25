using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class PageRecommendInfo
    {
        /// <summary>
        /// 获取或设置系统编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 获取或设置广告标题
        /// </summary>
        public string BannerTitle { get; set; }
        /// <summary>
        /// 获取或设置广告文字信息
        /// </summary>
        public string BannerText { get; set; }
        /// <summary>
        /// 获取或设置广告资源文件URL
        /// </summary>
        public string BannerSrcUrl { get; set; }
        
        /// <summary>
        /// 获取或设置广告对应链接
        /// </summary>
        public string BannerLinkUrl { get; set; }


        /// <summary>
        /// 获取或设置广告开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 获取或设置广告结束时间
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 获取或设置广告宽度
        /// </summary>
        public int SizeWidth { get; set; }
        /// <summary>
        /// 获取或设置广告高度
        /// </summary>
        public int SizeHeight { get; set; }

        /// <summary>
        /// 位置ID
        /// </summary>
        public BannerPosition PositionID { get; set; }

        /// <summary>
        /// 获取或设置广告类型
        /// </summary>
        public string RecommendType { get; set; }
    }
}
