
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

    public class PromotionProductDA : IPromotionProductDA
    {
        /// <summary>
        /// 创建PromotionProduct信息
        /// </summary>
        public static int InsertPromotionProduct(PromotionProduct entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertPromotionProduct");

            //DataCommand cmd = new DataCommand("InsertPromotionProduct");
            cmd.SetParameter<PromotionProduct>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新PromotionProduct信息
        /// </summary>
        public static void UpdatePromotionProduct(PromotionProduct entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdatePromotionProduct");

            //DataCommand cmd = new DataCommand("UpdatePromotionProduct");
            cmd.SetParameter<PromotionProduct>(entity);
            cmd.ExecuteNonQuery();			 
        }



        /// <summary>
        /// 删除PromotionProduct信息
        /// </summary>
        public static void DeletePromotionProduct(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeletePromotionProduct");

            //DataCommand cmd = new DataCommand("DeletePromotionProduct");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// 获取单个PromotionProduct信息
        /// </summary>
        public static List<PromotionProduct> LoadPromotionProduct(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadPromotionProduct");

            //DataCommand cmd = new DataCommand("LoadPromotionProduct");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            List<PromotionProduct> result = cmd.ExecuteEntityList<PromotionProduct>();
			return result; 
        }



    }

}
