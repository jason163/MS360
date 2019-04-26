
using MS.Application.EntityBasic;
using MS.DataAccess;
using MS.Dependency;
using MS360.Web.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.DataAccess
{
    public class CouponDA : ICouponDA
    {
        /// <summary>
        /// 领取优惠券
        /// </summary>
        public   int ReceiveCoupons(CouponReceivingRecord entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertCouponReceivingRecord");

            //DataCommand cmd = new DataCommand("InsertCouponReceivingRecord");
            cmd.SetParameter<CouponReceivingRecord>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }

        /// 获取单个Coupon信息
        /// </summary>
        public   CouponReceivingRecord LoadCouponReceivingRecord(int sysNo, int userSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadCouponReceivingRecord");

            //DataCommand cmd = new DataCommand("LoadCouponReceivingRecord");
            cmd.SetParameter("@CouponSysNo", DbType.Int32, sysNo);
            cmd.SetParameter("@UserSysNo", DbType.Int32, userSysNo);
            CouponReceivingRecord result = cmd.ExecuteEntity<CouponReceivingRecord>();
            return result;
        }

        /// 获取单个Coupon信息
        /// </summary>
        public   Coupon LoadCoupon(int sysNo,int userSysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadCoupon");

            //DataCommand cmd = new DataCommand("LoadCoupon");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.SetParameter("@UserSysNo", DbType.Int32, userSysNo);
            Coupon result = cmd.ExecuteEntity<Coupon>();
            return result;
        }

        public   QueryResult<CouponReceivingRecord> QueryCouponReceivingRecordList(QF_CouponReceivingRecord filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryCouponReceivingRecordList");

            //DataCommand cmd = new DataCommand("QueryCouponReceivingRecordList");
            cmd.QuerySetCondition("UserSysNo", ConditionOperation.Like, DbType.Int32, filter.CustomerSysNo);
            QueryResult<CouponReceivingRecord> result = cmd.Query<CouponReceivingRecord>(filter, "ReceivingDate DESC");

            return result;


        }
    }
}
