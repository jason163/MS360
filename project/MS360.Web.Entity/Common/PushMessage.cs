using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class PushMessage
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int CustomerSysNo { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 微信消息内容
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 微信消息模板ID
        /// </summary>
        public string ActionKey { get; set; }
        /// <summary>
        /// 自定义参数
        /// </summary>
        public string CustomerData { get; set; }
    }
}
