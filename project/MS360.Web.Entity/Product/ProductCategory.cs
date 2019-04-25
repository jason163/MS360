using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// 
        /// </summary>
        public int? CategorySysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParentCategoryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DefaultImage { get; set; }
    }
}
