using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetZero : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (GameObject.Find ("Panel_加速").GetComponent<DestroyComp> ().timeSetZero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
