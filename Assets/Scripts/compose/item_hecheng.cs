using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_hecheng : MonoBehaviour {

	private judge_hecheng jh;

	private string maobi_name;
	private string juanzhou_name;

	public string juanzhou_id;
	public string maobi_id;

	private int juanzhou_num;
	private int maobi_num;

	public static int endItem_num;

	public Text text_hechengImfor;
	private int t;

	void Start () {
		jh = GameObject.Find ("Canvas_合成/Image_judge").GetComponent<judge_hecheng> ();
		Random.InitState (System.Guid.NewGuid ().GetHashCode ());
	}

	public void hecheng()
	{
		juanzhou_name = jh.img_juanzhou.sprite.name;
		maobi_name = jh.img_maobi.sprite.name;

		switch (juanzhou_name) 
		{
		case "juanzhou1":
			juanzhou_id = "白麻纸";
			juanzhou_num = 1;
			break;
		case "juanzhou2":
			juanzhou_id = "藤纸";
			juanzhou_num = 2;
			break;
		case "juanzhou3":
			juanzhou_id = "瓷青纸";
			juanzhou_num = 3;
			break;
		case "juanzhou4":
			juanzhou_id = "洒金纸";
			juanzhou_num = 4;
			break;
		case "juanzhou5":
			juanzhou_id = "澄心堂纸";
			juanzhou_num = 5;
			break;
		}

		switch (maobi_name) 
		{
		case "maobi1":
			maobi_id = "羊毫笔";
			maobi_num = 1;
			break;
		case "maobi2":
			maobi_id = "玉笋笔";
			maobi_num = 2;
			break;
		case "maobi3":
			maobi_id = "象牙狼毫";
			maobi_num = 3;
			break;
		case "maobi4":
			maobi_id = "玉瓒紫毫";
			maobi_num = 4;
			break;
		case "maobi5":
			maobi_id = "描金云龙";
			maobi_num = 5;
			break;
		}

		text_hechengImfor.text="name将使用"+maobi_id+"在"+juanzhou_id+"上创作";

		if (juanzhou_num > maobi_num) 
		{
			t = maobi_num;
			maobi_num = juanzhou_num;
			juanzhou_num = t;
		}
		endItem_num = Random.Range (juanzhou_num+2, maobi_num+3);
        if (endItem_num == 3)
            endItem_num = Random.Range(1,4);
	}
}
