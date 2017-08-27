using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_exit : MonoBehaviour {

    public GameObject Canvas;

    public void clear_all()
    {
        Canvas.SetActive(false);
    }

}
