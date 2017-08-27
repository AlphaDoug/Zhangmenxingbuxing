using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Button_enter : MonoBehaviour {

    public GameObject name_school;
    public GameObject Canvas2;

    public Text schoolname;
    public Text infor;
    private string judge;
    public Text warning;
    private void Awake()
    {
        Time.timeScale = 0;
    }
    // Use this for initialization
    void Start () {

        GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().SetisUIAble(true);
        warning.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        judge = schoolname.text;
        infor.text = "门派命名成功:" + judge;
    }

    public void clearname_school()
    {
        if (judge != "")
        {
            warning.text = "";
            name_school.SetActive(false);
            Canvas2.SetActive(true);
            GameDataManager.data.SetValue("menpaimingcheng", judge);
        }
        else
            warning.text = "您还未输入门派名！";
    }

    public void destroy_ui()
    {
        Canvas2.SetActive(false);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().SetisUIAble(false);
    }

    public void ui_rename()
    {
        Canvas2.SetActive(false);
        name_school.SetActive(true);
    }
}
