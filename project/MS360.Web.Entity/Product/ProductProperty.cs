using MS360.Web.Enums;
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
    public class ProductPropertyListInfo
    {
        /// <summary>
        /// 获取或设置商品属性组信息
        /// </summary>
        public List<ProductProperty> PropertyList { get; set; }
    }

    /// <summary>
    /// 商品属性信息
    /// </summary>
    public class ProductProperty 
    {
        /// <summary>
        /// 获取或设置商品SysNo
        /// </summary>
        public int ProductSysNo { get; set; }

        /// <summary>
        /// 获取或设置商品 Code
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 获取或设置商品当前价格
        /// </summary>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// 获取或设置商品当前状态
        /// </summary>
        public ProductStatus ProStatus { get; set; }

        /// <summary>
        /// 获取或设置商品默认图片
        /// </summary>
        public string DefaultImage { get; set; }
        
        /// <summary>
        /// 获取或设置属性名称编号
        /// </summary>
        public int ParentPropertySysNo { get; set; }

        /// <summary>
        /// 获取或设置属性名称
        /// </summary>
        public string ParentPropertyName { get; set; }
        
        /// <summary>
        /// 获取或设置属性是否为聚集属性
        /// </summary>
        public string ParentIsPloymeric { get; set; }

        /// <summary>
        /// 获取或设置属性值编号
        /// </summary>
        public int ParentValueSysNo { get; set; }

        /// <summary>
        /// 获取或设置属性值
        /// </summary>
        public string ParentValue { get; set; }

        /// <summary>
        /// 获取或设置属性值排序
        /// </summary>
        public int ParentPriority { get; set; }
        
        /// <summary>
        /// 获取或设置属性名称编号
        /// </summary>
        public int PropertySysNo { get; set; }
        /// <summary>
        /// 获取或设置属性名称
        /// </summary>
        public string PropertyName { get; set; }
        
        /// <summary>
        /// 获取或设置属性是否为聚集属性
        /// </summary>
        public string IsPloymeric { get; set; }

        /// <summary>
        /// 获取或设置属性值编号
        /// </summary>
        public int ValueSysNo { get; set; }

        /// <summary>
        /// 获取或设置属性值
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// 获取或设置类型 2：存在第一第二属性 1：仅第一属性
        /// </summary>
        public int Type { get; set; }

    }
}
