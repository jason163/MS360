using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS360.Web.Enums;

namespace MS360.Web.Entity.Promotion
{
  public  class RecommendProductInfo
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
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 获取或设置广告结束时间
        /// </summary>
        public DateTime ?EndDate { get; set; }

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

        /// <summary>
        /// 状态，通用状态，共两种：有效，无效，删除是将状态设置为-999
        /// </summary>
        public CommonStatus CommonStatus { get; set; }

        /// <summary>
        /// 顺序，越小越优先
        /// </summary>
        public int Priority { get; set; }


        /// <summary>
        /// 业务数据主键，比如商品推荐时存放商品SysNo
        /// </summary>
        public int? BizDataSysNo { get; set; }

        /// <summary>
        /// 页面位置
        /// </summary>
        public string PagePositionID { get; set; }


        /// <summary>
        /// 页面参数，为NULL则表示该页面类型所有页面都OK;如果参数是INT，也需要转换为CHAR(20)
        /// </summary>
        public string PageID { get; set; }


        /// <summary>
        /// 市场价或参考价
        /// </summary>
        public decimal MarketPrice { get; set; }


        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal CurrentPrice { get; set; }


        /// <summary>
        /// 在售库存
        /// </summary>
        public int Q4S { get; set; }

        /// <summary>
        /// 促销计划标题
        /// </summary>
        public string PromotionTitle { get; set; }

        /// <summary>
        /// 活动商品编码
        /// </summary>
        public int? ProductSysNo { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///抢购商品默认图片
        /// </summary>
        public string DefaultImage { get; set; }
       
      
         /// <summary>
        ///商品促销语
        /// </summary>
        public string ProductNote { get; set; }
       
    }
}
