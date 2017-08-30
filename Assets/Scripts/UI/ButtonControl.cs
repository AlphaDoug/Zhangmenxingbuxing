using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour

{
    public Text name;
    public Text shengwang;
	public Image shanezhi;

	private Button[] buttons;
	private Button LevelUpButton;
	private Button LeavingButton;
	private EventControl m_event;
	private float LevelUpTime = 0;
	EventInterface m_interface;

	void Start () {
		buttons = new Button[10];
		m_interface = GameObject.Find ("EventSystem").GetComponent<EventControl> ();
		buttons[0] = GameObject.Find ("Canvas/Home/LeftButtons/Button0").GetComponent<Button> ();
		buttons[0].onClick.AddListener (m_interface.LeftButton0);
		buttons[1] = GameObject.Find ("Canvas/Home/LeftButtons/Button1").GetComponent<Button> ();
		buttons[1].onClick.AddListener (m_interface.LeftButton1);
		buttons[2] = GameObject.Find ("Canvas/Home/LeftButtons/Button2").GetComponent<Button> ();
		buttons[2].onClick.AddListener (m_interface.LeftButton2);
		buttons[3] = GameObject.Find ("Canvas/Home/LeftButtons/Button3").GetComponent<Button> ();
		buttons[3].onClick.AddListener (m_interface.LeftButton3);
		buttons[4] = GameObject.Find ("Canvas/Home/LeftButtons/Button4").GetComponent<Button> ();
		buttons[4].onClick.AddListener (m_interface.LeftButton4);
		LevelUpButton = GameObject.Find ("Canvas/Home/InformationLayer/LevelUpButton").GetComponent<Button> ();
		LevelUpButton.onClick.AddListener (LevelUp);
		LeavingButton = GameObject.Find ("Canvas/Home/LeavingButton").GetComponent<Button> ();
		LeavingButton.onClick.AddListener (m_interface.LeavingButton);
		LevelUpTime = Time.time-3f;

        name.text = "门派名称："+ GameDataManager.data.menpaimingcheng;
        shengwang.text = "声望值："+ GameDataManager.data.shengwangzhi.ToString();
		shanezhi.fillAmount = GameDataManager.data.shanezhi / 1000.0f;

    }
		
	private void LevelUp()
	{
		if (Time.time - LevelUpTime > 2.5f) {
			m_interface.LevelUpButton ();
			LevelUpTime = Time.time;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
