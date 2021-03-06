
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

    public class PromotionTemplatesDA : IPromotionTemplatesDA
    {

        /// <summary>
        /// 创建PromotionTemplates信息
        /// </summary>
        public   int InsertPromotionTemplates(PromotionTemplates entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertPromotionTemplates");

           // DataCommand cmd = new DataCommand("InsertPromotionTemplates");
            cmd.SetParameter<PromotionTemplates>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新PromotionTemplates信息
        /// </summary>
        public   void UpdatePromotionTemplates(PromotionTemplates entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdatePromotionTemplates");

            //DataCommand cmd = new DataCommand("UpdatePromotionTemplates");
            cmd.SetParameter<PromotionTemplates>(entity);
            cmd.ExecuteNonQuery();			 
        }



        /// <summary>
        /// 删除PromotionTemplates信息
        /// </summary>
        public   void DeletePromotionTemplates(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeletePromotionTemplates");

            //DataCommand cmd = new DataCommand("DeletePromotionTemplates");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }




        /// <summary>
        /// 获取单个PromotionTemplates信息
        /// </summary>
        public   PromotionTemplates LoadPromotionTemplates(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadPromotionTemplates");

            //DataCommand cmd = new DataCommand("LoadPromotionTemplates");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            PromotionTemplates result = cmd.ExecuteEntity<PromotionTemplates>();
			return result; 
        }



    }

}
