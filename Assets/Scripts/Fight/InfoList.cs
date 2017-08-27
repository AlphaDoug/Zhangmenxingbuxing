using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoList : MonoBehaviour {
    private Text HeroName;
    private Text HeroSex;
    private Text HP;
    private Text Defend;
    private Text Attack;
    private Text Speed;
    

    public HeroInfo heroinfo;
	// Use this for initialization
	void Start () {
        HeroName = GameObject.Find("InfoList/HeroMessage/HeroName").GetComponent<Text>();
        HeroSex = GameObject.Find("InfoList/HeroMessage/HeroSex").GetComponent<Text>();
        HP = GameObject.Find("InfoList/HeroProperty/HP").GetComponent<Text>();
        Defend = GameObject.Find("InfoList/HeroProperty/Defend").GetComponent<Text>();
        Attack = GameObject.Find("InfoList/HeroProperty/Attack").GetComponent<Text>();
        Speed = GameObject.Find("InfoList/HeroProperty/Speed").GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHeroInfo(string name, string sex, int hp,int defend,int attack,int speed, HeroInfo heroinfo)
    {
        HeroName.text = "姓名:"+name;
        HeroSex.text = "性别:" + sex;
        HP.text = "生命值:" + hp.ToString();
        Defend.text = "防御:" + defend.ToString();
        Attack.text = "攻击:" + attack.ToString();
        Speed.text = "敏捷:" + speed.ToString();
        this.heroinfo = heroinfo;
        heroinfo.gameObject.GetComponent<Image>();
    }

    
    
}
