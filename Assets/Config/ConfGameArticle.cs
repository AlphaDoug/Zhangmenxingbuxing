using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Data.Common;

/// <summary>
/// Generated from GameArticle.xlsx sheet GameArticle
/// </summary>
public  class  ConfGameArticle
{
    public static bool resLoaded = false;
    
    public static bool cacheLoaded = false;
     
    private static List<ConfGameArticle>  cacheArray = new List<ConfGameArticle>();
    
    private static Dictionary<string, ConfGameArticle> dic = new Dictionary<string, ConfGameArticle>();
    public static List<ConfGameArticle> array 
    {
        get
        {
            GetArrrayList();
            return cacheArray;
        }
    }
    
    public ConfGameArticle()
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
    /// 道具SN
    /// </summary>
    public readonly string sn;
    /// <summary>
    /// 名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 类别
    /// </summary>
    public readonly string Type;
    /// <summary>
    /// 介绍
    /// </summary>
    public readonly string Describe;
    /// <summary>
    /// 功能
    /// </summary>
    public readonly string Feature;
    /// <summary>
    /// 获得方式
    /// </summary>
    public readonly string HowtoGet;

    public ConfGameArticle
        (
        string sn,
        string Name,
        string Type,
        string Describe,
        string Feature,
        string HowtoGet
        )
    {
        this.sn = sn;
        this.Name = Name;
        this.Type = Type;
        this.Describe = Describe;
        this.Feature = Feature;
        this.HowtoGet = HowtoGet;
    }
        
    
    public static bool GetConfig( string id, out ConfGameArticle config )
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
        var reader = SQLiteDB.Select("ConfGameArticle", id);
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
                //D.error("GameArticle 表找不到SN={0} 的数据或者配置列数不匹配\n{1}", id, ex);
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

    public static ConfGameArticle Get(string id)
    {
        ConfGameArticle config;
        bool _exist = GetConfig(id, out config);
        return config;
    }

    public static bool GetConfig( string fieldName, object fieldValue, out ConfGameArticle config )
    {
        Type type = typeof(ConfGameArticle);
        var reader = SQLiteDB.Select("ConfGameArticle", fieldName, fieldValue);
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
                //D.error("GameArticle 表找不到列={0} 值={1}的数据\n{2}", fieldName, fieldValue, ex);
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
    
    private static ConfGameArticle GetConfByDic(DbDataReader reader)
    {
        string sn = reader.GetString(0);
        string Name = reader.GetString(1);
        string Type = reader.GetString(2);
        string Describe = reader.GetString(3);
        string Feature = reader.GetString(4);
        string HowtoGet = reader.GetString(5);
    
        var conf = new ConfGameArticle
        (
            sn,
            Name,
            Type,
            Describe,
            Feature,
            HowtoGet
        );        
        return conf;
    }
     
    private static void GetArrrayList()
    {
        if(cacheArray.Count <= 0)
        {
            var reader = SQLiteDB.Query("ConfGameArticle");
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
