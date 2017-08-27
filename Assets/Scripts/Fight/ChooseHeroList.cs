using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseHeroList : MonoBehaviour {
    private GameObject VerticalLayout;
    private GameObject HorizontalLayout;
    private int count = 1;
	// Use this for initialization
	void Start () {
        VerticalLayout = GameObject.Find("Fight/ChooseList/ScrollRect/Vertical Layout");
        HorizontalLayout = GameObject.Find("Fight/ChooseList/ScrollRect/Vertical Layout/Horizontal Layout");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Addhero(string heroname)
    {
        if (count % 3 == 0)
        {
            if (count - 15 >= 0)
            {
                Vector2 size = VerticalLayout.GetComponent<RectTransform>().sizeDelta;
                VerticalLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x,
                    size.y+HorizontalLayout.GetComponent<RectTransform>().sizeDelta.y + VerticalLayout.GetComponent<VerticalLayoutGroup>().spacing);
            }
            HorizontalLayout = Instantiate(Resources.Load("Layout/Horizontal Layout")) as GameObject;
            HorizontalLayout.transform.SetParent(VerticalLayout.transform);
            InitHero(heroname);
        }
        else
        {
            InitHero(heroname);
        }
        count++;
    }

    public void InitHero(string heroname)
    {
        GameObject Hero = Instantiate(Resources.Load("Hero/" + heroname)) as GameObject;
        Hero.GetComponent<Toggle>().group = VerticalLayout.GetComponent<ToggleGroup>();
        Hero.transform.SetParent(HorizontalLayout.transform);
    }
}
