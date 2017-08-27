using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_hecheng : MonoBehaviour {

    public GameObject Panel_hecheng;
    public GameObject maxWarning;
    public GameObject notEnoughWarning;
	private float ClickTime;

    private bool he_cheng=false;

    private judge_hecheng jh;

    void Start () {
		ClickTime = Time.time - 3f;
	}
	
	void Update () {
		
    }

    public void panelHechengActive()
    {
		jh = GameObject.Find ("Canvas_合成/Image_judge").GetComponent<judge_hecheng> ();

		if (CountText.count == CountText.maximum) {
			if (Time.time - ClickTime >= 2.5f) {
				maxWarning.SetActive (true);
				GameObject.Find ("Text_maxwarning").GetComponent<MaxTextAnimation> ().Up ();
				ClickTime = Time.time;
			}
		}
		if (jh.judge_dizi&&jh.judge_juanzhou&&jh.judge_maobi&&CountText.count < CountText.maximum)
			Panel_hecheng.SetActive (true);
		if((!jh.judge_dizi||!jh.judge_juanzhou||!jh.judge_maobi)&&CountText.count < CountText.maximum)
			notEnoughWarning.SetActive(true);
    }
		
}
