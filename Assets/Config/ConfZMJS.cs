using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Data.Common;

/// <summary>
/// Generated from ZMJS.xlsx sheet ZMJS
/// </summary>
public  class  ConfZMJS
{
    public static bool resLoaded = false;
    
    public static bool cacheLoaded = false;
     
    private static List<ConfZMJS>  cacheArray = new List<ConfZMJS>();
    
    private static Dictionary<int, ConfZMJS> dic = new Dictionary<int, ConfZMJS>();
    public static List<ConfZMJS> array 
    {
        get
        {
            GetArrrayList();
            return cacheArray;
        }
    }
    
    public ConfZMJS()
    {
    }

    public static void Init()
    {
        if (cacheLoaded)
        {
            GetArrrayList();
        }
        
    }
    /// <summary>
    /// 掌门等级
    /// </summary>
    public readonly int sn;
    /// <summary>
    /// 入室弟子
    /// </summary>
    public readonly int rsdz;
    /// <summary>
    /// 外门弟子
    /// </summary>
    public readonly int wmdz;
    /// <summary>
    /// 每日收入
    /// </summary>
    public readonly int input;
    /// <summary>
    /// 每日支出
    /// </summary>
    public readonly int output_rsdztime;
    /// <summary>
    /// 每日支出
    /// </summary>
    public readonly int output_wmdztime;
    /// <summary>
    /// 升级消耗
    /// </summary>
    public readonly int sjxh1;
    /// <summary>
    /// 升级消耗
    /// </summary>
    public readonly int sjxh2;
    /// <summary>
    /// 包裹数
    /// </summary>
    public readonly int bag;

    public ConfZMJS
        (
        int sn,
        int rsdz,
        int wmdz,
        int input,
        int output_rsdztime,
        int output_wmdztime,
        int sjxh1,
        int sjxh2,
        int bag
        )
    {
        this.sn = sn;
        this.rsdz = rsdz;
        this.wmdz = wmdz;
        this.input = input;
        this.output_rsdztime = output_rsdztime;
        this.output_wmdztime = output_wmdztime;
        this.sjxh1 = sjxh1;
        this.sjxh2 = sjxh2;
        this.bag = bag;
    }
        
    
    public static bool GetConfig( int id, out ConfZMJS config )
    {
        if (dic.TryGetValue(id, out config))
        {
            return true;
        }
        if(cacheLoaded)
        {
            config = null;
            return false;
        }
        var reader = SQLiteDB.Select("ConfZMJS", id);
        if (reader != null )
        {
            try
            {
                reader.Read();
                if(reader.HasRows)
                    config = GetConfByDic(reader);
                else
                {
                    config = null;
                    return false;
                }
                dic[id] = config;
                return true;
            }
            catch (Exception ex)
            {
                //D.error("ZMJS 表找不到SN={0} 的数据或者配置列数不匹配\n{1}", id, ex);
            }
            config = null;
            return false;
        }
        else
        {
            config = null;
            return false;
        }
    }

    public static ConfZMJS Get(int id)
    {
        ConfZMJS config;
        bool _exist = GetConfig(id, out config);
        return config;
    }

    public static bool GetConfig( string fieldName, object fieldValue, out ConfZMJS config )
    {
        Type type = typeof(ConfZMJS);
        var reader = SQLiteDB.Select("ConfZMJS", fieldName, fieldValue);
        if (reader != null )
        {
            try
            {
                reader.Read();
                if(reader.HasRows)
                    config = GetConfByDic(reader);
                else
                {
                    config = null;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //D.error("ZMJS 表找不到列={0} 值={1}的数据\n{2}", fieldName, fieldValue, ex);
            }
           config = null;
           return false;

        }
        config = null;
        return false;
    }

    public static void Clear()
    {
        cacheArray.Clear();
        dic.Clear();
        resLoaded = false;
    }
    
    private static ConfZMJS GetConfByDic(DbDataReader reader)
    {
        int sn = reader.GetInt32(0);
        int rsdz = reader.GetInt32(1);
        int wmdz = reader.GetInt32(2);
        int input = reader.GetInt32(3);
        int output_rsdztime = reader.GetInt32(4);
        int output_wmdztime = reader.GetInt32(5);
        int sjxh1 = reader.GetInt32(6);
        int sjxh2 = reader.GetInt32(7);
        int bag = reader.GetInt32(8);
    
        var conf = new ConfZMJS
        (
            sn,
            rsdz,
            wmdz,
            input,
            output_rsdztime,
            output_wmdztime,
            sjxh1,
            sjxh2,
            bag
        );        
        return conf;
    }
     
    private static void GetArrrayList()
    {
        if(cacheArray.Count <= 0)
        {
            var reader = SQLiteDB.Query("ConfZMJS");
            if(reader != null)
            {
                while (reader.Read())
                {
                    var conf = GetConfByDic(reader);
                    cacheArray.Add(conf);
                    dic[conf.sn] = conf;
                }
                resLoaded = true;
            }
        }
    }
}
