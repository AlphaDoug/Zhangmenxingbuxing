using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyHero : MonoBehaviour {
    private Button button;
    private Button close;
    public Sprite m_sprite;
    private InfoList m_infoList;

    private string pre;
    private string tempName = null;

    private bool isTempChoose = false;
    public string i = "noChoose";
    // Use this for initialization

    private void OnEnable()
    {
        gameObject.GetComponent<Image>().sprite = m_sprite;
        GameObject temple = GameObject.Find("Fight/Temple");
        GameObject.Find(pre + tempName).GetComponent<HeroInfo>().CancelBeChoose();
        i = "noChoose";
    }

    void Start () {
        pre = "Fight/ChooseList/ScrollRect/Vertical Layout/Horizontal Layout/";
        button = GetComponent<Button>();
        close = transform.Find("Close").GetComponent<Button>();

        button.onClick.AddListener(()=>{
            GameObject temple = GameObject.Find("Fight/Temple");
            if (!temple.GetComponent<Image>().sprite.name.Equals("touxiangkuangR"))
            {
                i = transform.GetChild(1).transform.name;
                gameObject.GetComponent<Image>().sprite = temple.GetComponent<Image>().sprite;
                if (tempName == null)
                {
                    m_infoList = GameObject.Find("Fight/InfoList").GetComponent<InfoList>();
                    tempName = m_infoList.heroinfo.transform.name;
                    GameObject.Find(pre + tempName).GetComponent<HeroInfo>().SetBeChoose();
                    GameObject.Find("Fight/Temple").GetComponent<Image>().sprite = m_sprite;
                }
                else
                {
                    GameObject.Find(pre + tempName).GetComponent<HeroInfo>().CancelBeChoose();

                    m_infoList = GameObject.Find("Fight/InfoList").GetComponent<InfoList>();
                    tempName = m_infoList.heroinfo.transform.name;
                    GameObject.Find(pre + tempName).GetComponent<HeroInfo>().SetBeChoose();
                }
                temple.GetComponent<Image>().sprite = m_sprite;
            }
            


        });

        close.onClick.AddListener(()=> {
            gameObject.GetComponent<Image>().sprite = m_sprite;
            GameObject temple = GameObject.Find("Fight/Temple");
            GameObject.Find(pre + tempName).GetComponent<HeroInfo>().CancelBeChoose();
            i = "noChoose";
        });
	}

    

}
