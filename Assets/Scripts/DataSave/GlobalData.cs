using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GlobalData: DataStruct.Article
{
    public GlobalData()
    {
        equipment = new DataStruct.Equipment();
        material = new DataStruct.Material();
        book = new DataStruct.Book();
        medicine = new DataStruct.Medicine();
        special = new DataStruct.Special();
        menpaimingcheng = "";
        paimeng = "";
        rushidizi = 0;
        waiweidizi = 0;
        maxrushidizi = 0;
        maxwaiweidizi = 0;
        minrushidizi = 0;
        minwaiweidizi = 0;
        shengwangzhi = 0;
        shanezhi = 0;
        huobi = 0;
        jingyan = 0;
    }

    /// <summary>
    /// 装备数量类
    /// </summary>
    public DataStruct.Equipment equipment { get; set; }
    /// <summary>
    /// 材料数量类
    /// </summary>
    public DataStruct.Material material { get; set; }
    /// <summary>
    /// 书数量类
    /// </summary>
    public DataStruct.Book book { get; set; }
    /// <summary>
    /// 药材数量类
    /// </summary>
    public DataStruct.Medicine medicine { get; set; }
    /// <summary>
    /// 特设物品数量类
    /// </summary>
    public DataStruct.Special special { get; set; }

    /// <summary>
    /// 门派名称
    /// </summary>
    public string menpaimingcheng
    {
        get; set;
    }
    /// <summary>
    /// 派盟
    /// </summary>
    public string paimeng
    {
        get; set;
    }
    /// <summary>
    /// 入室弟子数量
    /// </summary>
    public int rushidizi
    {
        get; set;
    }
    /// <summary>
    /// 外围弟子数量
    /// </summary>
    public int waiweidizi
    {
        get; set;
    }
    /// <summary>
    /// 最大入室弟子数量
    /// </summary>
    public int maxrushidizi
    {
        get; set;
    }
    /// <summary>
    /// 最大外围弟子数量
    /// </summary>
    public int maxwaiweidizi
    {
        get; set;
    }
    /// <summary>
    /// 最小入室弟子数量
    /// </summary>
    public int minrushidizi
    {
        get; set;
    }
    /// <summary>
    /// 最小外围弟子数量
    /// </summary>
    public int minwaiweidizi
    {
        get; set;
    }
    /// <summary>
    /// 声望值
    /// </summary>
    public int shengwangzhi
    {
        get; set;
    }
    /// <summary>
    /// 善恶值
    /// </summary>
    public int shanezhi
    {
        get; set;
    }
    /// <summary>
    /// 货币
    /// </summary>
    public int huobi
    {
        get; set;
    }
    /// <summary>
    /// 经验值
    /// </summary>
    public int jingyan
    {
        get; set;
    }
    /// <summary>
    /// 根据属性名字获得相应的数值
    /// </summary>
    /// <param name="propertyName">属性名</param>
    /// <returns></returns>
    public override object GetValue(string propertyName)
    {
        var type = GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(this, null);//用pi.GetValue获得值
            if (value1.GetType() != typeof(int) && value1.GetType() != typeof(string))
            {
                DataStruct.Article ar = value1 as DataStruct.Article;
                var t = ar.GetValue(propertyName);

                if (t != null)
                {
                    return t;
                }
            }
            else
            {
                if (pi.Name == propertyName)
                {
                    return value1;
                }
            }
        }
        return -1;
    }
    /// <summary>
    /// 根据属性名字设定相应的数值
    /// </summary>
    /// <param name="propertyName">属性名</param>
    /// <param name="num">数值</param>
    public override bool SetValue(string propertyName, object num)
    {
        var type = GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(this, null);//用pi.GetValue获得值
            if (value1.GetType() != typeof(int) && value1.GetType() != typeof(string))
            {
                DataStruct.Article ar = value1 as DataStruct.Article;
               
                //GetType().GetProperty(propertyName).SetValue(this, num, null);
                if (ar.SetValue(propertyName, num))
                {
                    return true;
                }
            }
            else
            {
                if (pi.Name == propertyName)
                {
                    pi.SetValue(this, num, null);
                    return true;
                }              
            }
        }
        return false;
    }
}