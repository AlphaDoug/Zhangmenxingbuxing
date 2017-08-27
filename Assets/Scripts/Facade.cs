using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade : MonoBehaviour {

    private static Facade _instance;
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<Facade>();
            }
            return _instance;
        }
    }
    private AudioManager audioMng;
    void Start()
    {
        audioMng = new AudioManager(this);
        audioMng.OnInit();
    }

    public void PlayBgSound(string soundName)
    {
        audioMng.PlayBgSound(soundName);
    }

    public void PlayNormalSound(string soundName)
    {
        audioMng.PlayNormalSound(soundName);
    }
}
