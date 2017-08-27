using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ZMJS_LevelUp : MonoBehaviour {

	// Use this for initialization
	private Text text;
	private Vector2 startPos;
	void Start () {
		//startPos = new Vector2 (0, -300);
	}

	void OnEnable()
	{
		startPos = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (this.GetComponent<RectTransform> ().anchoredPosition);
	}

	public void Up()
	{
		text = this.GetComponent<Text> ();
		this.GetComponent<RectTransform> ().anchoredPosition = startPos;
		FlyTo (text);
	}

	public static void FlyTo(Text graphic)  
	{  
		RectTransform rt = graphic.rectTransform;  
		Debug.Log (rt.position.y);
		Color c = graphic.color;  
		c.a = 0;  
		graphic.color = c;  
		Sequence mySequence = DOTween.Sequence ();
		Tweener move1 = rt.DOMoveY(rt.position.y + 5, 0.5f);  
		Tweener move2 = rt.DOMoveY(rt.position.y + 10, 0.5f);  
		Tweener alpha1 = graphic.DOColor(new Color(c.r, c.g, c.b, 1), 0.5f);  
		Tweener alpha2 = graphic.DOColor(new Color(c.r, c.g, c.b, 0), 0.5f);  
		mySequence.Append(move1);  
		mySequence.Join(alpha1);  
		mySequence.AppendInterval(1);  
		mySequence.Append(move2);  
		mySequence.Join(alpha2); 
	} 
}
