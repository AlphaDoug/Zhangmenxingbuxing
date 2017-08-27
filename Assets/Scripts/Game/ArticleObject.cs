using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleObject : MonoBehaviour
{
    /// <summary>
    /// 此物品的类别
    /// </summary>
    public string m_category;
    /// <summary>
    /// 此物品的名称
    /// </summary>
    public string m_name;
    /// <summary>
    /// 此物品的数量
    /// </summary>
    public int m_count;
    /// <summary>
    /// 此物品的描述
    /// </summary>
    public string m_description;
    /// <summary>
    /// 此物品的作用
    /// </summary>
    public string m_function;

    private Text nameText;
    private Image image;
    private Text descriptionText;
    private Text functionText;
    private Text howToGetText;
    private Text typeText;
    private Sprite sprite = new Sprite();
    private ConfGameArticle confGameArticle;
    // Use this for initialization
    void Start ()
    {
        typeText = GameObject.Find("Canvas/Backpack/Description/Type").GetComponent<Text>();
        howToGetText = GameObject.Find("Canvas/Backpack/Description/HowToGet").GetComponent<Text>();
        nameText = GameObject.Find("Canvas/Backpack/Description/Name").GetComponent<Text>();
        image = GameObject.Find("Canvas/Backpack/Description/InfoImage/Image").GetComponent<Image>();
        descriptionText = GameObject.Find("Canvas/Backpack/Description/DescriptionWord").GetComponent<Text>();
        functionText = GameObject.Find("Canvas/Backpack/Description/Function").GetComponent<Text>();

        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Count" && m_count >= 2)
            {
                child.gameObject.GetComponent<Text>().text = m_count.ToString();
            }
        }
        sprite = Resources.Load("Sprite/UI/" + m_category + "/" + m_name, sprite.GetType()) as Sprite;
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Image")
            {
                child.gameObject.GetComponent<Image>().sprite = sprite;
            }
        }
        
        SQLiteLoad.LoadSQLite();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ShowDescription()
    {       
        
        image.sprite = sprite;
        if (ConfGameArticle.GetConfig(m_name, out confGameArticle))
        {
            nameText.text = confGameArticle.Name;
            descriptionText.text = confGameArticle.Describe;
            functionText.text = confGameArticle.Feature;
            typeText.text = confGameArticle.Type;
            howToGetText.text = confGameArticle.HowtoGet;
        }      
    }
}
