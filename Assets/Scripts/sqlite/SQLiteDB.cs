using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public static class SQLiteDB
{
    private static DbConnection s_DB;

    public static void Initialize(DbConnection connection)
    {
        s_DB = connection;
        if (s_DB.State != System.Data.ConnectionState.Open)
        {
            s_DB.Open();
        }
    }

    private static DbDataReader ExecuteQuery(string sql)
    {
        return iExecuteQuery(sql);
    }

    private static DbDataReader iExecuteQuery(string sql)
    {
        var cmd = s_DB.CreateCommand();
        cmd.CommandText = sql;
        try
        {
            return cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            
            Debug.Log("sqlQuery:" + sql + " sqlCommand.ExecuteReader -> Exception:" + e);
        }
        return null;
    }

    public static DbDataReader Query(string name)
    {
        return iExecuteQuery("SELECT * FROM " + name);
    }

    public static DbDataReader Select(string name, string fieldName, object fieldValue)
    {
        string query = "select * from " + name + " where " + fieldName + "= " + (fieldValue is string ? ("'" + fieldValue + "'") : (fieldValue));
        return ExecuteQuery(query);
    }

    public static DbDataReader Select(string name,object sn)
    {
        string query = "select * from " + name + " where sn= " + (sn is string ? ("'" + sn + "'") : (sn));
        return ExecuteQuery(query);
    }
    public static void Close()
    {
        s_DB.Close();
    }
    public static bool Connected { get { return s_DB != null; } }
}
