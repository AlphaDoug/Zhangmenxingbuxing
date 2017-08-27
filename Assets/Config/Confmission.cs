using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Data.Common;

/// <summary>
/// Generated from Mission.xlsx sheet mission
/// </summary>
public  class  Confmission
{
    public static bool resLoaded = false;
    
    public static bool cacheLoaded = false;
     
    private static List<Confmission>  cacheArray = new List<Confmission>();
    
    private static Dictionary<int, Confmission> dic = new Dictionary<int, Confmission>();
    public static List<Confmission> array 
    {
        get
        {
            GetArrrayList();
            return cacheArray;
        }
    }
    
    public Confmission()
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
    /// 任务编号
    /// </summary>
    public readonly int sn;
    /// <summary>
    /// 任务名称
    /// </summary>
    public readonly string name;
    /// <summary>
    /// 查找树
    /// </summary>
    public readonly string find;
    /// <summary>
    /// 选项
    /// </summary>
    public readonly string choose;
    /// <summary>
    /// 奖励经验
    /// </summary>
    public readonly int experience;
    /// <summary>
    /// 奖励声望
    /// </summary>
    public readonly int prestige;
    /// <summary>
    /// 奖励货币
    /// </summary>
    public readonly int money;
    /// <summary>
    /// 奖励善恶
    /// </summary>
    public readonly int justice;
    /// <summary>
    /// 失去道具
    /// </summary>
    public readonly string lost;
    /// <summary>
    /// 获得道具
    /// </summary>
    public readonly string gain;
    /// <summary>
    /// 任务描述
    /// </summary>
    public readonly string missiondesc;
    /// <summary>
    /// 对话内容
    /// </summary>
    public readonly string talk;

    public Confmission
        (
        int sn,
        string name,
        string find,
        string choose,
        int experience,
        int prestige,
        int money,
        int justice,
        string lost,
        string gain,
        string missiondesc,
        string talk
        )
    {
        this.sn = sn;
        this.name = name;
        this.find = find;
        this.choose = choose;
        this.experience = experience;
        this.prestige = prestige;
        this.money = money;
        this.justice = justice;
        this.lost = lost;
        this.gain = gain;
        this.missiondesc = missiondesc;
        this.talk = talk;
    }
        
    
    public static bool GetConfig( int id, out Confmission config )
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
        var reader = SQLiteDB.Select("Confmission", id);
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

    public static Confmission Get(int id)
    {
        Confmission config;
        bool _exist = GetConfig(id, out config);
        return config;
    }

    public static bool GetConfig( string fieldName, object fieldValue, out Confmission config )
    {
        Type type = typeof(Confmission);
        var reader = SQLiteDB.Select("Confmission", fieldName, fieldValue);
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
    
    private static Confmission GetConfByDic(DbDataReader reader)
    {
        int sn = reader.GetInt32(0);
        string name = reader.GetString(1);
        string find = reader.GetString(2);
        string choose = reader.GetString(3);
        int experience = reader.GetInt32(4);
        int prestige = reader.GetInt32(5);
        int money = reader.GetInt32(6);
        int justice = reader.GetInt32(7);
        string lost = reader.GetString(8);
        string gain = reader.GetString(9);
        string missiondesc = reader.GetString(10);
        string talk = reader.GetString(11);
    
        var conf = new Confmission
        (
            sn,
            name,
            find,
            choose,
            experience,
            prestige,
            money,
            justice,
            lost,
            gain,
            missiondesc,
            talk
        );        
        return conf;
    }
     
    private static void GetArrrayList()
    {
        if(cacheArray.Count <= 0)
        {
            var reader = SQLiteDB.Query("Confmission");
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
