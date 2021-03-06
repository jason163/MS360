
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

    public class ProductDA : IProductDA
    {
        /// <summary>
        /// 获取单个Product信息
        /// </summary>
        public Product LoadProduct(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProduct");

            //DataCommand cmd = new DataCommand("LoadProduct");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            Product result = cmd.ExecuteEntity<Product>();
            return result;
        }

        /// <summary>
        /// 获取单个Product信息
        /// </summary>
        public List<Product> LoadProduct(IEnumerable<int> productSysNoList)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Product_LoadBySysNos");

            if (productSysNoList == null || productSysNoList.Count() == 0) return null;
            //DataCommand cmd = new DataCommand("Product_LoadBySysNos");
            cmd.CommandText = cmd.CommandText.Replace("#ProductSysNos#", cmd.SetSafeParameter(string.Join(",", productSysNoList)));
            List<Product> productList = cmd.ExecuteEntityList<Product>();

            return productList;
        }

    }

}
