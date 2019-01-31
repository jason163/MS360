using MS.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.DataAccess.DbProvider
{
    public interface ISQLConfigHelper
    {
        List<SQL> GetSQLList();
    }
}
