using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
public class SQLiteLoad
{
    public static bool resLoaded = false;
    public static string loadName = "ConfData.bytes";
    public static string writeName = "ConfData.db";
    public static string tempPath = string.Empty;
    /*public SQLiteLoad()
    {

    }*/
    public static void OnLoadFile(string name, UnityEngine.Object obj)
    {
        SqliteConnection.ClearAllPools();
        if (name != loadName)
        {
            Debug.Log("invalid file: " + name + ", need: " + "ConfData.db");
            return;
        }
        TextAsset ta = obj as TextAsset;
        if (ta == null)
        {
            Debug.Log("text asset is null");
            return;
        }
        string cStr = string.Empty;//数据库位于工程的根目录
        if (Application.platform == RuntimePlatform.Android)
        {
            cStr = Application.persistentDataPath + "/" + writeName;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            cStr = Application.persistentDataPath + "/" + writeName;
        }
        else
        {
            string _tempPath = System.IO.Path.GetTempFileName();
            int _index = _tempPath.IndexOf(".tmp");
            string _newPath = _tempPath.Substring(0, _index);
            tempPath = _newPath;
            cStr = tempPath + "/" + writeName;
            Directory.CreateDirectory(tempPath);
        }
        if (File.Exists(cStr))
        {
            File.Delete(cStr);
        }
        var buffer = ta.bytes;
        FileStream fileStream = new FileStream(cStr, FileMode.Create);
        fileStream.Write(buffer, 0, buffer.Length);
        fileStream.Close();
        
        resLoaded = true;
        CacheLoaded();
        InitDB(GetDbPath());
        
    }
    /// <summary>
    /// 需要进游戏后加入内存在这里添加
    /// </summary>
    private static void CacheLoaded()
    {
        //ConfParam.cacheLoaded = true;
    }

    public static void LoadSQLite()
    {
        if (resLoaded)
            return;
        TextAsset conf = Resources.Load<TextAsset>("Config/ConfData");
        OnLoadFile("ConfData.bytes", conf);
    }
    public static void ReloadConfig(string filePath)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            return;
        }
        string _tempPath = System.IO.Path.GetTempFileName();
        int _index = _tempPath.IndexOf(".tmp");
        string _newPath = _tempPath.Substring(0, _index);
        tempPath = _newPath;
        string cStr = tempPath + "/" + writeName;
        Directory.CreateDirectory(tempPath);
        if (File.Exists(cStr))
        {
            File.Delete(cStr);
        }
        File.Copy(filePath, cStr);

        Debug.Log("Reload Config in " + tempPath);
        CacheLoaded();
        InitDB(GetDbPath());
    }
    private static string GetDbPath()
    {
        string cStr = string.Empty;//数据库位于工程的根目录
        if (Application.platform == RuntimePlatform.Android)
        {
            cStr = Application.persistentDataPath + "/" + writeName;
            cStr = "URI=file:" + cStr;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            cStr = Application.persistentDataPath + "/" + writeName;
            cStr = "data source=" + cStr;
        }
        else
        {
            cStr = SQLiteLoad.tempPath + "/" + writeName;
            cStr = "data source=" + cStr;
        }
        return cStr;
    }
    private static void InitDB(string dbPath)
    {
        if (SQLiteDB.Connected)
        {
            SQLiteDB.Close();
            SQLiteDB.Initialize(new Mono.Data.Sqlite.SqliteConnection(dbPath));
            ConfFact.ReloadConfig();
        }
        else
        {
            SQLiteDB.Initialize(new Mono.Data.Sqlite.SqliteConnection(dbPath));
            ConfFact.Register();
        }
    }
}