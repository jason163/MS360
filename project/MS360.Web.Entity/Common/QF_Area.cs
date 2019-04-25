using MS.BasicModel;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class QF_Area : QueryFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public int? ProvinceSysNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? CitySysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CommonStatus? Status { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QR_Area
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if(ProvinceSysNo.HasValue && CitySysNo.HasValue)
                {
                    return DistrictName;
                }
                else if(ProvinceSysNo.HasValue &&!CitySysNo.HasValue)
                {
                    return CityName;
                }
                else if(!ProvinceSysNo.HasValue&&!CitySysNo.HasValue)
                {
                    return ProvinceName;
                }
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            get
            {
                if (ProvinceSysNo.HasValue && CitySysNo.HasValue)
                {
                    return 3;
                }
                else if (ProvinceSysNo.HasValue && !CitySysNo.HasValue)
                {
                    return 2;
                }
                else if (!ProvinceSysNo.HasValue && !CitySysNo.HasValue)
                {
                    return 1;
                }
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LevelStr
        {
            get
            {
                if(Level==1)
                {
                    return "省";
                }
                else if(Level==2)
                {
                    return "市";
                }
                else if (Level ==3)
                {
                    return "区县";
                }
                return "";
            }
        }
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
        /// <summary>
        /// 区名称
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// 状态，通用状态，共两种：有效，无效，删除是将状态设置为-999
        /// </summary>
        public CommonStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string StatusStr
        //{
        //    get { return EnumHelper.GetDescription(Status); }
        //}
    }
    /// <summary>
    /// 
    /// </summary>
    public class QR_Saler
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeName { get; set; }
    }
}
