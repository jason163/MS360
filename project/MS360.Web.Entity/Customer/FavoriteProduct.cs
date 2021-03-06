
using MS.Application.EntityBasic;
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
    public class FavoriteProduct
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 用户编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductPic { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QF_FavoriteProduct : QueryFilter
    {

        /// <summary>
        /// 用户编号
        /// </summary>
        public int? CustomerSysNo { get; set; }


    }
}
