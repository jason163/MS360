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
    public class SOItemCostDetail 
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
        /// 采购单号
        /// </summary>
        public int? POSysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int? ProductSysNo { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }


        /// <summary>
        /// 成本
        /// </summary>
        public decimal? CostPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InDate
        { get; set; }

    }
}
