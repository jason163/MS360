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
    public class Area
    {
        /// <summary>
        /// 区编号
        /// </summary>
        public int? SysNo { get; set; }
        /// <summary>
        /// 区名称
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public int? ProvinceSysNo { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public int? CitySysNo { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }


    }
}
