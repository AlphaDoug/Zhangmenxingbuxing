using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum FightState { 
    Player,
    Enemy,
    Computer,
    Quit
}

public class FightManager : MonoBehaviour {

    public static FightManager main;
    public FightState state = FightState.Computer;
    public ArrayList enemys=new ArrayList();

    public ArrayList  players=new ArrayList();
    private bool isQuit = false;

    public string m_state = "Fighting";
    public GameObject winText;
    public GameObject loseText;

    public GameObject Fight;
    public GameObject Switch;
    public GameObject Action;
    public GameObject[] player;
    public GameObject[] enemy;
    
	void OnEnable () {
        state = FightState.Computer;
        enemys = new ArrayList();
        players = new ArrayList();
        isQuit = false;
        //Debug.Log("Once FightManager执行");
        main = this;
        m_state = "Fighting";
        winText.SetActive(false);
        loseText.SetActive(false);
        GameObject[] pls=GameObject.FindGameObjectsWithTag(Tags.Player);
        GameObject[] es=GameObject.FindGameObjectsWithTag(Tags.Enemy);
        for (int i = 0; i < pls.Length; i++)
        { 
           players.Add(pls[i]);
        }
        for (int i = 0; i < es.Length; i++)
        {
            enemys.Add(es[i]);
        }
	}
    public void FinishRound()
    {
        if (isQuit)
        {
            state = FightState.Quit;
        }
        else {
            state = FightState.Computer;
        }
    }

    public void CostEnemyCount()
    {

        enemys.RemoveAt(0);
        if (enemys.Count <= 0)
        {
            m_state = "You Win";
            winText.SetActive(true);
            Invoke("QuitFight",5f);//3秒后退出
            Invoke("QuitQuit",0f);
        }
    }

    public void CostPlayerCount()
    {
        players.RemoveAt(0);
        if (players.Count <= 0)
        {
            m_state = "GameOver";
            loseText.SetActive(true);
            Invoke("QuitFight", 5f);
            Invoke("QuitQuit", 0f);
        }
    }
    void QuitQuit()
    {
        isQuit = true;
    }
    //在这里退出战斗
    void QuitFight()
    {
        //Fight.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            enemy[i].GetComponent<EnemyFight>().InitialTrans();
        }
        for (int i = 0; i < 4; i++)
        {
            player[i].GetComponent<PlayerFight>().InitialTrans();
        }

        winText.SetActive(true);
        loseText.SetActive(true);
        for(int i = 0; i < Action.transform.childCount; i++)
        {
           // Action.transform.GetChild(1).gameObject.GetComponent<Scrollbar>
            Destroy(Action.transform.GetChild(i).gameObject);
        }
        Action.SetActive(true);
        foreach(GameObject play in player)
        {
            play.SetActive(false);
        }
        foreach(GameObject enem in enemy)
        {
            enem.SetActive(true);
        }
        state = FightState.Computer;
        m_state = "null";
        Switch.GetComponent<SwitchManager>().enabled = false;
        Switch.SetActive(false);
    }

    
}
