﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hechengResult_addItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("Panel_加速").GetComponent<DestroyComp>().onClick_hechengResult);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
