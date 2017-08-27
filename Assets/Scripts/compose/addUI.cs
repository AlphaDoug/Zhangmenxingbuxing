using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addUI : MonoBehaviour {

	private Button accelerate;
	private Button exit;

	// Use this for initialization
	void Start () {
		accelerate = transform.Find ("Button_加速").GetComponent<Button> ();
		accelerate.onClick.AddListener (ButtonAccelerate);
		exit = transform.Find ("Button_终止").GetComponent<Button> ();
		exit.onClick.AddListener (ButtonExit);
	}

	// Update is called once per frame
	void Update () {

	}

	private void ButtonExit()
	{
		GameObject.FindGameObjectWithTag ("Panel_Exit").GetComponent<Button_Active> ().active();
		GameObject.Find ("Panel_终止").GetComponent<DestroyComp> ().setComp (gameObject);
        GameObject.Find("Panel_终止").GetComponent<DestroyComp>().GetName(gameObject);

    }

	private void ButtonAccelerate()
	{
		GameObject.FindGameObjectWithTag ("Panel_Accelerate").GetComponent<Button_Active> ().active ();
		GameObject.Find ("Panel_加速").GetComponent<DestroyComp> ().setComp (gameObject);
		GameObject.Find ("Panel_加速").GetComponent<DestroyComp> ().setComp2 (gameObject);
        GameObject.Find("Panel_加速").GetComponent<DestroyComp>().setComp3(gameObject);
        GameObject.FindGameObjectWithTag("Panel_Accelerate").GetComponent<DestroyComp>().jiasuquan();
        GameObject.Find("Panel_终止").GetComponent<DestroyComp>().GetName(gameObject);
    }
}