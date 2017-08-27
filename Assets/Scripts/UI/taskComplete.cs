using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwordsmanGame;

public class taskComplete : MonoBehaviour
{
    public Button complete;
    public Image completeUI;
    public Text money;
    public Text justice;
    public Text prestige;
    public Text experience;
    public Confmission confmission = new Confmission();

    private GameObject gainOrLostArticleItem;
    private GameObject getItem;
    private GameObject loseItem;
    private GameObject getItemContent;
    private GameObject lostItemContent;
    // Use this for initialization
    /// <summary>
    /// 确认按钮按下，进行全局数据更改
    /// </summary>
    public void surePress()
    {
        
        Destroy(gameObject);
    }
    /// <summary>
    ///获得奖励
    /// </summary>
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "getItem")
            {
                getItem = child.gameObject;
            }
            if (child.gameObject.name == "loseItem")
            {
                loseItem = child.gameObject;
            }
        }
        gainOrLostArticleItem = Resources.Load("Prefabs/GainOrLostArticleItem") as GameObject;
        if (confmission.gain == "null")//如果没有获得物品，则将获得物品的外框设置为不显示
        {
            getItem.SetActive(false);
        }
        else//如果获得物品，则将获得物品的的UI显示在指定位置
        {
            string[] gainSting = confmission.gain.Split('|');
            foreach (Transform child in getItem.transform)
            {
                if (child.gameObject.name == "count")
                {
                    getItemContent = child.gameObject;
                }
            }
            for (int i = 0; i < gainSting.Length; i++)
            {
                GameObject newContent = Instantiate(gainOrLostArticleItem);
                newContent.transform.parent = getItemContent.transform;
                newContent.transform.localPosition = Vector3.zero;
                newContent.transform.localScale = Vector3.one;

                //newContent.GetComponent<GainOrLostArticleItem>().m_key = gainSting[i];
                foreach (Transform child in newContent.transform)
                {
                    if (child.gameObject.name == "Item")
                    {
                        child.gameObject.GetComponent<Image>().sprite = LoadSprite(gainSting[i]);
                    }
                }
            }
            
        }
        if (confmission.lost == "null")//如果没有失去物品，则将失去物品的外框设置为不显示
        {
            loseItem.SetActive(false);
        }
        else//如果失去物品，则将失去物品的的UI显示在指定位置
        {
            string[] lostSting = confmission.lost.Split('|');
            foreach (Transform child in loseItem.transform)
            {
                if (child.gameObject.name == "count")
                {
                    lostItemContent = child.gameObject;
                }
            }
            for (int i = 0; i < lostSting.Length; i++)
            {
                GameObject newContent = Instantiate(gainOrLostArticleItem);
                newContent.transform.parent = lostItemContent.transform;
                newContent.transform.localPosition = Vector3.zero;
                newContent.transform.localScale = Vector3.one;

                //newContent.GetComponent<GainOrLostArticleItem>().m_key = lostSting[i];
                foreach (Transform child in newContent.transform)
                {
                    if (child.gameObject.name == "Item")
                    {
                        child.gameObject.GetComponent<Image>().sprite = LoadSprite(lostSting[i]);
                    }
                }
            }
        }


        if (confmission.money > 0)
        {
            money.gameObject.SetActive(true);
            money.text = "金钱" + "+" + confmission.money.ToString();
        }
        else if (confmission.money == 0)
        {
            money.gameObject.SetActive(false);
        }
        else
        {
            money.gameObject.SetActive(true);
            money.text = "金钱" + confmission.money.ToString();
        }
        if (confmission.justice > 0)
        {
            justice.gameObject.SetActive(true);
            justice.text = "善恶" + "+" + confmission.justice.ToString();
        }
        else if (confmission.justice == 0)
        {
            justice.gameObject.SetActive(false);
        }
        else
        {
            justice.gameObject.SetActive(true);
            justice.text = "善恶" + confmission.justice.ToString();
        }
        if (confmission.prestige == 0)
        {
            prestige.gameObject.SetActive(false);
        }
        else
        {
            prestige.gameObject.SetActive(true);
            prestige.text = "声望" + "+" + confmission.prestige.ToString();
        }
        if (confmission.experience == 0)
        {
            experience.gameObject.SetActive(false);
        }
        else
        {
            experience.gameObject.SetActive(true);
            experience.text = "经验" + "+" + confmission.experience.ToString();
        }
    }
    private Sprite LoadSprite(string name)
    {
        Sprite sprite;
        sprite = Resources.Load("Sprite/UI/book/" + name, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            return sprite;
        }
        sprite = (Sprite)Resources.Load("Sprite/UI/equipment/" + name, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            return sprite;
        }
        sprite = (Sprite)Resources.Load("Sprite/UI/material/" + name, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            return sprite;
        }
        sprite = (Sprite)Resources.Load("Sprite/UI/medicine/" + name, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            return sprite;
        }
        sprite = (Sprite)Resources.Load("Sprite/UI/special/" + name, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            return sprite;
        }
        return sprite;
    }
}
