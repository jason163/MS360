
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
    public class TopicDA : ITopicDA
    {

        /// <summary>
        /// 创建Topic信息
        /// </summary>
        public   int InsertTopic(Topic entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("InsertTopic");

            //DataCommand cmd = new DataCommand("InsertTopic");
            cmd.SetParameter<Topic>(entity);
            int result = cmd.ExecuteScalar<int>();
            return result;

        }



        /// <summary>
        /// 更新Topic信息
        /// </summary>
        public   void UpdateTopic(Topic entity)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("UpdateTopic");

            //DataCommand cmd = new DataCommand("UpdateTopic");
            cmd.SetParameter<Topic>(entity);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 删除Topic信息
        /// </summary>
        public   void DeleteTopic(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("DeleteTopic");

            //DataCommand cmd = new DataCommand("DeleteTopic");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 分页查询Topic信息
        /// </summary>
        public   QueryResult<QR_Topic> QueryTopicList(QF_Topic filter)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("QueryTopicList");

            //DataCommand cmd = new DataCommand("QueryTopicList");
            cmd.QuerySetCondition("TopicCategorySysNo", ConditionOperation.Equal, DbType.Int32, filter.TopicCategorySysNo);
            cmd.QuerySetCondition("TopicStatus", ConditionOperation.Equal, DbType.Int32, 1);
            cmd.QuerySetCondition("StartTime", ConditionOperation.LessThanEqual, DbType.DateTime, DateTime.Now);
            cmd.QuerySetCondition("EndTime", ConditionOperation.MoreThanEqual, DbType.DateTime, DateTime.Now);
            QueryResult<QR_Topic> result = cmd.Query<QR_Topic>(filter, " SysNo DESC");

            return result;
        }


        /// <summary>
        /// 获取单个Topic信息
        /// </summary>
        public   Topic LoadTopic(int sysNo)
        {
            IDataCommand cmd = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("LoadTopic");

            //DataCommand cmd = new DataCommand("LoadTopic");
            cmd.SetParameter("@SysNo", DbType.Int32, sysNo);
            Topic result = cmd.ExecuteEntity<Topic>();
            return result;
        }



    }

}
