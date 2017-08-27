using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfo : MonoBehaviour {
    private ConfPlayerProperty config;
    private InfoList infoList;
    private Toggle toggle;
    private Button ready;
    
    // Use this for initialization
    void Start () {
        toggle = GetComponent<Toggle>();
        SQLiteLoad.LoadSQLite();
        ConfPlayerProperty.GetConfig(transform.name, out config);
        infoList = GameObject.Find("Fight/InfoList").GetComponent<InfoList>();
    }
	
	// Update is called once per frame
	void Update () {
        if (toggle.isOn)
        {
            infoList.SetHeroInfo(config.nameC, config.sex, config.hp, config.defense, config.attack, config.agility,this);
            GameObject temple = GameObject.Find("Fight/Temple");
            Image templeImg = temple.GetComponent<Image>();
            templeImg.sprite = gameObject.transform.Find("PersonPic").GetComponent<Image>().sprite;
        }
	}

    public void SetBeChoose()
    {
        transform.Find("PersonPic").GetComponent<Image>().color = Color.grey;
        toggle.isOn = false;
        toggle.interactable = false;
        
    }

    public void CancelBeChoose()
    {
        transform.Find("PersonPic").GetComponent<Image>().color = Color.white;
        toggle.interactable = true;
        
    }

    
}
