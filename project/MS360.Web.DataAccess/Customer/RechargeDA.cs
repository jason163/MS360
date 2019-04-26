
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;


namespace MS360.Web.DataAccess.Customer
{
    public class RechargeDA : IRechargeDA
    {
        public static QueryResult<QR_Recharge> QueryCustomerRechargeList(QF_Recharge filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryCustomerRechargeList");

            //DataCommand cmd = new DataCommand("QueryCustomerRechargeList");
            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            cmd.QuerySetCondition("RechargeStatus", ConditionOperation.NotEqual, DbType.Int32, -2);
            QueryResult<QR_Recharge> result = cmd.Query<QR_Recharge>(filter, " SysNo DESC");
            return result;
        }
        public static QueryResult<QR_Consum> QueryCustomerConsumList(QF_Consum filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryCustomerConsumList");

            //DataCommand cmd = new DataCommand("QueryCustomerConsumList");
            cmd.QuerySetCondition("ND.NursingStatus", ConditionOperation.NotIn, DbType.Int32, "0");
            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            QueryResult<QR_Consum> result = cmd.Query<QR_Consum>(filter, " ND.SysNo DESC");
            return result;
        }
        /// <summary>
        /// 预约列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static QueryResult<QR_ReservationRecords> GetCustomerReservationRecords(QF_ReservationRecords filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryCustomerReservationRecords");
            //DataCommand cmd = new DataCommand("QueryCustomerReservationRecords");
            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            QueryResult<QR_ReservationRecords> result = cmd.Query<QR_ReservationRecords>(filter, " SysNo DESC");
            return result;
        }
        
        /// <summary>
        /// 根据sysno 查询消费记录信息
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public static NursingDiaryItem LoadNursingDiaryItem(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadNursingDiaryItem");

            //DataCommand cmd = new DataCommand("LoadNursingDiaryItem");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            NursingDiaryItem result = cmd.ExecuteEntity<NursingDiaryItem>();
            return result;
        }
        
        /// <summary>
        /// 确认消费记录
        /// </summary>
        public static void Confirmconsum( int sysno,int score)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Confirmconsum");

            //DataCommand cmd = new DataCommand("Confirmconsum");
            cmd.SetParameter("@SysNo", DbType.Int32, sysno);
            cmd.SetParameter("@Rate", DbType.Int32, score);
            cmd.ExecuteNonQuery();
        }
        
        public static RechargeRequest InsertRecharge(RechargeRequest entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertRecharge");

            //DataCommand cmd = new DataCommand("InsertRecharge");
            cmd.SetParameter<RechargeRequest>(entity);
            RechargeRequest result = cmd.ExecuteEntity<RechargeRequest>();
            return result;
        }
        /// <summary>
        /// 插入预约记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static QR_ReservationRecords InsertReservationRecords(QR_ReservationRecords entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertReservationRecords");

            //DataCommand cmd = new DataCommand("InsertReservationRecords");
            cmd.SetParameter<QR_ReservationRecords>(entity);
            QR_ReservationRecords result = cmd.ExecuteEntity<QR_ReservationRecords>();
            return result;
        }
         public static QR_ReservationRecords QuerySO(int customerSysNo, int productSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QuerySO");

            //DataCommand cmd = new DataCommand("QuerySO");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            cmd.SetParameter("@ProductSysNo", DbType.Int32, productSysNo);
            QR_ReservationRecords result = cmd.ExecuteEntity<QR_ReservationRecords>();
            return result;

        }
        /// <summary>
        /// 预约商品列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<GetReservationProduct> GetReservationProduct(int customerSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetReservationProduct");

            //DataCommand cmd = new DataCommand("GetReservationProduct");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            return cmd.ExecuteEntityList<GetReservationProduct>();
        }

        public static void UpdateRecharge(RechargeRequest rechargedetail)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateRecharge");

            //DataCommand cmd = new DataCommand("UpdateRecharge");
            cmd.SetParameter<RechargeRequest>(rechargedetail);            
            cmd.ExecuteNonQuery();
        }
        public static RechargeRequest LoadRecharge(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadRecharge");

            //DataCommand cmd = new DataCommand("LoadRecharge");
            cmd.SetParameter("@SoSysNo", DbType.Int32, sosysno);
            RechargeRequest result = cmd.ExecuteEntity<RechargeRequest>();
            return result;
        }
    }
}
