using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeItem : MonoBehaviour {

	private judge_hecheng jh;

	private string maobi_name;
	private string juanzhou_name;

	void Start () 
	{
		jh = GameObject.Find ("Canvas_合成/Image_judge").GetComponent<judge_hecheng> ();

        juanzhou_name = jh.img_juanzhou.sprite.name;
        maobi_name = jh.img_maobi.sprite.name;

        switch (juanzhou_name)
        {
            case "juanzhou1":
                GameDataManager.data.material.baimazhi--;
                break;
            case "juanzhou2":
                GameDataManager.data.material.tengzhi--;
                break;
            case "juanzhou3":
                GameDataManager.data.material.ciqingzhi--;
                break;
            case "juanzhou4":
                GameDataManager.data.material.sajinzhi--;
                break;
            case "juanzhou5":
                GameDataManager.data.material.chengxintangzhi--;
                break;
        }

        switch (maobi_name)
        {
            case "maobi1":
                GameDataManager.data.material.yanghaobi--;
                break;
            case "maobi2":
                GameDataManager.data.material.yusunbi--;
                break;
            case "maobi3":
                GameDataManager.data.material.xiangyalanghao--;
                break;
            case "maobi4":
                GameDataManager.data.material.yuzanzihao--;
                break;
            case "maobi5":
                GameDataManager.data.material.miaojinyunlong--;
                break;
        }
    }
}
