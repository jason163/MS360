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
    public class OperationLog
    {

        /// <summary>
        ///系统编号
        /// </summary>
        public int? SysNo
        {
            get;
            set;
        }

        /// <summary>
        ///业务对象类型
        /// </summary>
        public string BizObjectType
        {
            get;
            set;
        }


        /// <summary>
        ///业务操作类型
        /// </summary>
        public string BizOperationType
        {
            get;
            set;
        }

        /// <summary>
        ///业务对象Id
        /// </summary>
        public string BizObjectId
        {
            get;
            set;
        }

        /// <summary>
        ///说明
        /// </summary>
        public string OperationDesc
        {
            get;
            set;
        }
        /// <summary>
        /// 是否有日志数据
        /// </summary>
        public int HasLogData
        {
            get;
            set;
        }

        /// <summary>
        ///输入内容
        /// </summary>
        public string InputBizData
        {
            get;
            set;
        }

        /// <summary>
        ///反馈内容
        /// </summary>
        public string OutputBizData
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int InUserSysNo
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string InUserName
        {
            get;
            set;
        }
    }
}
