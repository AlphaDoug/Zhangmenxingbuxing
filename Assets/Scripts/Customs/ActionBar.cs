using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

    public float speed=1;//行动条速度

	void Update () {
        if (FightManager.main.state == FightState.Computer)//如果是非敌人控制也非主角控制，行动条才能行动
        {

            /*if (transform.GetComponent<UISlider>().value <1)
            {
                transform.GetComponent<UISlider>().value += speed / 1000f;
            }*/

            if (transform.GetComponent<Scrollbar>().value < 1)
            {
                transform.GetComponent<Scrollbar>().value += speed / 1000f;
            }
        }
	}
}
