using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConf : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        SQLiteLoad.LoadSQLite();
        Confmission confMission;
        var isSuccessedLoaded = Confmission.GetConfig(30100, out confMission);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
