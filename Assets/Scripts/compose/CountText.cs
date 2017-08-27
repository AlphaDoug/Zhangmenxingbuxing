using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour {

    public Text countText;
    public static int maximum=10;
    public static int count=0;
    public GameObject textMaxQuest;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        countText.text = count+"/" + maximum;
        if (count == maximum)
            textMaxQuest.SetActive(true);
    }

}
