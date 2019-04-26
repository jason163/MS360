using MS360.Web.Entity.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS360.Web.Entity.Common;
using MS360.Web.Entity;
using MS360.Web.Enums;
using MS.DataAccess;
using MS.Dependency;

namespace MS360.Web.DataAccess.Customer
{
    public class CustomerDA : ICustomerDA
    {

        /// <summary>
        /// 创建CustomerInfo信息
        /// </summary>
        public   int InsertCustomerInfo(CustomerInfo entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("InsertCustomerInfo");

            //DataCommand cmd = new DataCommand("InsertCustomerInfo");
            cmd.SetParameter<CustomerInfo>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }

        public   void CreateCustomerExt(int customerSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("CreateCustomerExt");
            //DataCommand cmd = new DataCommand("CreateCustomerExt");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 更新CustomerInfo信息
        /// </summary>
        public   void UpdateCustomerInfo(CustomerInfo entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateCustomerInfo");

            //DataCommand cmd = new DataCommand("UpdateCustomerInfo");
            cmd.SetParameter<CustomerInfo>(entity);
            cmd.ExecuteNonQuery();
        }
         /// <summary>
        /// 充值增加账户余额
        /// </summary>
        public   void UpdateCustomerBalance(int CustomerSysNo, decimal BalancePayAmount)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateCustomerBalance");
            //DataCommand cmd = new DataCommand("UpdateCustomerBalance");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, CustomerSysNo);
            cmd.SetParameter("@Balance", DbType.Decimal, BalancePayAmount);
            cmd.ExecuteNonQuery();
        }
            
        //注册送积分
         public   void UpdateCustomerPoint(int SysNo, int point)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateCustomerPoint");

            //DataCommand cmd = new DataCommand("UpdateCustomerPoint");
            cmd.SetParameter("@SysNo", DbType.Int32, SysNo);
            cmd.SetParameter("@point", DbType.Int32, point);
            cmd.ExecuteNonQuery();
        }
        //插入积分记录
         public   int InsertCustomer_PointLog(Customer_PointLog entity)
         {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("InsertCustomer_PointLog");

            //DataCommand cmd = new DataCommand("InsertCustomer_PointLog");
             cmd.SetParameter<Customer_PointLog>(entity);
             int result = cmd.ExecuteScalar<int>();
             return result;
         }
        /// <summary>
        /// 删除CustomerInfo信息
        /// </summary>
        public   void DeleteCustomerInfo(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("DeleteCustomerInfo");

            //DataCommand cmd = new DataCommand("DeleteCustomerInfo");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }




        /// <summary>
        /// 获取单个CustomerInfo信息
        /// </summary>
        public   CustomerInfo LoadCustomerInfo(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("LoadCustomerInfo");

            //DataCommand cmd = new DataCommand("LoadCustomerInfo");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            CustomerInfo result = cmd.ExecuteEntity<CustomerInfo>();
            return result;
        }

        public   CustomerInfo GetCustomerInfoByCustomerID(string tel)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("GetCustomerInfoByCustomerID");

            //DataCommand cmd = new DataCommand("GetCustomerInfoByCustomerID");
            cmd.SetParameter("@CustomerID", DbType.String, tel);
            CustomerInfo result = cmd.ExecuteEntity<CustomerInfo>();
            return result;
        }
        public   void UpdatePwdByCustomerID(string cellNumber, string pwd, string pwdSalt)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdatePwdByCustomerID");

            //DataCommand cmd = new DataCommand("UpdatePwdByCustomerID");
            cmd.SetParameter("@CustomerID", DbType.String, cellNumber);
            cmd.SetParameter("@Pwd", DbType.String, pwd);
            cmd.SetParameter("@PwdSalt", DbType.String, pwdSalt);
            cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// 创建CustomerMapping信息
        /// </summary>
        public   void InsertCustomerMapping(CustomerMapping entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("InsertCustomerMapping");

            //DataCommand cmd = new DataCommand("InsertCustomerMapping");
            cmd.SetParameter<CustomerMapping>(entity);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 更新CustomerMapping信息
        /// </summary>
        public   void UpdateCustomerMapping(CustomerMapping entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateCustomerMapping");

            //DataCommand cmd = new DataCommand("UpdateCustomerMapping");
            cmd.SetParameter<CustomerMapping>(entity);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 获取单个CustomerMapping信息
        /// </summary>
        public   CustomerMapping LoadCustomerMapping(string openid, int thridtype)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("LoadCustomerMapping");

            //DataCommand cmd = new DataCommand("LoadCustomerMapping");
            cmd.SetParameter("@OpenID", DbType.String, openid);
            cmd.SetParameter("@ThirdType", DbType.Int32, thridtype);
            CustomerMapping result = cmd.ExecuteEntity<CustomerMapping>();
            return result;
        }

        public   CustomerMapping LoadCustomerMappingForCustomer(int customerSysno, int thridtype)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("LoadCustomerMappingForCustomer");

            //DataCommand cmd = new DataCommand("LoadCustomerMappingForCustomer");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysno);
            cmd.SetParameter("@ThirdType", DbType.Int32, thridtype);
            CustomerMapping result = cmd.ExecuteEntity<CustomerMapping>();
            return result;
        }


        public   void UpdateCellPhoneConfirmTempStatus(CellPhoneConfirmTemp item)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateCellPhoneConfirmTempStatus");

            //DataCommand cmd = new DataCommand("UpdateCellPhoneConfirmTempStatus");
            cmd.SetParameter("@SysNo", DbType.Int32, item.SysNo);
            cmd.SetParameter("@Status", DbType.Int32, item.Status);
            cmd.ExecuteNonQuery();
        }

        #region Recharge
        public   int GenerateRechargeSysNo()
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("GenerateRechargeSysNo");

            //DataCommand cmd = new DataCommand("GenerateRechargeSysNo");
            return cmd.ExecuteScalar<int>();
        }

        public   void CreateRechargeRequest(RechargeRequest request)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("InsertRechargeRequest");

            //DataCommand cmd = new DataCommand("InsertRechargeRequest");
            cmd.SetParameter<RechargeRequest>(request);
            int result = cmd.ExecuteNonQuery();
        }
        public   RechargeRequest LoadRechargeRequest(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("LoadRechargeRequest");

            //DataCommand cmd = new DataCommand("LoadRechargeRequest");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            RechargeRequest result = cmd.ExecuteEntity<RechargeRequest>();
            return result;
        }

        public   int UpdateRechargeRequestStatus(int sysNo,RechargeStatus oldStatus,RechargeStatus newStatus)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            cmd.CreateCommand("UpdateRechargeRequestStatus");

            //DataCommand cmd = new DataCommand("UpdateRechargeRequestStatus");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.SetParameter("@OldStatus", DbType.Int32, (Int32)oldStatus);
            cmd.SetParameter("@NewStatus", DbType.Int32, (Int32)newStatus);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        #endregion
    }
}
