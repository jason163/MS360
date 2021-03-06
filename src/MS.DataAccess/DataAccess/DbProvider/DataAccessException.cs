﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Common;

namespace MS.DataAccess.DbProvider
{
    [Serializable]
    public class DataAccessException : MSException
    {
        public DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DataAccessException(System.Exception innerException, string connectionStr, string sqlText,
            params DbParameter[] commandParameters)
            : base(BuilderMessage(innerException.Message, connectionStr, sqlText, commandParameters), innerException)
        {
        }

        private static string BuilderMessage(string errorMsg, string connectionStr, string sqlText,
            params DbParameter[] commandParameters)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendFormat("{0}\r\n", errorMsg);
            msg.AppendFormat("<<Connection String>> : {0}\r\n", connectionStr);
            msg.AppendFormat("<<SQL Script>> : {0}\r\n", sqlText);
            if (commandParameters != null && commandParameters.Length > 0)
            {
                msg.Append("<<SQL Parameter(s)>> :\r\n");
                foreach (DbParameter param in commandParameters)
                {
                    msg.AppendFormat("{0} [{1}] : {2} [{3}]\r\n", param.ParameterName, param.DbType, param.Value, param.Value == null ? "" : param.Value.GetType().ToString());
                }
            }
            return msg.ToString();
        }
    }
}
