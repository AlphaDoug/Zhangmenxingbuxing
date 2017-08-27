using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class judge_hecheng : MonoBehaviour {

	public bool judge_dizi;
    public bool judge_juanzhou;
    public bool judge_maobi;

	public Image img_dizi;
    public Image img_juanzhou;
    public Image img_maobi;

	void Start () {
		judge_dizi = false;
		judge_juanzhou = false;
		judge_maobi = false;
	}

	void Update () {
		if (img_dizi.sprite.name != "touxiangkuangL")
			judge_dizi = true;
		
		if (img_juanzhou.sprite.name != "touxiangkuangL") 
			judge_juanzhou = true;
						
		if (img_maobi.sprite.name != "touxiangkuangL")
            judge_maobi = true;
	}
}
