
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;

namespace MS360.Web.DataAccess
{

    public class RMAItemDA : IRMAItemDA
    {

        /// <summary>
        /// 创建RMAItem信息
        /// </summary>
        public   int InsertRMAItem(RMAItem entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertRMAItem");

            //DataCommand cmd = new DataCommand("InsertRMAItem");
            cmd.SetParameter<RMAItem>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新RMAItem信息
        /// </summary>
        public   void UpdateRMAItem(RMAItem entity)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>();
            dataCommand.CreateCommand("UpdateRMAItem");

            //DataCommand cmd = new DataCommand("UpdateRMAItem");
            dataCommand.SetParameter<RMAItem>(entity);
            dataCommand.ExecuteNonQuery();
        }



        /// <summary>
        /// 删除RMAItem信息
        /// </summary>
        public   void DeleteRMAItem(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteRMAItem");

            //DataCommand cmd = new DataCommand("DeleteRMAItem");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }

        
        /// <summary>
        /// 删除RMAItem信息
        /// </summary>
        public   void DeleteRMAItemByRMASysNo(int rmaSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteRMAItemByRMASysNo");

           // DataCommand cmd = new DataCommand("DeleteRMAItemByRMASysNo");
            cmd.SetParameter("@SysNo", DbType.Int32, rmaSysNo);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 分页查询RMAItem信息
        /// </summary>
        public   QueryResult<QR_RMAItem> QueryRMAItemList(QF_RMAItem filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryRMAItemList");

            //DataCommand cmd = new DataCommand("QueryRMAItemList");
            QueryResult<QR_RMAItem> result = cmd.Query<QR_RMAItem>(filter, " SysNo DESC");

            return result;


        }


        /// <summary>
        /// 获取单个RMAItem信息
        /// </summary>
        public   RMAItem LoadRMAItem(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadRMAItem");

            //DataCommand cmd = new DataCommand("LoadRMAItem");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            RMAItem result = cmd.ExecuteEntity<RMAItem>();
            return result;
        }

        /// <summary>
        /// 根据MasterSysNo获取列表
        /// </summary>
        /// <param name="rmaMasterSysNo"></param>
        /// <returns></returns>
        public   List<RMAItem> LoadRMAItems(int rmaMasterSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadRMAItems");

            //DataCommand cmd = new DataCommand("LoadRMAItems");
            cmd.SetParameter("@RMASysNo", DbType.Int32, rmaMasterSysNo);
            return cmd.ExecuteEntityList<RMAItem>();
        }

        /// <summary>
        /// 检查是否提交过售后申请信息
        /// </summary>
        /// <param name="sosysno"></param>
        /// <param name="productSysNo"></param>
        /// <returns></returns>
        public   bool CheckRmaItemExists(int sosysno, int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("CheckRmaItemExists");

            //var cmd = new DataCommand("CheckRmaItemExists");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteScalar<bool>();
        }

    }

}
