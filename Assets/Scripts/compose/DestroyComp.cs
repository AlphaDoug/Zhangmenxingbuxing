using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyComp : MonoBehaviour {

	private GameObject Comp;
	private GameObject jishi;
    private GameObject hechengjieguo;

    public Text hechengResult;

    public Text text_jiasuquan;

    private GameObject materialName;

    private create_composition c_c;

	// Use this for initialization
	void Start () {
        c_c = GameObject.Find("Canvas_合成/Panel_创作列表/Image_bottom/创作区域范围").GetComponent<create_composition>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setComp(GameObject other)
	{
		Comp = other;
	}

	public void desComp()
	{
		Destroy (Comp);
	}

	public void setComp2(GameObject other)
	{
		jishi = other;
	}

	public void timeSetZero()
	{
		jishi.GetComponent<listComp> ().second = 0;
	}

    public void setComp3(GameObject other)
    {
        hechengjieguo = other;
    }

    public void ChangeName()
    {
        switch(hechengjieguo.GetComponent<listComp>().addItemName)
        {
            case "青城心法":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=white>"+hechengjieguo.GetComponent<listComp>().addItemName+"</color>";
                break;
            case "青山剑法":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=white>" + hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
            case "鹰爪功":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=white>" + hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
            case "警世通言":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=green>"+hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
            case "北冥神功":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=blue>" + hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
            case "伤寒论":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=purple>" + hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
            case "九阴真经":
                hechengResult.text = "<color=red>恭喜您获得</color>" + "<color=orange>" + hechengjieguo.GetComponent<listComp>().addItemName + "</color>";
                break;
        }
        
    }

    public void onClick_hechengResult()
    {        
        switch(hechengjieguo.GetComponent<listComp>().addItemName)
        {
            case "青城心法":
                GameDataManager.data.book.qingchengxinfa++;
                break;
            case "青山剑法":
                GameDataManager.data.book.qingshanjianfa++;
                break;
            case "鹰爪功":
                GameDataManager.data.book.yingzhaogong++;
                break;
            case "警世通言":
                GameDataManager.data.book.jingshitongyan++;
                break;
            case "北冥神功":
                GameDataManager.data.book.beimingshengong++;
                break;
            case "伤寒论":
                GameDataManager.data.book.shanghanlun++;
                //GameDataManager.data.SetValue("shanghanlun", (int)GameDataManager.data.GetValue("shanghanlun") + 1);
                break;
            case "九阴真经":
                GameDataManager.data.book.jiuyinzhenjing++;
                break;
        }
    }

    public void jiasuquan()
    {
        text_jiasuquan.text = "花费" + jishi.GetComponent<listComp>().second / 60 + "个加速券立即完成";
    }

    public void countDecrease()
    {
        CountText.count--;
    }

    public void GetName(GameObject other)
    {
        materialName=other;
    }

    public void itemReturn()
    {
        switch (materialName.GetComponent<listComp>().juanzhouName)
        {
            case "白麻纸":
                GameDataManager.data.material.baimazhi++;
                break;
            case "藤纸":
                GameDataManager.data.material.tengzhi++;
                break;
            case "瓷青纸":
                GameDataManager.data.material.ciqingzhi++;
                break;
            case "洒金纸":
                GameDataManager.data.material.sajinzhi++;
                break;
            case "澄心堂纸":
                GameDataManager.data.material.chengxintangzhi++;
                break;
        }
        switch (materialName.GetComponent<listComp>().maobiName)
        {
            case "羊毫笔":
                GameDataManager.data.material.yanghaobi++;
                break;
            case "玉笋笔":
                GameDataManager.data.material.yusunbi++;
                break;
            case "象牙狼毫":
                GameDataManager.data.material.xiangyalanghao++;
                break;
            case "玉瓒紫毫":
                GameDataManager.data.material.yuzanzihao++;
                break;
            case "描金云龙":
                GameDataManager.data.material.miaojinyunlong++;
                break;
        }
    }

    public void lengthChange()
    {
        Vector2 size = c_c.text_length.GetComponent<RectTransform>().sizeDelta;
        c_c.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x - 450, size.y);
    }
}
