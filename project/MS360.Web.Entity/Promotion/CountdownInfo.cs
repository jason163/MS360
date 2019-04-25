using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 限时抢购
    /// </summary>
    public class CountdownInfo
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int? SysNo { get; set; }

        /// <summary>
        /// 活动状态
        /// </summary>
        public int? Status { get; set; }

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
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 促销时商品的卖价
        /// </summary>
        public decimal? CountDownCurrentPrice { get; set; }

        /// <summary>
        /// 促销时商品折扣
        /// </summary>
        public decimal? CountDownCashRebate { get; set; }

        /// <summary>
        /// 促销活动赠送积分数量
        /// </summary>
        public int? CountDownPoint { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        public decimal SnapShotCurrentPrice { get; set; }

        /// <summary>
        /// 商品原立减金额
        /// </summary>
        public decimal SnapShotCashRebate { get; set; }

        /// <summary>
        /// 商品原赠送积分
        /// </summary>
        public decimal SnapShotPoint { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }

        /// <summary>
        /// 售完即止
        /// </summary>
        public int IsEndIfNoQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaxPerOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CountDownTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SoldQty { get; set; }
    }
}
