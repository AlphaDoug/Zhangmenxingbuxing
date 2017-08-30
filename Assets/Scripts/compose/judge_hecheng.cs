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

    private int juanzhou = -1;
    private int maobi = -1;

	void Start () {
		judge_dizi = false;
		judge_juanzhou = false;
		judge_maobi = false;
	}

	void Update () {
        switch (img_juanzhou.sprite.name)
        {
            case "juanzhou1":
                juanzhou = GameDataManager.data.material.baimazhi;
                break;
            case "juanzhou2":
                juanzhou = GameDataManager.data.material.tengzhi;
                break;
            case "juanzhou3":
                juanzhou = GameDataManager.data.material.ciqingzhi;
                break;
            case "juanzhou4":
                juanzhou = GameDataManager.data.material.sajinzhi;
                break;
            case "juanzhou5":
                juanzhou = GameDataManager.data.material.chengxintangzhi;
                break;
        }

        switch (img_maobi.sprite.name)
        {
            case "yanghaobi":
                maobi = GameDataManager.data.material.yanghaobi;
                break;
            case "yusunbi":
                maobi = GameDataManager.data.material.yusunbi;
                break;
            case "xiangyalanghao":
                maobi = GameDataManager.data.material.xiangyalanghao;
                break;
            case "yuzanzihao":
                maobi = GameDataManager.data.material.yuzanzihao;
                break;
            case "miaojinyunlong":
                maobi = GameDataManager.data.material.miaojinyunlong;
                break;
        }

        if (img_dizi.sprite.name != "kuang")
			judge_dizi = true;
        if (img_dizi.sprite.name == "kuang")
            judge_dizi = false;

        if (juanzhou == -1)
            judge_juanzhou = false;
		else if (img_juanzhou.sprite.name != "kuang") 
			judge_juanzhou = true;
        else if (img_juanzhou.sprite.name == "kuang")
            judge_juanzhou = false;


        if (maobi == -1)
            judge_maobi = false;
		else if (img_maobi.sprite.name != "kuang")
            judge_maobi = true;
        else if (img_maobi.sprite.name == "kuang")
            judge_maobi = false;
        //Debug.LogError(img_maobi.sprite.name);
       // Debug.LogError(judge_maobi);
    }
}
