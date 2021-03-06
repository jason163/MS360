


using MS.Application.EntityBasic;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class QF_ShippingAddress  : QueryFilter
    {

        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int? CustomerSysNo { get; set; }


        /// <summary>
        /// 是否默认
        /// </summary>
        public int? IsDefault { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
	public class QR_ShippingAddress
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int? SysNo { get; set; }


        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int? CustomerSysNo { get; set; }


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
        /// 收货地址
        /// </summary>
        public string ReceiveAddress { get; set; }

        /// <summary>
        /// 地区名称，组合了省市区，如：四川省成都市高新区
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ReceiveZip { get; set; }


    }
}

