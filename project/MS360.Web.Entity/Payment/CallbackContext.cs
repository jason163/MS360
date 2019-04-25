
using System;
using System.Linq;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using MS360.Web.Entity.Order;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 支付回调上下文
    /// </summary>
    [Serializable]
    public class CallbackContext
    {
        /// <summary>
        /// 支付方式
        /// </summary>

        public string PaymentModeId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>

        public int SOSysNo { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>

        public SOMaster SOInfo { get; set; }

        /// <summary>
        /// 充值信息
        /// </summary>
        public RechargeRequest RechargeInfo { get; set; }

        /// <summary>
        /// 相应参数
        /// </summary>

        public NameValueCollection ResponseForm { get; set; }

        /// <summary>
        /// 请求
        /// </summary>

        public HttpRequest Request { get; set; }

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
                    merchant = this.PaymentInfo.PaymentMode.MerchantList.FirstOrDefault();
                return merchant;
            }
        }
    }
}
