using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 任务界面功能
/// </summary>
public class MissionInfo : MonoBehaviour
{

    public int ID;
    public string dec;

    private GameObject taskUI;
    private GameObject gameController;
    /// <summary>
    /// 拒绝开关
    /// </summary>
    public void NoPress()
    {
        gameController.GetComponent<MissionController>().currentTasksNum--;
        Destroy(gameObject);
    }
    /// <summary>
    /// 接收开关
    /// </summary>
    public void YesPress()
    {
        gameController.GetComponent<MissionController>().currentTasksNum--;
        Destroy(gameObject);
        taskUI.SetActive(false);
        GameObject newConversation = Instantiate((GameObject)Resources.Load("Prefabs/Conversation"), Vector3.zero, new Quaternion(), GameObject.Find("Canvas").transform);
        newConversation.GetComponent<RectTransform>().localPosition = new Vector3(0,-360,0);
        newConversation.GetComponent<ConversationFrame>().m_ID = ID;
    }
   
    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        taskUI = transform.parent.parent.parent.parent.gameObject;
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "decription")
            {
                child.gameObject.GetComponent<Text>().text = dec;
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
