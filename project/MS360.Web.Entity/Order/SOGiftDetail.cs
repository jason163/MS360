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
    public class SOGiftDetail 
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
        /// 活动系统编号
        /// </summary>
        public int PromotionSysNo { get; set; }


        /// <summary>
        /// 赠品编号
        /// </summary>
        public int GiftProductSysNo { get; set; }


        /// <summary>
        /// 赠品数量
        /// </summary>
        public int GiftProductQty { get; set; }


        /// <summary>
        /// 赠品价格，如果赠品价格不为0则为加购
        /// </summary>
        public decimal GiftProductPrice { get; set; }


    }
}
