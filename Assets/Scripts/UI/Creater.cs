using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creater : MonoBehaviour {

    public Image creater;

    public void GetIt() {
        creater.gameObject.SetActive(true);
    }

    public void CloseIt()
    {
        creater.gameObject.SetActive(false);
    }
}
