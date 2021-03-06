using MS.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
 

namespace MS360.Web.Entity.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class SOLogistic 
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 配送类型
        /// </summary>
        public string ShipTypeID { get; set; }


        /// <summary>
        /// 快递单号
        /// </summary>
        public string WaybillNumber { get; set; }


        /// <summary>
        /// 物流信息内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SOLogisticsEntry> EntryList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Body))
                {
                    return XmlSerializationHelper.XmlDeserialize<List<SOLogisticsEntry>>(Body);
                }
                return null;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SOLogisticsEntry
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the scan.
        /// </summary>
        /// <value>
        /// The type of the scan.
        /// </value>
        public string ScanType
        {
            get;
            set;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class SOLog 
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int SOSysNo { get; set; }


        /// <summary>
        /// 操作类型
        /// </summary>
        public SOLogAction Action { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }


        /// <summary>
        /// 操作员系统编号
        /// </summary>
        public int OperatorSysNo { get; set; }


        /// <summary>
        /// 操作员显示名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InDate { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SOLogAction
    {
        /// <summary>
        /// 作废
        /// </summary>
        [Description("订单已作废")]
        Void = -1,
        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建订单成功")]
        Create = 0,
        /// <summary>
        /// 已付款待出库
        /// </summary>
        [Description("已付款待出库")]
        AuditPass = 100,
        /// <summary>
        /// 服务型商品,点到店消费后变成消费中
        /// </summary>
        [Description("订单消费中")]
        Service = 101,
        /// <summary>
        /// 开始拣货
        /// </summary>
        [Description("开始拣货")]
        Picking = 200,
        /// <summary>
        /// 发货
        /// </summary>
        [Description("订单已发货")]
        Shipping = 300,
        /// <summary>
        /// 跨境订单推送
        /// </summary>
        [Description("跨境订单推送")]
        PushOrder = 400,
        /// <summary>
        /// 跨境订单已出库
        /// </summary>
        [Description("跨境订单已出库")]
        OutputWarehouse = 500,
        /// <summary>
        /// 跨境订单已申报
        /// </summary>
        [Description("跨境订单已申报")]
        Declare = 600,
        /// <summary>
        /// 跨境订单已出关
        /// </summary>
        [Description("跨境订单已出关")]
        OutputCustoms = 700,
        /// <summary>
        /// 订单已完成
        /// </summary>
        [Description("订单已完成")]
        Complete = 800,
    }

}
