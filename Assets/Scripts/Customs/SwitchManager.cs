using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    public FightManager fight;
    public EnemyFight[] enemy;
    public PlayerFight[] player;
    private void OnEnable()
    {
        foreach(EnemyFight enem in enemy)
        {
            enem.enabled = true;
        }
        /*enemy[0].gameObject.transform.position = new Vector3(0, 0, 3.54f);
        enemy[0].gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        enemy[1].gameObject.transform.position = new Vector3(-3, 0, 3.54f);
        enemy[1].gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        enemy[2].gameObject.transform.position = new Vector3(3, 0, 3.54f);
        enemy[2].gameObject.transform.eulerAngles = new Vector3(0, 180, 0);*/
        foreach (PlayerFight play in player)
        {
            play.enabled = true;
        }
        fight.enabled = true;
    }

    private void OnDisable()
    {
        foreach (EnemyFight enem in enemy)
        {
            enem.enabled = false;
        }
        foreach (PlayerFight play in player)
        {
            play.enabled = false;
        }
        fight.enabled = false;
    }
}
