using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EventControl :MonoBehaviour,EventInterface{

	//private bool LevelUpPD=false;
	
	public void LeftButton0(){Debug.Log ("0");}

	public void LeftButton1(){Debug.Log ("1");}

	public void LeftButton2(){Debug.Log ("2");}

	public void LeftButton3(){Debug.Log ("3");}

	public void LeftButton4(){Debug.Log ("4");}

	public void LevelUpButton()
	{
		GameObject.Find ("Canvas/Home/InformationLayer").GetComponent<ZMJS_GetData> ().LevelUp ();
		GameObject.Find ("Canvas/Home/InformationLayer/LevelUpText").SetActive (true);
		GameObject.Find ("Canvas/Home/InformationLayer/LevelUpText").GetComponent<ZMJS_LevelUp> ().Up ();

	}
	public void LeavingButton(){Debug.Log ("Leaving");}


}
