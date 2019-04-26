
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.DataMapper;
using MS.Dependency;
using MS360.Web.Entity;
using MS360.Web.Entity.Order;
using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class OrderDA : IOrderDA
    {
        public   QueryResult<SOMaster> QueryOrderList(QF_SO filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryOrderList");

            //DataCommand cmd = new DataCommand("QueryOrderList");
            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            if (filter.SOStatus.HasValue && filter.SOStatus.Value == 101)
            {
                cmd.QuerySetCondition("and  exists(select 1  from    [ECCenter].[dbo].SOItem  as si with (nolock) left join [ECCenter].[dbo].[ProductComment] as pc with (nolock) on si.ProductSysNo=pc.ProductSysNo and si.SOSysNo=pc.SOSysNo where si.SOSysNo=[ECCenter].[dbo].[SOMaster].SysNo and pc.SysNo is null  )");
                cmd.QuerySetCondition("SOStatus", ConditionOperation.Equal, DbType.Int32, 100);
                cmd.QuerySetCondition("and DATEDIFF(M, SODATE ,GETDATE())<=1");
            }
            else
            {
                cmd.QuerySetCondition("SOStatus", ConditionOperation.Equal, DbType.Int32, filter.SOStatus);
            }
            QueryResult<SOMaster> result = cmd.Query<SOMaster>(filter, " SODate DESC");
            return result;
        }

        public   List<SOItem> GetSOItemProducts(List<int> sosysnos)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOItemProducts");

            //DataCommand cmd = new DataCommand("GetSOItemProducts");
            cmd.QuerySetCondition("si.SOSysNo", ConditionOperation.In, DbType.Int32, sosysnos);
            return cmd.ExecuteEntityList<SOItem>("#DynamicParameters#");
        }

        public   SOMaster GetSOMaster(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOMaster");

            //DataCommand cmd = new DataCommand("GetSOMaster");
            cmd.SetParameter("@SysNo", DbType.Int32, sosysno);
            return cmd.ExecuteEntity<SOMaster>();
        }

        public   List<SOItem> GetSOItemBySOSysNo(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOItemBySOSysNo");

            //DataCommand cmd = new DataCommand("GetSOItemBySOSysNo");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            return cmd.ExecuteEntityList<SOItem>();
        }
        public   List<SODiscountMaster> GetSODiscountBySOSysNo(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSODiscountBySOSysNo");

            //DataCommand cmd = new DataCommand("GetSODiscountBySOSysNo");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            DataSet ds = cmd.ExecuteDataSet();
            List<SODiscountMaster> dmList = null;
            if (ds != null && ds.Tables.Count > 1)
            {
                dmList = DataMapperHelper.GetEntityList<SODiscountMaster, List<SODiscountMaster>>(ds.Tables[0].Rows);
                if (dmList != null && dmList.Count > 0)
                {
                    List<SODiscountDetail> ddList = DataMapperHelper.GetEntityList<SODiscountDetail, List<SODiscountDetail>>(ds.Tables[1].Rows);

                    foreach (var dm in dmList)
                    {
                        dm.Details = ddList.FindAll(dd => dd.MasterSysNo == dm.SysNo);
                    }
                }
            }
            return dmList;
        }


        public   List<SOStatistics> GetSOStatistics(int customersysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOStatistics");

            //DataCommand cmd = new DataCommand("GetSOStatistics");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customersysno);
            return cmd.ExecuteEntityList<SOStatistics>();
        }


        public   List<SOLog> GetSOLogList(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOLogList");

            //DataCommand cmd = new DataCommand("GetSOLogList");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            return cmd.ExecuteEntityList<SOLog>();
        }


        public   SOLogistic GetSOLogistic(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOLogistic");

            //DataCommand cmd = new DataCommand("GetSOLogistic");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            return cmd.ExecuteEntity<SOLogistic>();
        }
        public   bool UpdateSOPayType(int soSysNo, string payTypeID, int userSysNo, string userName)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateSOPayType");

            //DataCommand cmd = new DataCommand("UpdateSOPayType");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@PayTypeID", DbType.Int32, payTypeID);
            cmd.SetParameter("@EditUserSysNo", DbType.Int32, userSysNo);
            cmd.SetParameter("@EditUserName", DbType.AnsiStringFixedLength, userName, 40);
            cmd.ExecuteNonQuery();
            return true;
        }
        public   bool updateRechargePayType(int soSysNo, string payTypeID, int userSysNo, string userName)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("updateRechargePayType");

            //DataCommand cmd = new DataCommand("updateRechargePayType");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@PayTypeID", DbType.Int32, payTypeID);
            cmd.SetParameter("@EditUserSysNo", DbType.Int32, userSysNo);
            cmd.SetParameter("@EditUserName", DbType.AnsiStringFixedLength, userName, 40);
            cmd.ExecuteNonQuery();
            return true;
        }
        
        public   SONetPay GetSONetPay(int sosysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSONetPayBySOSysNo");

            //DataCommand cmd = new DataCommand("GetSONetPayBySOSysNo");
            cmd.SetParameter("@SOSysNo", DbType.Int32, sosysno);
            return cmd.ExecuteEntity<SONetPay>();
        }

        public   bool CreateSONetpay(SONetPay soNetPay)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("CreateSONetpay");

            //DataCommand cmd = new DataCommand("CreateSONetpay");
            cmd.SetParameter<SONetPay>(soNetPay);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        /// <summary>
        /// 创建销售收款单
        /// </summary>
        /// <param name="soNetPay"></param>
        /// <param name="incomeType">收款单类型 0:正收款单 1：AO 2：RO</param>
        /// <returns></returns>
        public   bool CreateSOIncome(SONetPay soNetPay,int incomeType,int status=0)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("CreateSOIncome");

            //DataCommand cmd = new DataCommand("CreateSOIncome");
            cmd.SetParameter<SONetPay>(soNetPay);
            cmd.SetParameter("@PayAmount", DbType.Decimal, incomeType > 0 ? soNetPay.PayAmount : -soNetPay.PayAmount);
            cmd.SetParameter("@SOIncomeType", DbType.Int32, incomeType);
            cmd.SetParameter("@SOIncomeBillStatus", DbType.Int32, status);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        /// <summary>
        /// 流水号取订单号
        /// </summary>
        /// <param name="TradeNumber">流水号</param>
        /// <returns></returns>
        public   int GetSOSysNoByTradeNumber(string TradeNumber)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSOSysNoByTradeNumber");

            //DataCommand cmd = new DataCommand("GetSOSysNoByTradeNumber");
            cmd.SetParameter("@BankTrackingNumber", DbType.String, TradeNumber);
            return cmd.ExecuteScalar<int>();
        }

        public   void UpdateRefundCallback(int refundSysNo, SOIncomeBillStatus sOIncomeBillStatus)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateRefundCallback");

            //DataCommand cmd = new DataCommand("UpdateRefundCallback");
            cmd.SetParameter("@RefundSysNo", DbType.Int32, refundSysNo);
            cmd.SetParameter("@SOIncomeBillStatus", DbType.Int32, sOIncomeBillStatus);
            cmd.ExecuteScalar<int>();
        }
        public   bool UpdateSOStatusToAbandon(int soSysNo, SOStatus soStatus, int userSysNo, string userName)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateSOStatusToAbandon");

            //DataCommand cmd = new DataCommand("UpdateSOStatusToAbandon");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo); ;
            cmd.SetParameter("@OldStatus", DbType.Int32, soStatus);
            cmd.SetParameter("@EditUserSysNo", DbType.Int32, userSysNo);
            cmd.SetParameter("@EditUserName", DbType.AnsiString, userName, 40);
            return cmd.ExecuteScalar<int>() > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soSysNo"></param>
        /// <param name="action">0创建，-1作废</param>
        /// <param name="memo"></param>
        /// <param name="userSysNo"></param>
        /// <param name="useName"></param>
        public   void SaveSOLog(int soSysNo, int action, string memo, int userSysNo, string useName)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Pipeline_SaveSOLog");


            //DataCommand cmd = new DataCommand("Pipeline_SaveSOLog");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@Action", DbType.Int32, action);
            cmd.SetParameter("@Memo", DbType.String, memo, 500);
            cmd.SetParameter("@OperatorSysNo", DbType.Int32, userSysNo);
            cmd.SetParameter("@OperatorName", DbType.AnsiString, useName, 40);
            cmd.SetParameter("@InUserSysNo", DbType.Int32, userSysNo);
            cmd.SetParameter("@InUserName", DbType.AnsiString, useName, 40);
            cmd.ExecuteNonQuery();
        }

        public   void AbandonSOAdjustProductInventory(int soSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("AbandonSOAdjustProductInventory");

            //DataCommand cmd = new DataCommand("AbandonSOAdjustProductInventory");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.ExecuteNonQuery();
        }
        public   void AbandonOrderAdjustCountDownProductInventory(int soSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("AbandonOrderAdjustCountDownProductInventory");

            //DataCommand cmd = new DataCommand("AbandonOrderAdjustCountDownProductInventory");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@PromotionType", DbType.Int32, (int)PromotionType.Countdown);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 作废订单调整顾客账户余额
        /// </summary>
        /// <param name="soSysNo"></param>
        public   void AbandonOrderAdjustCustomerAccount(int soSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("AbandonOrderAdjustCustomerAccount");

            //DataCommand cmd = new DataCommand("AbandonOrderAdjustCustomerAccount");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.ExecuteNonQuery();
        }

        public   void UpdateSOStatus(int soSysNo, SOStatus newStatus, SOStatus oldStatus)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Order_UpdateSOStatus");

            //DataCommand cmd = new DataCommand("Order_UpdateSOStatus");
            cmd.SetParameter("@SOSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@NewStatus", DbType.Int32, (int)newStatus);
            cmd.SetParameter("@OldStatus", DbType.Int32, (int)oldStatus);
            cmd.ExecuteNonQuery();
        }

        public   SORefund GetSORefund(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Order_GetSORefund");

            //DataCommand cmd = new DataCommand("Order_GetSORefund");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            return cmd.ExecuteEntity<SORefund>();
        }

        public   void UpdateRMACompleteStatus(int rmaSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Order_UpdateRMACompleteStatus");

            //DataCommand cmd = new DataCommand("Order_UpdateRMACompleteStatus");
            cmd.SetParameter("@SysNo", DbType.Int32, rmaSysNo);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 订单是否存在护理日志
        /// </summary>
        /// <param name="soSysNo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public   int IsExsitNursingDaily(int soSysNo,int status)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("Order_IsExistsNursingDiary");

            //DataCommand cmd = new DataCommand("Order_IsExistsNursingDiary");
            cmd.SetParameter("@OrderSysNo", DbType.Int32, soSysNo);
            cmd.SetParameter("@NursingStatus", DbType.Int32, status);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
