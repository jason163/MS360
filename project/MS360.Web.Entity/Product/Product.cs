using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace MS360.Web.Entity
{
    /// <summary>
    /// 商品基本信息
    /// </summary>
    public class Product 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductID { get; set; }


        /// <summary>
        /// 商品组系统编号
        /// </summary>
        public int ProductCommonSysNo { get; set; }


        /// <summary>
        /// SKU的名称，默认继承商品基础信息的名称，可手动修改
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProductStatus ProductStatus { get; set; }

        /// <summary>
        /// SKU的型号
        /// </summary>
        public string SKUModel { get; set; }


        /// <summary>
        /// UPC Code
        /// </summary>
        public string UPCCode { get; set; }


        /// <summary>
        /// 重量，单位克，用于普通百货商品计算运费时使用
        /// </summary>
        public int? Weight { get; set; }


        /// <summary>
        /// SKU简要说明
        /// </summary>
        public string ProductNote { get; set; }


        /// <summary>
        /// SKU默认图片
        /// </summary>
        public string DefaultImage { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 贸易类型
        /// </summary>
        public TradeType TradeType { get; set; }


        /// <summary>
        /// 类别系统编号
        /// </summary>
        public int CategorySysNo { get; set; }


        /// <summary>
        /// 品牌系统编号
        /// </summary>
        public int BrandSysNo { get; set; }


        /// <summary>
        /// 销售时支付模式，0=款到发货，1=货到付款，2=两种都支持
        /// </summary>
        public PayMode PayMode { get; set; }


        /// <summary>
        /// 在售库存
        /// </summary>
        public int Q4S { get; set; }

        /// <summary>
        /// 商品详情描述
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// 分组属性
        /// </summary>
        public string PropertyValueDesc { get; set; }

    }
}
