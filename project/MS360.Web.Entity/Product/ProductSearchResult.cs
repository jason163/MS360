using SolrNet.Attributes;
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
    public class ProductSearchResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> CategoryNames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> BrandNames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> CountryNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductSearchProperty> Properties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductSearchRecord> Products { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PageAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CurrentPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PageSize { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductSearchProperty
    {
        /// <summary>
        /// 
        /// </summary>
        public string PropertyKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> PropertyValues { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductSearchRecord
    {
        /// <summary>
        /// 
        /// </summary>
        [SolrUniqueKey]
        public int? ProductSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string ProductID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string PromotionTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string DefaultImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public decimal CurrentPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public decimal CashRebate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? MinQtyPerOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? TradeType { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [SolrField]
        public int BizType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? CategorySysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? C2SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string C2Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? C1SysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string C1Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? BrandSysNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string BrandName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public int? OnlineQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string CountryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string CountryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public string Property { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SolrField]
        public float SortNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TradeTypeText { get; set; }
    }
}
