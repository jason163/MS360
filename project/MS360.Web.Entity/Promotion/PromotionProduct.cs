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
    public class PromotionProduct
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 分组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string ProductImage { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public decimal CurrentPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal MarketPrice { get; set; }


        /// <summary>
        /// 活动编号
        /// </summary>
        public int PromotionTempSysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


    }
}
