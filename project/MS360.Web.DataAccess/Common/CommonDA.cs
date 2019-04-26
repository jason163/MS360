
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;
using MS360.Web.Entity.Common;
using MS360.Web.Entity.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class CommonDA : ICommonDA
    {
        public bool CheckTelIsExist(string phoneNumber)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>(); //new DataCommand("CustomerCheckTelIsExist");
            dataCommand.CreateCommand("CustomerCheckTelIsExist");
            dataCommand.SetParameter("@phoneNumber", DbType.String, phoneNumber);
            object result = dataCommand.ExecuteScalar();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool PhoneTimeInterval(string phoneNumber)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>();
            dataCommand.CreateCommand("CustomerPhoneTimeInterval");
            //DataCommand dataCommand = new DataCommand("CustomerPhoneTimeInterval");
            dataCommand.SetParameter("@phoneNumber", DbType.String, phoneNumber);
            object result = dataCommand.ExecuteScalar();
            if (result != null)
            {
                DateTime lastPhoneTime = DateTime.Parse(result.ToString());
                TimeSpan diff = DateTime.Now - lastPhoneTime;
                return diff.Days != 0 || diff.Hours != 0 || diff.Minutes >= 1;
            }
            return true;
        }
        public   bool CheckIpCount(string ip, int day, int count)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>();
            dataCommand.CreateCommand("CustomerCheckIpCount");
            //DataCommand dataCommand = new DataCommand("CustomerCheckIpCount");
            dataCommand.SetParameter("@IP", DbType.String, ip);
            dataCommand.SetParameter("@day", DbType.Int32, day);
            var result = dataCommand.ExecuteScalar();
            return result != null && int.Parse(result.ToString()) >= count;

        }
        public   CellPhoneConfirmTemp CreateCellPhoneConfirmTemp(CellPhoneConfirmTemp item)
        {
            IDataCommand dataCommand = IocManager.Instance.Resolve<IDataCommand>();
            dataCommand.CreateCommand("CustomerCreateCellPhoneConfirmTemp");

            //DataCommand datacommand = new DataCommand("CustomerCreateCellPhoneConfirmTemp");
            dataCommand.SetParameter<CellPhoneConfirmTemp>(item);
            int result = dataCommand.ExecuteScalar<int>();
            item.SysNo = result;
            return item;
        }
        public   void InsertNewSMS(SMSInfo item)
        {
            IDataCommand datacommand = IocManager.Instance.Resolve<IDataCommand>();
            datacommand.CreateCommand("CustomerInsertNewSMS");

            //DataCommand datacommand = new DataCommand("CustomerInsertNewSMS");
            datacommand.SetParameter<SMSInfo>(item);
            datacommand.ExecuteNonQuery();
        }
        public   CellPhoneConfirmTemp GetVerifyVodeByCellNumber(string cellNumber)
        {
            IDataCommand datacommand = IocManager.Instance.Resolve<IDataCommand>();
            datacommand.CreateCommand("GetVerifyVodeByCellNumber");

            //DataCommand datacommand = new DataCommand("GetVerifyVodeByCellNumber");
            datacommand.SetParameter("@CellNumber", DbType.String, cellNumber);
            CellPhoneConfirmTemp result = datacommand.ExecuteEntity<CellPhoneConfirmTemp>();
            return result;
        }

        /// <summary>
        /// 分页查询Area
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public   QueryResult<QR_Area> QueryAreaList(QF_Area filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryAreaList");
            //DataCommand cmd = new DataCommand("QueryAreaList");
            cmd.QuerySetCondition("Status", ConditionOperation.NotEqual, DbType.Int32, -999);
            if (filter.ProvinceSysNo.HasValue)
            {
                cmd.QuerySetCondition("ProvinceSysNo", ConditionOperation.Equal, DbType.Int32, filter.ProvinceSysNo);
            }
            else
            {
                cmd.QuerySetCondition("and ProvinceSysNo is null");
            }
            if (filter.CitySysNo.HasValue)
            {
                cmd.QuerySetCondition("CitySysNo", ConditionOperation.Equal, DbType.String, filter.CitySysNo);
            }
            else
            {
                cmd.QuerySetCondition("and CitySysNo is null");
            }
            cmd.QuerySetCondition("SysNo", ConditionOperation.Equal, DbType.String, filter.SysNo);
            cmd.QuerySetCondition("Status", ConditionOperation.Equal, DbType.Int32, filter.Status);

            QueryResult<QR_Area> result = cmd.Query<QR_Area>(filter, "OrderNumber ASC");

            return result;
        }
        /// <summary>
        /// 分页查询Area
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public   List<QR_Saler> GetSalerList()
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetSalerList");

            //DataCommand cmd = new DataCommand("GetSalerList");
            return cmd.ExecuteEntityList<QR_Saler>();
        }
            
        public   Area LoadArea(int sysno)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadArea");

            //DataCommand datacommand = new DataCommand("LoadArea");
            cmd.SetParameter("@SysNo", DbType.Int32, sysno);
            Area result = cmd.ExecuteEntity<Area>();
            return result;
        }

        public   void CreatePushMessage(PushMessage msg)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("CreatePushMessage");

            //DataCommand cmd = new DataCommand("CreatePushMessage");
            cmd.SetParameter<PushMessage>(msg);
            cmd.ExecuteNonQuery();
        }

        public   void UpdateCellPhoneConfirmTempStatusExpired(string tel)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateCellPhoneConfirmTempStatusExpired");

            //DataCommand cmd = new DataCommand("UpdateCellPhoneConfirmTempStatusExpired");
            cmd.SetParameter("@tel", DbType.String, tel);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 修改绑定的设备号
        /// </summary>
        /// <param name="customerSysNo"></param>
        /// <param name="channelId"></param>
        /// <param name="deviceType"></param>
        public   void UpdateMemberDevice(int customerSysNo, string channelId, int deviceType)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateMemberDevice");

            //DataCommand cmd = new DataCommand("UpdateMemberDevice");
            cmd.SetParameter("@CustomerSysNo", DbType.Int32, customerSysNo);
            cmd.SetParameter("@ChannelID", DbType.String, channelId);
            cmd.SetParameter("@DeviceType", DbType.Int32, deviceType);
            cmd.ExecuteNonQuery();
        }
    }
}
