using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Enums
{
    public enum ReductionUsableRange
    {
        /// <summary>
        /// 指定商品
        /// </summary>
        [Description("指定商品")]
        Product = 0,
        /// <summary>
        /// 商品总计
        /// </summary>
        [Description("商品总计")]
        TotalProduct = 1,

    }

    public enum ReductionRuleUnit
    {
        /// <summary>
        /// 个
        /// </summary>
        [Description("个")]
        Count = 0,
        /// <summary>
        /// 元
        /// </summary>
        [Description("元")]
        Money = 1,

    }
    public enum ReductionType
    {
        /// <summary>
        /// 打折
        /// </summary>
        [Description("打折")]
        Discount = 0,
        /// <summary>
        /// 减价
        /// </summary>
        [Description("减价")]
        Reduced = 1,

    }
    public enum ReductionStatus
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
}
