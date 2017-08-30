using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zhongzhi_returnItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("Panel_终止").GetComponent<DestroyComp>().itemReturn);
    }
}
