using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;
using System.Security.Cryptography;

/// <summary>
/// GameData,储存数据的类，把需要储存的数据定义在GameData之内就行
/// </summary>
public class GameData
{
    //密钥,用于防止拷贝存档//
    public string key;

    //下面是添加需要储存的内容//
    public DataStruct.Equipment equipment = new DataStruct.Equipment();
    public DataStruct.Material material = new DataStruct.Material();
    public DataStruct.Book book = new DataStruct.Book();
    public DataStruct.Medicine medicine = new DataStruct.Medicine();
    public DataStruct.Special special = new DataStruct.Special();
    public string menpaimingcheng;
    public string paimeng;
    public int rushidizi;
    public int waiweidizi;
    public int maxrushidizi;
    public int maxwaiweidizi;
    public int minrushidizi;
    public int minwaiweidizi;
    public int shengwangzhi;
    public int shanezhi;
    public int huobi;


}

/// <summary>
/// 管理数据储存的类，并控制游戏数据的自动
/// </summary>
public class GameDataManager : MonoBehaviour
{
    private string dataFileName = "SwordManData.dat";//存档文件的名称,自己定//
    private XmlSaver xs = new XmlSaver();

    public GameData gameData = new GameData();
    public static GlobalData data ;
    public GameObject startInfo;
    public void Awake()
    {
        data = new GlobalData();
        if (PlayerPrefs.GetString("isFirstStart") == "")
        {
            //是首次启动游戏。设置isFirstStart字段为false
            PlayerPrefs.SetString("isFirstStart", "false");

            data.book.beimingshengong = 2;
            data.book.qingchengxinfa = 2;

            data.material.baimazhi = 1;
            data.material.chengxintangzhi = 1;
            data.material.ciqingzhi = 1;
            data.material.miaojinyunlong = 1;
            data.material.sajinzhi = 1;
            data.material.tengzhi = 1;
            data.material.xiangyalanghao = 1;
            data.material.yanghaobi = 1;
            data.material.yusunbi = 1;
            data.material.yuzanzihao = 1;

            data.waiweidizi = 12;
            data.shanezhi = 500;
            data.menpaimingcheng = "我擦";
            data.shengwangzhi = 0;
            data.huobi = 5000;

            startInfo.SetActive(true);
        }
        else
        {
            startInfo.SetActive(false);
            PlayerPrefs.DeleteAll();
            //不是首次启动游戏，则读取存储的数据
            gameData = new GameData();
            //设定密钥，根据具体平台设定//
            gameData.key = SystemInfo.deviceUniqueIdentifier;
            Load();
            RefuseClone();
        }
    }

    /// <summary>
    /// 存储数据时调用此函数
    /// </summary>
    public void Save()
    {
        //先将静态字段拷贝到一个不包含静态字段的类中
        Clone();
        string gameDataFile = GetDataPath() + "/" + dataFileName;
        string dataString = xs.SerializeObject(gameData, typeof(GameData));
        xs.CreateXML(gameDataFile, dataString);
    }

    //读档时调用的函数//
    public void Load()
    {
        string gameDataFile = GetDataPath() + "/" + dataFileName;
        if (xs.hasFile(gameDataFile))
        {
            string dataString = xs.LoadXML(gameDataFile);
            GameData gameDataFromXML = xs.DeserializeObject(dataString, typeof(GameData)) as GameData;

            if (gameDataFromXML != null)
            {
                gameData = gameDataFromXML;
            }
            else
            {
                Debug.LogError("数据读取出错");
            }
        }
        else
        {
            if (gameData != null)
                Save();
        }
    }

    //获取路径//
    private static string GetDataPath()
    {
        // Your game has read+write access to /var/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/Documents
        // Application.dataPath returns ar/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/myappname.app/Data             
        // Strip "/Data" from path
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            // Strip application name
            path = path.Substring(0, path.LastIndexOf('/'));
            return path + "/Documents";
        }
        else
            //    return Application.dataPath + "/Resources";
            return Application.dataPath;
    }
    /// <summary>
    /// 讲全局数据类拷贝到gameData中
    /// </summary>
    public void Clone()
    {
        gameData.book = data.book;
        gameData.equipment = data.equipment;
        gameData.huobi = data.huobi;
        gameData.material = data.material;
        gameData.maxrushidizi = data.maxrushidizi;
        gameData.maxwaiweidizi = data.waiweidizi;
        gameData.medicine = data.medicine;
        gameData.menpaimingcheng = data.menpaimingcheng;
        gameData.minrushidizi = data.minrushidizi;
        gameData.minwaiweidizi = data.minwaiweidizi;
        gameData.paimeng = data.paimeng;
        gameData.rushidizi = data.rushidizi;
        gameData.shanezhi = data.shanezhi;
        gameData.shengwangzhi = data.shengwangzhi;
        gameData.special = data.special;
        gameData.waiweidizi = data.waiweidizi;
    }

    public void RefuseClone()
    {
        data.book = gameData.book;
        data.equipment = gameData.equipment;
        data.huobi = gameData.huobi;
        data.material = gameData.material;
        data.maxrushidizi = gameData.maxrushidizi;
        data.maxwaiweidizi = gameData.waiweidizi;
        data.medicine = gameData.medicine;
        data.menpaimingcheng = gameData.menpaimingcheng;
        data.minrushidizi = gameData.minrushidizi;
        data.minwaiweidizi = gameData.minwaiweidizi;
        data.paimeng = gameData.paimeng;
        data.rushidizi = gameData.rushidizi;
        data.shanezhi = gameData.shanezhi;
        data.shengwangzhi = gameData.shengwangzhi;
        data.special = gameData.special;
        data.waiweidizi = gameData.waiweidizi;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}