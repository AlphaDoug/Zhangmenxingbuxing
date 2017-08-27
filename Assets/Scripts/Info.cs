using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {
    ConfPlayerProperty confPlane;
    InformationPanel information;
    public int attack;
    // Use this for initialization
    void Start () {
        SQLiteLoad.LoadSQLite();
        ConfPlayerProperty.GetConfig(transform.name, out confPlane);
        attack = confPlane.attack;
        information = GameObject.Find("FollowerCanvas/Information").GetComponent<InformationPanel>();
        Debug.Log(attack);
        
    }
	
	// Update is called once per frame
	void Update () {
        information.Set();	
    }
}
