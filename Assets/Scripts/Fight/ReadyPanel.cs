using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    void Start () {
        
        dic.Add(hero[0], player1);
        dic.Add(hero[1], player2);
        dic.Add(hero[2], player3);
        dic.Add(hero[3], player4);

        
        startButton = transform.Find("Start").GetComponent<Button>();
        startButton.onClick.AddListener(() => {
            int count = 0;
            Switch.SetActive(true);
            foreach (ReadyHero her in hero)
            {
                if (!her.i.Equals("noChoose"))
                {
                    count++;
                    GameObject d_player;
                    dic.TryGetValue(her, out d_player);
                    d_player.SetActive(true);
                }
            }
            if (count<= 0)
            {
                Switch.SetActive(false);
                errorLog.gameObject.SetActive(true);
            }
            else
            GameObject.Find("Fight").SetActive(false);
            Facade.Instance.PlayNormalSound(AudioManager.Sound_FightBGM);
        });
    }

    
}
