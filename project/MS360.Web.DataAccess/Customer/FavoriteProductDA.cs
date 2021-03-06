
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS360.Web.DataAccess.Customer
{

    public class FavoriteProductDA : IFavoriteProductDA
    {

        /// <summary>
        /// 创建FavoriteProduct信息
        /// </summary>
        public   int InsertFavoriteProduct(FavoriteProduct entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); 
            cmd.CreateCommand("InsertFavoriteProduct");

            //DataCommand cmd = new DataCommand("InsertFavoriteProduct");
            cmd.SetParameter<FavoriteProduct>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }

        public   int IsFavoriteProduct(int customerSysNo,int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("IsFavoriteProduct");

            //DataCommand cmd = new DataCommand("IsFavoriteProduct");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>
        /// 删除FavoriteProduct信息
        /// </summary>
        public   void DeleteFavoriteProduct(int usersysno, int productsysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteFavoriteProduct");

            //DataCommand cmd = new DataCommand("DeleteFavoriteProduct");
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productsysno);
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, usersysno);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 分页查询FavoriteProduct信息
        /// </summary>
        public   QueryResult<FavoriteProduct> QueryFavoriteProductList(QF_FavoriteProduct filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryFavoriteProductList");

            //DataCommand cmd = new DataCommand("QueryFavoriteProductList");
            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            QueryResult<FavoriteProduct> result = cmd.Query<FavoriteProduct>(filter, "F.InDate DESC");
            return result;
			 
            
        }
    }

}
