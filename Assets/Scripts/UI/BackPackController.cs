using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class BackPackController : MonoBehaviour
{
    public GameObject backPack;
    public GameObject articleObject;
    public GameObject content;
    public GameObject[] rightBtns;
    public Text nameText;
    public Image image;
    public Text descriptionText;
    public Text functionText;
    public Text howToGetText;
    public Text typeText;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    /// <summary>
    /// 所有物品按钮按下事件
    /// </summary>
    public void OnAllButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "AllButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach(Transform child in content.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 装备按钮按下事件
    /// </summary>
    public void OnEquipmentButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "EquipmentButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.GetComponent<ArticleObject>().m_category != "equipment")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 书籍按钮按下事件
    /// </summary>
    public void OnBookButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "BookButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.GetComponent<ArticleObject>().m_category != "book")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 药材按钮按下事件
    /// </summary>
    public void OnMedicinesButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "MedicinesButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.GetComponent<ArticleObject>().m_category != "medicine")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 材料按钮按下事件
    /// </summary>
    public void OnMaterialButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "MaterialButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.GetComponent<ArticleObject>().m_category != "material")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 特殊物品按钮按下事件
    /// </summary>
    public void OnSpecialButtonDown()
    {
        for (int i = 0; i < rightBtns.Length; i++)
        {
            if (rightBtns[i].name == "SpecialButton")
            {
                rightBtns[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
            else
            {
                rightBtns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.GetComponent<ArticleObject>().m_category != "special")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 背包界面打开时候需要调用此函数
    /// </summary>
    public void OnBackPackAble()
    {
        if (content.transform.childCount != 0)
        {
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
        }
        Type type;

        type = GameDataManager.data.book.GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(GameDataManager.data.book, null);
            string name = pi.Name;
            if ((int)value1 == 0)
            {
                continue;
            }
            var newArticleObject = Instantiate(articleObject);
            newArticleObject.transform.parent = content.transform;
            newArticleObject.GetComponent<ArticleObject>().m_category = "book";
            newArticleObject.GetComponent<ArticleObject>().m_name = name;
            newArticleObject.GetComponent<ArticleObject>().m_function = "meiyou";
            newArticleObject.GetComponent<ArticleObject>().m_count = (int)value1;
            newArticleObject.GetComponent<ArticleObject>().m_description = "meiyou ";
            newArticleObject.transform.localScale = new Vector3(1, 1, 1);
            newArticleObject.transform.localPosition = Vector3.zero;
        }

        type = GameDataManager.data.equipment.GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(GameDataManager.data.equipment, null);
            string name = pi.Name;
            if ((int)value1 == 0)
            {
                continue;
            }
            var newArticleObject = Instantiate(articleObject);
            newArticleObject.transform.parent = content.transform;
            newArticleObject.GetComponent<ArticleObject>().m_category = "equipment";
            newArticleObject.GetComponent<ArticleObject>().m_name = name;
            newArticleObject.GetComponent<ArticleObject>().m_function = "meiyou";
            newArticleObject.GetComponent<ArticleObject>().m_count = (int)value1;
            newArticleObject.GetComponent<ArticleObject>().m_description = "meiyou ";
            newArticleObject.transform.localScale = new Vector3(1, 1, 1);
            newArticleObject.transform.localPosition = Vector3.zero;
        }

        type = GameDataManager.data.material.GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(GameDataManager.data.material, null);
            string name = pi.Name;
            if ((int)value1 == 0)
            {
                continue;
            }
            var newArticleObject = Instantiate(articleObject);
            newArticleObject.transform.parent = content.transform;
            newArticleObject.GetComponent<ArticleObject>().m_category = "material";
            newArticleObject.GetComponent<ArticleObject>().m_name = name;
            newArticleObject.GetComponent<ArticleObject>().m_function = "meiyou";
            newArticleObject.GetComponent<ArticleObject>().m_count = (int)value1;
            newArticleObject.GetComponent<ArticleObject>().m_description = "meiyou ";
            newArticleObject.transform.localScale = new Vector3(1, 1, 1);
            newArticleObject.transform.localPosition = Vector3.zero;
        }

        type = GameDataManager.data.medicine.GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(GameDataManager.data.medicine, null);
            string name = pi.Name;
            if ((int)value1 == 0)
            {
                continue;
            }
            var newArticleObject = Instantiate(articleObject);
            newArticleObject.transform.parent = content.transform;
            newArticleObject.GetComponent<ArticleObject>().m_category = "medicine";
            newArticleObject.GetComponent<ArticleObject>().m_name = name;
            newArticleObject.GetComponent<ArticleObject>().m_function = "meiyou";
            newArticleObject.GetComponent<ArticleObject>().m_count = (int)value1;
            newArticleObject.GetComponent<ArticleObject>().m_description = "meiyou ";
            newArticleObject.transform.localScale = new Vector3(1, 1, 1);
            newArticleObject.transform.localPosition = Vector3.zero;
        }

        type = GameDataManager.data.special.GetType();
        foreach (PropertyInfo pi in type.GetProperties())
        {
            object value1 = pi.GetValue(GameDataManager.data.special, null);
            string name = pi.Name;
            if ((int)value1 == 0)
            {
                continue;
            }
            var newArticleObject = Instantiate(articleObject);
            newArticleObject.transform.parent = content.transform;
            newArticleObject.GetComponent<ArticleObject>().m_category = "special";
            newArticleObject.GetComponent<ArticleObject>().m_name = name;
            newArticleObject.GetComponent<ArticleObject>().m_function = "meiyou";
            newArticleObject.GetComponent<ArticleObject>().m_count = (int)value1;
            newArticleObject.GetComponent<ArticleObject>().m_description = "meiyou ";
            newArticleObject.transform.localScale = new Vector3(1, 1, 1);
            newArticleObject.transform.localPosition = Vector3.zero;
        }
        StartCoroutine(ShowDefaulInfo());

    }
    IEnumerator ShowDefaulInfo()
    {
        yield return new WaitForFixedUpdate();
        if (content.transform.childCount > 0)
        {
            content.transform.GetChild(0).gameObject.SendMessage("ShowDescription");
        }
    }
}
