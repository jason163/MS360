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
    public class PromotionTemplates
    {

        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }


        /// <summary>
        /// 促销模板名称
        /// </summary>
        public string Name { get; set; }




        /// <summary>
        /// 默认图片
        /// </summary>
        public string DefaultImage { get; set; }


        /// <summary>
        /// 开始时间  
        /// </summary>
        public DateTime? StartDate { get; set; }


        /// <summary>
        /// 结束时间  
        /// </summary>
        public DateTime? EndDate { get; set; }


    }
}
