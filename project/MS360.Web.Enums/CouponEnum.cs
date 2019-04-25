using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum CouponGenerateWay
    {
        /// <summary>
        /// 按消费金额
        /// </summary>
        [Description("按消费金额")]
        Consume = 0,
        /// <summary>
        /// 用户领取
        /// </summary>
        [Description("用户领取")]
        UserGet = 1,

    }
    public enum CouponProductLimitType
    {
        /// <summary>
        /// 不限制
        /// </summary>
        [Description("不限制")]
        All = 0,
        /// <summary>
        /// 按商品品类
        /// </summary>
        [Description("按商品品类")]
        Category = 1,
        /// <summary>
        /// 按指定商品限制
        /// </summary>
        [Description("按指定商品限制")]
        Item = 2,

    }
    public enum CouponGetQtyLimit
    {
        /// <summary>
        /// 只限领一张
        /// </summary>
        [Description("只限领一张")]
        OnlyOne = 0,
        /// <summary>
        /// 每天限领一张
        /// </summary>
        [Description("每天限领一张")]
        OnlyOnePerDay = 1,
        /// <summary>
        /// 不限制
        /// </summary>
        [Description("不限制")]
        UnLimit = 2,

    }
    public enum CouponUseType
    {
        /// <summary>
        /// 不限制
        /// </summary>
        [Description("不限制")]
        All = 0,
        /// <summary>
        /// 时间范围
        /// </summary>
        [Description("时间范围")]
        Range = 1,
        /// <summary>
        /// 获得后指定天数
        /// </summary>
        [Description("获得后指定天数")]
        Days = 2,

    }

    public enum CouponStatus
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        DeActived = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Actived = 1,
    }
    public enum CouponReceivingStatus
    {
        /// <summary>
        /// 已生成
        /// </summary>
        [Description("已生成")]
        Generated = 0,
        /// <summary>
        /// 已领取
        /// </summary>
        [Description("已领取")]
        Got = 1,
        /// <summary>
        /// 已使用
        /// </summary>
        [Description("已使用")]
        Used = 2,
        /// <summary>
        /// 已作废
        /// </summary>
        [Description("已作废")]
        Abandoned = 3,

    }

}
