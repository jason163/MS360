using MS360.Web.Entity.Common;
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
    public class ShippingAddress
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int CustomerSysNo { get; set; }


        /// <summary>
        /// 是否默认
        /// </summary>
        public int? IsDefault { get; set; }


        /// <summary>
        /// 收件人名称
        /// </summary>
        public string ReceiveName { get; set; }


        /// <summary>
        /// 收件人电话
        /// </summary>
        public string ReceiveCellPhone { get; set; }


        /// <summary>
        /// 所属区域
        /// </summary>
        public int? ReceiveAreaSysNo { get; set; }

        /// <summary>
        /// 所属区域详细信息
        /// </summary>
        public Area AreaInfo { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiveAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ReceiveZip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int InUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EditUserSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EditUserName { get; set; }
    }
}
