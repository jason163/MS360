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
    public class SOItem 
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
        /// Item类型,0=Common=普通商品,1=Gift=赠品,2=AddBuy=加购商品
        /// </summary>
        public SOItemType ItemType { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductID { get; set; }


        /// <summary>
        /// 原始价格
        /// </summary>
        public decimal OriginPrice { get; set; }


        /// <summary>
        /// 当前价格，原始价格扣除掉了商品折扣后的价格
        /// </summary>
        public decimal CurrentPrice { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }


        /// <summary>
        /// 赠送积分
        /// </summary>
        public int SendPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TradeType { get; set; }
    }
}
