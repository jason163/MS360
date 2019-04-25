using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MS360.Web.Entity.Payment
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("xml")]
    public class WXPayResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("prepay_id")]
        public string PrepayId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }
    }
}
