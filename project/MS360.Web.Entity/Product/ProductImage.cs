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
    public class ProductImage 
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
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }


        /// <summary>
        /// 预留,图片组
        /// </summary>
        public int? ImageGroupID { get; set; }


        /// <summary>
        /// 图片说明
        /// </summary>
        public string ImageTips { get; set; }


        /// <summary>
        /// 优先级，越小越高
        /// </summary>
        public int Priority { get; set; }


        /// <summary>
        /// 是否为全组商品默认图片
        /// </summary>
        public int IsCommonDefault { get; set; }


        /// <summary>
        /// 是否为当前商品默认图片
        /// </summary>
        public int IsProductDefault { get; set; }


    }
}
