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
    public class RMAItem 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// RMA编号
        /// </summary>
        public int RMASysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }


        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductID { get; set; }


        /// <summary>
        /// 退换数量
        /// </summary>
        public int Quantity { get; set; }


    }
}
