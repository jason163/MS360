
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

    public class ProductImageDA : IProductImageDA
    {
        /// <summary>
        /// 获取单个ProductImage信息
        /// </summary>
        public List<ProductImage> LoadProductImage(int ProductCommonSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProductImage");

            //DataCommand cmd = new DataCommand("LoadProductImage");
            cmd.SetParameter("@ProductCommonSysNo", DbType.Int32, ProductCommonSysNo);
            var result = cmd.ExecuteEntityList<ProductImage>();
			return result; 
        }

        public List<ProductImage> LoadProductImageByProductSysNo(int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProductImageByProductSysNo");

            //DataCommand cmd = new DataCommand("LoadProductImageByProductSysNo");
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            var result = cmd.ExecuteEntityList<ProductImage>();
			return result; 
        }
        
    }

}
