using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Active : MonoBehaviour {

    public GameObject setactive;

	public void active()
    {
		Debug.Log (setactive);
        setactive.SetActive(true);
    }
}
