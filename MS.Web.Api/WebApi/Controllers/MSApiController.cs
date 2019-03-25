using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace MS.WebApi.Controllers
{
    /// <summary>
    /// 所有MS框架API控件器基础类
    /// </summary>
    public abstract class MSApiController : ApiController
    {
        /// <summary>
        /// 日志引用
        /// </summary>
        public ILogger Logger { get; set; }

        protected MSApiController()
        {
            Logger = NullLogger.Instance;
        }
    }
}
