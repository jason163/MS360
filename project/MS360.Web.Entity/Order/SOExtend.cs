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
    public class SOExtend
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 真实姓名
        /// </summary>
        public string AuthRealName { get; set; }


        /// <summary>
        /// 性别，0=女，1=男
        /// </summary>
        public int? AuthGender { get; set; }


        /// <summary>
        /// 证件类型，0=身份证，1=护照
        /// </summary>
        public AuthIDCardType? AuthIDCardType { get; set; }


        /// <summary>
        /// 证件号码
        /// </summary>
        public string AuthIDCardNumber { get; set; }


        /// <summary>
        /// 出生日期
        /// </summary>
        public string AuthBirthday { get; set; }


        /// <summary>
        /// 电话号码
        /// </summary>
        public string AuthPhoneNumber { get; set; }


        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string AuthEmail { get; set; }


        /// <summary>
        /// 证件地址
        /// </summary>
        public string AuthAddress { get; set; }


        /// <summary>
        /// 地址邮编
        /// </summary>
        public string AuthZipCode { get; set; }


        /// <summary>
        /// 发货时间，仓库返回
        /// </summary>
        public DateTime? DeliveryDate { get; set; }


        /// <summary>
        /// 快递单号，仓库返回
        /// </summary>
        public string DeliveryTrackingNumber { get; set; }


        /// <summary>
        /// 订单重量，仓库返回
        /// </summary>
        public decimal? SOWeight { get; set; }


        /// <summary>
        /// 商品总成本金额，仓库返回
        /// </summary>
        public decimal? ProductTotalCostAmt { get; set; }


        /// <summary>
        /// 运费总成本金额，仓库返回
        /// </summary>
        public decimal? ShippingTotalCostAmt { get; set; }


        /// <summary>
        /// 订单作废原因ID
        /// </summary>
        public string VoidReasonID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EditDate { get; set; }
    }
}
