
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class ProductCategoryDA : IProductCategoryDA
    {
        public static List<ProductCategory> LoadTopCategories()
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadTopCategories");

            //var cmd = new DataCommand("LoadTopCategories");
            return cmd.ExecuteEntityList<ProductCategory>();
        }

        public static List<ProductCategory> LoadCategoriesByParentCategoryCode(string parentCategoryCode)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadCategoriesByParentCategoryCode");

            //var cmd = new DataCommand("LoadCategoriesByParentCategoryCode");
            cmd.SetParameter("@ParentCategoryCode", DbType.String, parentCategoryCode);
            return cmd.ExecuteEntityList<ProductCategory>();
        }
    }
}
