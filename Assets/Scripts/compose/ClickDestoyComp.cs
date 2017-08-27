using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDestoyComp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (GameObject.Find ("Panel_终止").GetComponent<DestroyComp> ().desComp);
        //gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("Panel_终止").GetComponent<DestroyComp>().itemReturn);
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("Panel_终止").GetComponent<DestroyComp>().lengthChange);
        gameObject.GetComponent<Button> ().onClick.AddListener (GameObject.Find ("Panel_加速").GetComponent<DestroyComp> ().desComp);
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("Panel_加速").GetComponent<DestroyComp>().countDecrease);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
