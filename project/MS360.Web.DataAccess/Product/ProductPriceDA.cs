
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;

namespace MS360.Web.DataAccess
{
    public class ProductPriceDA : IProductPriceDA
    {
        /// <summary>
        /// 获取单个ProductPrice信息
        /// </summary>
        public ProductPrice LoadProductPrice(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProductPrice");

            //DataCommand cmd = new DataCommand("LoadProductPrice");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            ProductPrice result = cmd.ExecuteEntity<ProductPrice>();
			return result; 
        }

        public List<ProductPrice> LoadProductPrice(IEnumerable<int> productSysNoList)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("ProductPrice_GetByProdcutSysNos");

            if (productSysNoList == null || productSysNoList.Count() == 0) return null;
            //DataCommand cmd = new DataCommand("ProductPrice_GetByProdcutSysNos");
            cmd.CommandText = cmd.CommandText.Replace("#ProductSysNos#", cmd.SetSafeParameter(string.Join(",", productSysNoList)));
            return cmd.ExecuteEntityList<ProductPrice>();
        }

    }

}
