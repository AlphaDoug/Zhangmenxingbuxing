using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordsmanGame;
using UnityEngine.UI;

public class ChoiceBox : MonoBehaviour
{
    public static event GameController.OnMouseDown_Choice OnMouseDownEvent_Choice;
    public string content;
    public int index;
    public GameObject text;
    public GameObject image;
    // Use this for initialization
    void Start ()
    {

        text.GetComponent<Text>().text = content;

        //image.GetComponent<RectTransform>().sizeDelta = text.GetComponent<RectTransform>().sizeDelta + new Vector2(17, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //image.GetComponent<RectTransform>().sizeDelta = text.GetComponent<RectTransform>().sizeDelta + new Vector2(17, 0);

    }
    
    public void ButtonDown()
    {
        if (OnMouseDownEvent_Choice != null)
        {
            OnMouseDownEvent_Choice(this, index);
        }
    }
}
