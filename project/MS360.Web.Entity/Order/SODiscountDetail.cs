using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
 

namespace MS360.Web.Entity.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class SODiscountMaster
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 优惠类型
        /// </summary>
        public PromotionType PromotionType { get; set; }


        /// <summary>
        /// 活动系统编号
        /// </summary>
        public int PromotionSysNo { get; set; }
        /// <summary>
        /// 活动标题
        /// </summary>
        public string PromotionTitle { get; set; } 

        /// <summary>
        /// 折扣总额
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MerchantSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SODiscountDetail> Details { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SODiscountDetail 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 折扣主表编号
        /// </summary>
        public int MasterSysNo { get; set; }



        /// <summary>
        /// 活动规则编号
        /// </summary>
        public int? RuleSysNo { get; set; }


        /// <summary>
        /// 优惠券号码
        /// </summary>
        public string CouponCode { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 折扣数量
        /// </summary>
        public int DiscountQty { get; set; }


        /// <summary>
        /// 折扣单价
        /// </summary>
        public decimal DiscountPrice { get; set; }


    }
}
