using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
 

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductPrice 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 商品系统编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 商品组系统编号
        /// </summary>
        public int ProductCommonSysNo { get; set; }


        /// <summary>
        /// 市场价或参考价
        /// </summary>
        public decimal MarketPrice { get; set; }


        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal CurrentPrice { get; set; }


        /// <summary>
        /// 预留，订金金额
        /// </summary>
        public decimal? DepositPrice { get; set; }


        /// <summary>
        /// 每单购买下限
        /// </summary>
        public int MinQtyPerOrder { get; set; }


        /// <summary>
        /// 每单购买上限
        /// </summary>
        public int MaxQtyPerOrder { get; set; }


        /// <summary>
        /// 赠送积分
        /// </summary>
        public int Point { get; set; }


        /// <summary>
        /// 购买增量数，默认是1，不为1时，每次增减都是增量数的倍数。
        /// </summary>
        public int IncreaseCount { get; set; }


        /// <summary>
        /// 商品数量单位，默认是件
        /// </summary>
        public string ProductUnit { get; set; }


    }
}
