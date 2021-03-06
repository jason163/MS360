
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
    public class RMAMasterDA : IRMAMasterDA
    {

        /// <summary>
        /// 创建RMAMaster信息
        /// </summary>
        public static int InsertRMAMaster(RMAMaster entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertRMAMaster");

            //DataCommand cmd = new DataCommand("InsertRMAMaster");
            cmd.SetParameter<RMAMaster>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新RMAMaster信息
        /// </summary>
        public static void UpdateRMAMaster(RMAMaster entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateRMAMaster");

            //DataCommand cmd = new DataCommand("UpdateRMAMaster");
            cmd.SetParameter<RMAMaster>(entity);
            cmd.ExecuteNonQuery();			 
        }



        /// <summary>
        /// 删除RMAMaster信息
        /// </summary>
        public static void DeleteRMAMaster(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteRMAMaster");

            //DataCommand cmd = new DataCommand("DeleteRMAMaster");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 分页查询RMAMaster信息
        /// </summary>
        public static QueryResult<QR_RMAMaster> QueryRMAMasterList(QF_RMAMaster filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryRMAMasterList");

            //DataCommand cmd = new DataCommand("QueryRMAMasterList");
			
			                cmd.QuerySetCondition("SOSysNo",ConditionOperation.Equal,DbType.Int32,filter.SOSysNo);
                cmd.QuerySetCondition("CustomerSysNo",ConditionOperation.Equal,DbType.Int32,filter.CustomerSysNo);

			            
            QueryResult<QR_RMAMaster> result = cmd.Query<QR_RMAMaster>(filter, " SysNo DESC");
			
            return result;
			 
            
        }


        /// <summary>
        /// 获取单个RMAMaster信息
        /// </summary>
        public static RMAMaster LoadRMAMaster(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadRMAMaster");

            //DataCommand cmd = new DataCommand("LoadRMAMaster");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            RMAMaster result = cmd.ExecuteEntity<RMAMaster>();
			return result; 
        }

        /// <summary>
        /// 根据订单号和商品编号加载RMAMaster信息
        /// </summary>
        /// <param name="rmasysno"></param>
        /// <param name="productSysNo"></param>
        /// <returns></returns>
        public static RMAMaster GetRMAMasterBySOSysNoAndProductSysNo(int sosysno, int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetRMAMasterBySOSysNoAndProductSysNo");

            //var cmd = new DataCommand("GetRMAMasterBySOSysNoAndProductSysNo");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            return cmd.ExecuteEntity<RMAMaster>();
        }

    }

}
