using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listComp : MonoBehaviour {

	private item_hecheng ih;

	public Text text_comp;
	public Text compTime;
	private float nextTime = 1;
	public int second;

	public GameObject button_chakan;
	private Button chakan;

    public string addItemName;

    public string juanzhouName;
    public string maobiName;

    private void Awake()
    {
        second = 7588;
        ih = GameObject.Find("Canvas_合成/Image_judge").GetComponent<item_hecheng>();
        juanzhouName = ih.juanzhou_id;
        maobiName = ih.maobi_id;
        text_comp.text = "name正在用" + ih.juanzhou_id + "和" + ih.maobi_id + "创作" + endItem.endItem_name;
        compTime.text = "24:00:00";
        addItemName = endItem.endItem_name;
    }

    void Start () 
	{
		
	}

	void Update()
	{
		if (nextTime <= Time.time) 
		{
			second--;
			compTime.text = string.Format ("{0:d2}:{1:d2}:{2:d2}",second / 3600, second % 3600 / 60, second % 60);
			nextTime = Time.time + 1;

			if (second <= 0)
			{
				this.enabled = false;
				text_comp.text = "";
				compTime.text = "已完成";
				button_chakan.SetActive (true);

				chakan=transform.Find ("Button_查看").GetComponent<Button> ();
				chakan.onClick.AddListener (chakanActive);
                chakan.onClick.AddListener(GameObject.Find("Panel_加速").GetComponent<DestroyComp>().ChangeName);
			}
		}
	}

	private void chakanActive()
	{
		GameObject.FindGameObjectWithTag ("chakanComp").GetComponent<Button_Active> ().active ();
	}
}
