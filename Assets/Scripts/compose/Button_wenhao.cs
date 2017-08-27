using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_wenhao : MonoBehaviour {

    private bool judge=false;
    public GameObject introduction;

    void Start()
    {
        
    }

    public void clickwenhao()
    {
        judge = !judge;
        introduction.SetActive(judge);
    }
}
