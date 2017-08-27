using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ConversationFrame : MonoBehaviour
{
    public enum ConversationState
    {
        noneSonNode = 0,
        moreThanTwoSonNode = 1,
        battleNode = 2
    }

    public int m_ID;
    public float letterPause = 0.2f;
    public float twoChoiceBoxDistance = 25f;
    public GameObject taskComplete;
    public GameObject content;

    private GameObject choiceObject;
    private GameObject conversation;

    private string[] m_choose;
    private int[] m_NextID;
    private string m_Text;
    private GameObject[] m_chooseFrame;
    private ConversationState m_ConversationState;
    private bool isShowing;
    private string word;
    private Text text;
    private string[] m_SingleSentences;
    private int m_CurrentSentenceIndex;
    private bool isChoiceBoxShown;
    private string[] m_CurrentCharacter;
    private Image m_TalkerImage;
    private Confmission confMission;
    private GameObject gameController;
    private GameObject battleInterface;
    private GameObject fightManager;
    private GameObject fightSwitch;
    // Use this for initialization
    void Start()
    {
        var allObj = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int i = 0; i < allObj.Length; i++)
        {
            if (allObj[i].name == "Fight")
            {
                battleInterface = allObj[i];
               
            }
            if (allObj[i].name == "FightSwitch")
            {
                fightSwitch = allObj[i];

            }
        }
        foreach (Transform child in fightSwitch.transform)
        {
            if (child.gameObject.name == "FightManager")
            {
                fightManager = child.gameObject;
            }
        }
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameController.GetComponent<UIController>().SetisUIAble(true);
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Text")
            {
                text = child.gameObject.GetComponent<Text>();
            }
            if (child.gameObject.name == "Talker")
            {
                m_TalkerImage = child.gameObject.GetComponent<Image>();
            }
        }
        
        #region 初始化配置
        conversation = (GameObject)Resources.Load("Prefabs/Conversation");
        choiceObject = (GameObject)Resources.Load("Prefabs/ChoiceBox");
        SQLiteLoad.LoadSQLite();
        
        var isSuccessedLoaded = Confmission.GetConfig(m_ID, out confMission);
        if (!isSuccessedLoaded)
        {
            Debug.LogError("读取配置出错！");
            return;
        }
        #endregion

        #region 读取配置
        m_choose = confMission.choose.Split('|');
        m_Text = confMission.talk;
        if (confMission.find != "null")
        {
            m_NextID = Array.ConvertAll<string, int>(confMission.find.Split(','), s => int.Parse(s));
        }
        else
        {
            m_NextID = new int[0];
        }
        m_SingleSentences = m_Text.Split('|');
        if (m_SingleSentences == null)
        {
            m_SingleSentences = new string[1];
            m_SingleSentences[0] = m_Text;
        }
        m_CurrentCharacter = new string[m_SingleSentences.Length];
        for (int i = 0; i < m_SingleSentences.Length; i++)
        {
            m_CurrentCharacter[i] = m_SingleSentences[i].Split('@')[1];
            m_SingleSentences[i] = m_SingleSentences[i].Split('@')[0];
        }
        ////设置当前的m_ID，根据此ID读配置文件。获取对应的文字以及下一个（几个）节点，放在m_NextID中,获取任务发起者
        m_chooseFrame = new GameObject[m_NextID.Length];
        if (m_chooseFrame.Length == 0)
        {
            //表示此段文字是尾节点
            m_ConversationState = ConversationState.noneSonNode;
        }
        if (m_chooseFrame.Length >= 2)
        {
            if (confMission.choose == "战斗")
            {
                //表示当前节点有战斗
                m_ConversationState = ConversationState.battleNode;
            }
            else
            {
                //表示当前节点存在选项
                m_ConversationState = ConversationState.moreThanTwoSonNode;
                isChoiceBoxShown = false;
            }
            
        }

        #endregion
        word = m_SingleSentences[0];
        SetTalkerAnimation(0);
        m_CurrentSentenceIndex = 0;
        text.text = "";
        StartCoroutine(TypeText());

        ChoiceBox.OnMouseDownEvent_Choice += ChoiceBox_OnMouseDownEvent_Choice;
    }
    /// <summary>
    /// 此类创建的选择按钮的回调事件
    /// </summary>
    /// <param name="sender">回调事件发起者</param>
    /// <param name="index">参数</param>
    private void ChoiceBox_OnMouseDownEvent_Choice(object sender, int index)
    {
        Destroy(this);
        Destroy(gameObject);
        GameObject newConversation = Instantiate(conversation, gameObject.transform.position, new Quaternion(), GameObject.Find("Canvas").transform);
        newConversation.GetComponent<ConversationFrame>().m_ID = m_NextID[index];
        //newConversation.GetComponent<ConversationFrame>().conversation = conversation;

    }

    private IEnumerator TypeText()
    {
        isShowing = true;
        foreach (char letter in word.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        isShowing = false;
    }

    private void OnDestroy()
    {
        ChoiceBox.OnMouseDownEvent_Choice -= ChoiceBox_OnMouseDownEvent_Choice;
       
    }

    private void OnMouseDown()
    {
        if (isShowing)
        {
            //正在动态显示文字，那么点击鼠标时候加速显示文字
            letterPause = 0.04f;
            return;
        }
        else
        {
            if (m_CurrentSentenceIndex < m_SingleSentences.Length - 1)
            {
                letterPause = 0.2f;
                text.text = "";
                m_CurrentSentenceIndex++;
                word = m_SingleSentences[m_CurrentSentenceIndex];
                SetTalkerAnimation(m_CurrentSentenceIndex);
                StartCoroutine(TypeText());
                return;
            }
            //文字显示完毕，但是当前选择框未显示，则显示选择框
            if (m_ConversationState == ConversationState.moreThanTwoSonNode)
            {
                if (!isChoiceBoxShown)
                {
                    for (int i = 0; i < m_chooseFrame.Length; i++)
                    {
                        //表示有两个或者以上的子节点，动态创建相应的选项
                        //根据下一个节点数量来创建选择按钮
                        m_chooseFrame[i] = Instantiate(choiceObject);
                        m_chooseFrame[i].GetComponent<Transform>().parent = content.transform;
                        m_chooseFrame[i].GetComponent<Transform>().localPosition = Vector3.zero;
                        m_chooseFrame[i].GetComponent<Transform>().localScale = Vector3.one;
                        m_chooseFrame[i].GetComponent<ChoiceBox>().index = i;
                        m_chooseFrame[i].GetComponent<ChoiceBox>().content = m_choose[i];
                    }
                    isChoiceBoxShown = true;
                }
            }
            //若当前节点存在战斗，则调用战斗系统
            else if (m_ConversationState == ConversationState.battleNode)
            {



                battleInterface.SetActive(true);
                StartCoroutine(WaitForBattleResult());
            }
            //若当前没有下一个对话，则结束对话，进行任务结算
            else if (m_ConversationState == ConversationState.noneSonNode)
            {
                Destroy(gameObject);
                gameController.GetComponent<UIController>().SetisUIAble(false);
                var tas = Instantiate(taskComplete);
                string[] lostString;
                string[] gainString;

                if (confMission.gain.Split('|') != null)
                {
                    gainString = confMission.gain.Split('|');
                }
                else
                {
                    gainString = new string[1];
                    gainString[0] = confMission.gain;
                }

                for (int i = 0; i < gainString.Length; i++)
                {
                    if (gainString[i] == "null")
                    {
                        continue;
                    }
                    GameDataManager.data.SetValue(gainString[i], (int)GameDataManager.data.GetValue(gainString[i]) + 1);
                    //if (gainString[i] == "baimazhi")
                    //{
                    //    GlobalData.material.baimazhi++;
                    //}
                    //if (gainString[i] == "yanghaobi")
                    //{
                    //    GlobalData.material.yanghaobi++;
                    //}
                    //if (gainString[i] == "qiguaidebaoguo")
                    //{
                    //    GlobalData.special.qiguaidebaoguo++;
                    //}
                }
                if (confMission.lost.Split('|') != null)
                {
                    lostString = confMission.lost.Split('|');
                }
                else
                {
                    lostString = new string[1];
                    lostString[0] = confMission.lost;
                }

                for (int i = 0; i < lostString.Length; i++)
                {
                    if (lostString[i] == "null")
                    {
                        continue;
                    }
                    GameDataManager.data.SetValue(lostString[i], (int)GameDataManager.data.GetValue(lostString[i]) - 1);
                    //if (lostString[i] == "jingshitongyan")
                    //{
                    //    GlobalData.book.jingshitongyan--;
                    //}
                    //if (lostString[i] == "qiguaidebaohuo")
                    //{
                    //    GlobalData.special.qiguaidebaoguo--;
                    //}
                }
                GameDataManager.data.SetValue("huobi", (int)GameDataManager.data.GetValue("huobi") + confMission.money);
                GameDataManager.data.SetValue("shanezhi", (int)GameDataManager.data.GetValue("shanezhi") + confMission.justice);
                GameDataManager.data.SetValue("shengwangzhi", (int)GameDataManager.data.GetValue("shengwangzhi") + confMission.prestige);
                GameDataManager.data.SetValue("jingyan", (int)GameDataManager.data.GetValue("jingyan") + confMission.experience);

                //GlobalData.huobi += confMission.money;//根据结算修改货币
                //GlobalData.shanezhi += confMission.justice;//根据结算修改善恶值
                //GlobalData.shengwangzhi += confMission.prestige;//根据结算修改声望值
                //GlobalData.jingyan += confMission.experience;//根据结算修改经验

                Debug.Log("奖励道具" + confMission.gain + "奖励善恶" + confMission.justice + "奖励经验" + confMission.experience + "失去道具" + confMission.lost + "奖励货币" + confMission.money + "奖励声望" + confMission.prestige);
                tas.GetComponent<taskComplete>().confmission = confMission;
                tas.transform.parent = GameObject.Find("Canvas").transform;
                tas.transform.localPosition = Vector3.zero;
                tas.transform.localScale = Vector3.one;
            }
            
        }
    }

    /// <summary>
    /// 设置当前说话的人物的头像
    /// </summary>
    /// <param name="index">当前句子的下标</param>
    private void SetTalkerAnimation(int index)
    {

        Sprite sprite = Resources.Load("Sprite/UI/chara/" + m_CurrentCharacter[index], typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            m_TalkerImage.gameObject.SetActive(true);
            m_TalkerImage.sprite = sprite;
            m_TalkerImage.SetNativeSize();
        }
        else
        {
            m_TalkerImage.gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitForBattleResult()
    {
        yield return new WaitForSeconds(3.5f);
        while (true)
        {
            if (fightManager.GetComponent<FightManager>().m_state == "You Win")
            {
                Debug.Log("胜利");
                StopCoroutine(WaitForBattleResult());
                ChoiceBox_OnMouseDownEvent_Choice(this, 0);
            }
            if (fightManager.GetComponent<FightManager>().m_state == "GameOver")
            {
                Debug.Log("失败");
                StopCoroutine(WaitForBattleResult());
                ChoiceBox_OnMouseDownEvent_Choice(this, 1);
            }
            if (fightManager.GetComponent<FightManager>().m_state == "Fighting")
            {
                Debug.Log("战斗未结束");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
