
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
    public class ProductPropertyDA : IProductPropertyDA
    {
        /// <summary>
        /// 获取商品所有属性值信息
        /// </summary>
        public List<ProductProperty> LoadProductProperty(int ProductCommonSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadProductProperty");

            //DataCommand cmd = new DataCommand("LoadProductProperty");
            cmd.CommandText = cmd.CommandText.Replace("#ProductCommonSysNo#", cmd.SetSafeParameter(ProductCommonSysNo.ToString()));
            return cmd.ExecuteEntityList<ProductProperty>();
        }
    }

}
