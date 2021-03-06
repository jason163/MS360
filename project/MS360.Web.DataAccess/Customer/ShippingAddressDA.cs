
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

    public class ShippingAddressDA : IShippingAddressDA
    {

        /// <summary>
        /// 创建ShippingAddress信息
        /// </summary>
        public   int InsertShippingAddress(ShippingAddress entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertShippingAddress");

            //DataCommand cmd = new DataCommand("InsertShippingAddress");
            cmd.SetParameter<ShippingAddress>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新ShippingAddress信息
        /// </summary>
        public   void UpdateShippingAddress(ShippingAddress entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateShippingAddress");

            //DataCommand cmd = new DataCommand("UpdateShippingAddress");
            cmd.SetParameter<ShippingAddress>(entity);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 删除ShippingAddress信息
        /// </summary>
        public   void DeleteShippingAddress(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteShippingAddress");

            //DataCommand cmd = new DataCommand("DeleteShippingAddress");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 分页查询ShippingAddress信息
        /// </summary>
        public   QueryResult<QR_ShippingAddress> QueryShippingAddressList(QF_ShippingAddress filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryShippingAddressList");

            //DataCommand cmd = new DataCommand("QueryShippingAddressList");

            cmd.QuerySetCondition("CustomerSysNo", ConditionOperation.Equal, DbType.Int32, filter.CustomerSysNo);
            
            cmd.QuerySetCondition("IsDefault", ConditionOperation.Equal, DbType.Int32, filter.IsDefault);
            

            QueryResult<QR_ShippingAddress> result = cmd.Query<QR_ShippingAddress>(filter, " SysNo DESC");

            return result;
        }
        /// <summary>
        /// 加载自提收货地址
        /// </summary>
        /// <returns></returns>
        public   List<QR_ShippingAddress> QuerySelfPickupAddresses()
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QuerySelfPickupAddresses");

            //DataCommand cmd = new DataCommand("QuerySelfPickupAddresses");
            List<QR_ShippingAddress> result = cmd.ExecuteEntityList<QR_ShippingAddress>();

            return result;
        }


        /// <summary>
        /// 获取单个ShippingAddress信息
        /// </summary>
        public   ShippingAddress LoadShippingAddress(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadShippingAddress");

            //DataCommand cmd = new DataCommand("LoadShippingAddress");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            ShippingAddress result = cmd.ExecuteEntity<ShippingAddress>();
            return result;
        }



    }

}
