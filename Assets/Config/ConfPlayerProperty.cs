using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Data.Common;


/// <summary>
/// Generated from PlayerProperty.xlsx sheet PlayerProperty
/// </summary>
public  class  ConfPlayerProperty
{
    public static bool resLoaded = false;
    
    public static bool cacheLoaded = false;
     
    private static List<ConfPlayerProperty>  cacheArray = new List<ConfPlayerProperty>();
    
    private static Dictionary<string, ConfPlayerProperty> dic = new Dictionary<string, ConfPlayerProperty>();
    public static List<ConfPlayerProperty> array 
    {
        get
        {
            GetArrrayList();
            return cacheArray;
        }
    }
    
    public ConfPlayerProperty()
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
    /// 角色英文
    /// </summary>
    public readonly string sn;
    /// <summary>
    /// 角色中文
    /// </summary>
    public readonly string nameC;
    /// <summary>
    /// 性别
    /// </summary>
    public readonly string sex;
    /// <summary>
    /// 生命值
    /// </summary>
    public readonly int hp;
    /// <summary>
    /// 防御力
    /// </summary>
    public readonly int defense;
    /// <summary>
    /// 攻击力
    /// </summary>
    public readonly int attack;
    /// <summary>
    /// 敏捷度
    /// </summary>
    public readonly int agility;
    /// <summary>
    /// 状态
    /// </summary>
    public readonly string content;
    /// <summary>
    /// 体力
    /// </summary>
    public readonly int strength;
    /// <summary>
    /// 等级
    /// </summary>
    public readonly int level;
    /// <summary>
    /// 经验值
    /// </summary>
    public readonly int exp;
    /// <summary>
    /// 悟性
    /// </summary>
    public readonly int WX;
    /// <summary>
    /// 武器专精
    /// </summary>
    public readonly string WQ;
    /// <summary>
    /// 生活专精
    /// </summary>
    public readonly string SH;

    public ConfPlayerProperty
        (
        string sn,
        string nameC,
        string sex,
        int hp,
        int defense,
        int attack,
        int agility,
        string content,
        int strength,
        int level,
        int exp,
        int WX,
        string WQ,
        string SH
        )
    {
        this.sn = sn;
        this.nameC = nameC;
        this.sex = sex;
        this.hp = hp;
        this.defense = defense;
        this.attack = attack;
        this.agility = agility;
        this.content = content;
        this.strength = strength;
        this.level = level;
        this.exp = exp;
        this.WX = WX;
        this.WQ = WQ;
        this.SH = SH;
    }
        
    
    public static bool GetConfig( string id, out ConfPlayerProperty config )
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
        var reader = SQLiteDB.Select("ConfPlayerProperty", id);
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
                //D.error("PlayerProperty 表找不到SN={0} 的数据或者配置列数不匹配\n{1}", id, ex);
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

    public static ConfPlayerProperty Get(string id)
    {
        ConfPlayerProperty config;
        bool _exist = GetConfig(id, out config);
        return config;
    }

    public static bool GetConfig( string fieldName, object fieldValue, out ConfPlayerProperty config )
    {
        Type type = typeof(ConfPlayerProperty);
        var reader = SQLiteDB.Select("ConfPlayerProperty", fieldName, fieldValue);
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
                //D.error("PlayerProperty 表找不到列={0} 值={1}的数据\n{2}", fieldName, fieldValue, ex);
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
    
    private static ConfPlayerProperty GetConfByDic(DbDataReader reader)
    {
        string sn = reader.GetString(0);
        string nameC = reader.GetString(1);
        string sex = reader.GetString(2);
        int hp = reader.GetInt32(3);
        int defense = reader.GetInt32(4);
        int attack = reader.GetInt32(5);
        int agility = reader.GetInt32(6);
        string content = reader.GetString(7);
        int strength = reader.GetInt32(8);
        int level = reader.GetInt32(9);
        int exp = reader.GetInt32(10);
        int WX = reader.GetInt32(11);
        string WQ = reader.GetString(12);
        string SH = reader.GetString(13);
    
        var conf = new ConfPlayerProperty
        (
            sn,
            nameC,
            sex,
            hp,
            defense,
            attack,
            agility,
            content,
            strength,
            level,
            exp,
            WX,
            WQ,
            SH
        );        
        return conf;
    }
     
    private static void GetArrrayList()
    {
        if(cacheArray.Count <= 0)
        {
            var reader = SQLiteDB.Query("ConfPlayerProperty");
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
