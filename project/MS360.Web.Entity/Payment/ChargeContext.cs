
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using MS360.Web.Entity.Order;



namespace MS360.Web.Entity
{
    /// <summary>
    /// 支付上下文
    /// </summary>
    [Serializable]
    public class ChargeContext
    {
        /// <summary>
        /// 业务单据编号，须保证唯一
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 支付方式系统编号
        /// </summary>
        public string PaymentModeId { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public SOMaster SOInfo { get; set; }

        /// <summary>
        /// 充值信息
        /// </summary>
        public RechargeRequest RechargeInfo { get; set; }

        /// <summary>
        /// 业务参数,用于替换SOInfo,兼容订单支付和充值
        /// </summary>
        public NameValueCollection BizParams { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public NameValueCollection RequestForm { get; set; }

        /// <summary>
        /// 支付方式配置
        /// </summary>
        public PaymentSetting PaymentInfo { get; set; }

        /// <summary>
        /// 支付方式商家配置
        /// </summary>
        public PaymentModeMerchant PaymentInfoMerchant
        {
            get
            {
                PaymentModeMerchant merchant = null;
                if (this.PaymentInfo != null && this.PaymentInfo.PaymentMode != null
                    && this.PaymentInfo.PaymentMode.MerchantList != null)
                {
                    merchant = this.PaymentInfo.PaymentMode.MerchantList.FirstOrDefault();
                }
                return merchant;
            }
        }

        /// <summary>
        /// 支付来源：1：网站  2：APP 3：微信
        /// </summary>
        public int PaySource { get; set; }
        /// <summary>
        /// 支付来源的IP地址
        /// </summary>
        public string PaySourceIP { get; set; }
    }

    /// <summary>
    /// 支付方式配置
    /// </summary>
    [Serializable]
    public class PaymentSetting
    {
        /// <summary>
        /// 基础公共配置
        /// </summary>
        public PaymentBase PaymentBase { get; set; }

        /// <summary>
        /// 支付方式的具体配置
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
    }

    /// <summary>
    /// 基础公共配置
    /// </summary>
    [Serializable]
    public class PaymentBase
    {
        /// <summary>
        /// 基地址
        /// </summary>
        public string BaseUrl { get; set; }
    }

    /// <summary>
    /// 支付方式的具体配置
    /// </summary>
    [Serializable]
    public class PaymentMode
    {
        /// <summary>
        /// 支付方式系统编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// 处理程序
        /// </summary>
        public string ChargeProcessor { get; set; }
        
        /// <summary>
        /// 支付地址
        /// </summary>
        public string PaymentUrl { get; set; }

        /// <summary>
        /// 支付前台回调地址
        /// </summary>
        public string PaymentCallbackUrl { get; set; }

        /// <summary>
        /// 支付后台回调地址
        /// </summary>
        public string PaymentBgCallbackUrl { get; set; }

        /// <summary>
        /// 退款地址
        /// </summary>
        public string RefundUrl { get; set; }

        /// <summary>
        /// 退款回调地址
        /// </summary>
        public string RefundCallbackUrl { get; set; }

        /// <summary>
        /// 银行公钥证书
        /// </summary>
        public string BankCert { get; set; }

        /// <summary>
        /// 银行公钥证书密码
        /// </summary>
        public string BankCertKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PaymentModeMerchant> MerchantList { get; set; }

        /// <summary>
        /// 是否debug，0-否；1-是
        /// </summary>
        public string Debug { get; set; }
    }

    /// <summary>
    /// 商家配置
    /// </summary>
    [Serializable]
    public class PaymentModeMerchant
    {
        /// <summary>
        /// 商户的系统编号
        /// </summary>
        public int MerchantSysNo { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNO { get; set; }

        /// <summary>
        /// 商户密钥证书
        /// </summary>
        public string MerchantCert { get; set; }

        /// <summary>
        /// 商户密钥证书密码
        /// </summary>
        public string MerchantCertKey { get; set; }

        /// <summary>
        /// 货款币种
        /// </summary>
        public string CurCode { get; set; }

        /// <summary>
        /// 运费币种
        /// </summary>
        public string ShipCurrencyCode { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// 每个接口自定义配置
        /// </summary>
        public Dictionary<string, string> CustomConfigs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTSRC_NCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CBTREC_NCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayCurrencyCode { get; set; }
    }
    /// <summary>
    /// 线上支付的业务类型
    /// </summary>
    public enum PayBizType
    {
        /// <summary>
        /// 销售订单支付
        /// </summary>
        OrderPay=1,
        /// <summary>
        /// 线上充值
        /// </summary>
        Recharge=2
    }
}
