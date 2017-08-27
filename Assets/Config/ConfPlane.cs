using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Data.Common;
using UnityEngine;

/// <summary>
/// Generated from Plane.xlsx sheet Plane
/// </summary>
public  class  ConfPlane
{
    public static bool resLoaded = false;
    
    public static bool cacheLoaded = false;
     
    private static List<ConfPlane>  cacheArray = new List<ConfPlane>();
    
    private static Dictionary<string, ConfPlane> dic = new Dictionary<string, ConfPlane>();
    public static List<ConfPlane> array 
    {
        get
        {
            GetArrrayList();
            return cacheArray;
        }
    }
    
    public ConfPlane()
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
    /// 英文名
    /// </summary>
    public readonly string sn;
    /// <summary>
    /// 中文名
    /// </summary>
    public readonly string nameC;
    /// <summary>
    /// 性别
    /// </summary>
    public readonly string sex;
    /// <summary>
    /// 血量
    /// </summary>
    public readonly int hp;
    /// <summary>
    /// 防御
    /// </summary>
    public readonly double defense;
    /// <summary>
    /// 攻击
    /// </summary>
    public readonly int attack;
    /// <summary>
    /// 敏捷
    /// </summary>
    public readonly int agility;

    public ConfPlane
        (
        string sn,
        string nameC,
        string sex,
        int hp,
        double defense,
        int attack,
        int agility
        )
    {
        this.sn = sn;
        this.nameC = nameC;
        this.sex = sex;
        this.hp = hp;
        this.defense = defense;
        this.attack = attack;
        this.agility = agility;
    }
        
    
    public static bool GetConfig( string id, out ConfPlane config )
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
        var reader = SQLiteDB.Select("ConfPlane", id);
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
                Debug.Log("Plane 表找不到SN={0} 的数据或者配置列数不匹配\n{1}" + id + ex);
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

    public static ConfPlane Get(string id)
    {
        ConfPlane config;
        bool _exist = GetConfig(id, out config);
        return config;
    }

    public static bool GetConfig( string fieldName, object fieldValue, out ConfPlane config )
    {
        Type type = typeof(ConfPlane);
        var reader = SQLiteDB.Select("ConfPlane", fieldName, fieldValue);
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
                Debug.Log("Plane 表找不到列={0} 值={1}的数据\n{2}"+fieldName+ fieldValue+ ex);
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
    
    private static ConfPlane GetConfByDic(DbDataReader reader)
    {
        string sn = reader.GetString(0);
        string nameC = reader.GetString(1);
        string sex = reader.GetString(2);
        int hp = reader.GetInt32(3);
        double defense = reader.GetDouble(4);
        int attack = reader.GetInt32(5);
        int agility = reader.GetInt32(6);
    
        var conf = new ConfPlane
        (
            sn,
            nameC,
            sex,
            hp,
            defense,
            attack,
            agility
        );        
        return conf;
    }
     
    private static void GetArrrayList()
    {
        if(cacheArray.Count <= 0)
        {
            var reader = SQLiteDB.Query("ConfPlane");
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
