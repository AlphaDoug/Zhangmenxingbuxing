using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_shaixuan : MonoBehaviour {

    private bool judge=false;
    public GameObject Panel_shaixuan;

	// Use this for initialization
	void Start () {
        
	}
	
	public void clickButton()
    {
        judge = !judge;
        Panel_shaixuan.SetActive(judge);
    }
}
