using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwordsmanGame;

public class MissionController : MonoBehaviour
{
    public GameObject taskUI;  
    public GameObject taskList;
    public int[] missionID = { 301, 302, 303, 304, 305, 306 };
    public int minTimeInterval = 300;
    public int maxTimeInterval = 600;
    public static event GameController.HaveNewTasks HaveNewTasksEvent;
    public int currentTasksNum;

    private bool[] isMissionShown;
    private Confmission confmission;
    private GameObject missionObject;
    private int randomIndex;
    private bool[] allTrue;
    private List<int> currentMissionID;
    private Vector2 taskListSize;

    void Start()
    {
        currentTasksNum = 0;
        currentMissionID = new List<int>();
        isMissionShown = new bool[missionID.Length];
        allTrue = new bool[missionID.Length];
        for (int i = 0; i < allTrue.Length; i++)
        {
            allTrue[i] = true;
        }
        missionObject = (GameObject)Resources.Load("Prefabs/task");
        SQLiteLoad.LoadSQLite();
        StartCoroutine(CreatTaskByTime());

    }

	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            CreateTask();
        }

    }

    private void CreateTask()
    {
        if (CompareArray(isMissionShown,allTrue))
        {
            Debug.Log("所有任务均出现过");
            return;
        }
        //随机生成一个不重复的任务ID并add进currentMissionID中
        randomIndex = UnityEngine.Random.Range(0, missionID.Length);
        while (isMissionShown[randomIndex])
        {
            randomIndex = UnityEngine.Random.Range(0, missionID.Length);          
        }
        Confmission.GetConfig(missionID[randomIndex] * 100, out confmission);
        if (confmission.lost != "null")//若有失去的物品
        {
            var lostString = confmission.lost.Split('|');
            for (int i = 0; i < lostString.Length; i++)
            {
                if ((int)GameDataManager.data.GetValue(lostString[i]) == 0)
                {
                    return;
                }
            }
            isMissionShown[randomIndex] = true;
            currentMissionID.Add(missionID[randomIndex] * 100);
        }
        else
        {
            isMissionShown[randomIndex] = true;
            currentMissionID.Add(missionID[randomIndex] * 100);
        }
        
    }
    /// <summary>
    /// 数组比较是否相等
    /// </summary>
    /// <param name="bt1">数组1</param>
    /// <param name="bt2">数组2</param>
    /// <returns>true:相等，false:不相等</returns>
    private bool CompareArray(bool[] bt1, bool[] bt2)
    {
        var len1 = bt1.Length;
        var len2 = bt2.Length;
        if (len1 != len2)
        {
            return false;
        }
        for (var i = 0; i < len1; i++)
        {
            if (bt1[i] != bt2[i])
                return false;
        }
        return true;
    }

    public void TaskUI_IsActive_True()
    {
        var count = currentMissionID.Count;
        for (int i = 0; i < count; i++)
        {

            Confmission.GetConfig(currentMissionID[0], out confmission);

            taskListSize = taskList.GetComponent<RectTransform>().sizeDelta;
            taskList.GetComponent<RectTransform>().sizeDelta = new Vector2(taskListSize.x, taskListSize.y + 204);

            GameObject newTask = Instantiate(missionObject);
            newTask.transform.SetParent(taskList.transform);
            newTask.transform.localPosition = newTask.transform.localPosition - new Vector3(0, 0, newTask.transform.localPosition.z);
            newTask.transform.localScale = new Vector3(1, 1, 1);
            newTask.GetComponent<MissionInfo>().ID = currentMissionID[0];
            newTask.GetComponent<MissionInfo>().dec = confmission.missiondesc;

            currentMissionID.RemoveAt(0);
            currentTasksNum++;
        }
    }

    IEnumerator CreatTaskByTime()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeInterval, maxTimeInterval));
        StartCoroutine(CheckTaskNum());//启动检查任务数量协程
        while (!CompareArray(isMissionShown, allTrue))
        {
            CreateTask();
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeInterval, maxTimeInterval));
        }
        Debug.Log("所有任务均出现过");
    }
    /// <summary>
    /// 检查任务数量并通知红点
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckTaskNum()
    {
        while (true)
        {
            if (currentTasksNum <= 0)
            {
                //HaveNewTasksEvent(false);
                GameObject.Find("MissionBtn").SendMessage("MissionController_HaveNewTasksEvent", false);
            }
            if (currentMissionID.Count > 0)
            {
                //HaveNewTasksEvent(true);
                GameObject.Find("MissionBtn").SendMessage("MissionController_HaveNewTasksEvent", true);
                //Facade.Instance.PlayNormalSound(AudioManager.Sound_Warning);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
