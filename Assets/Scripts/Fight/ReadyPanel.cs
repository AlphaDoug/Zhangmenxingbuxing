using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ReadyPanel : MonoBehaviour {
    private Button startButton;
    public GameObject Switch;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public ReadyHero[]  hero;
    public Text errorLog;

    private Dictionary<ReadyHero, GameObject> dic = new Dictionary<ReadyHero, GameObject>();
    // Use this for initialization
    void OnEnable () {
        dic = new Dictionary<ReadyHero, GameObject>();
        dic.Add(hero[0], player1);
        dic.Add(hero[1], player2);
        dic.Add(hero[2], player3);
        dic.Add(hero[3], player4);
        foreach (ReadyHero her in hero)
        {
            GameObject d_player;
            dic.TryGetValue(her, out d_player);
            d_player.SetActive(false);
        }
        startButton = transform.Find("Start").GetComponent<Button>();
        startButton.onClick.AddListener(() => {
            int count = 0;
            
            foreach (ReadyHero her in hero)
            {
                if (!her.i.Equals("noChoose"))
                {
                   // Debug.Log("执行");
                    count++;
                    GameObject d_player;
                    dic.TryGetValue(her, out d_player);
                    d_player.SetActive(true);
                    d_player.GetComponent<PlayerFight>().HP = 100;
                }
            }
            if (count<= 0)
            {
                Switch.SetActive(false);
                Switch.GetComponent<SwitchManager>().enabled = false;
                errorLog.gameObject.SetActive(true);

                errorLog.DOFade(255, 3f).OnComplete(()=> { errorLog.gameObject.SetActive(false); });
               
            }
            else
            {
                Switch.SetActive(true);
                Switch.GetComponent<SwitchManager>().enabled = true;
                GameObject.Find("Fight").SetActive(false);
                Facade.Instance.PlayBgSound(AudioManager.Sound_FightBGM);
            }
            
            
        });
    }

    void Dispare()
    {
        errorLog.gameObject.SetActive(false);
    }
    
}
