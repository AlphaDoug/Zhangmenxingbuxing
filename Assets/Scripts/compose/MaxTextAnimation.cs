using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MaxTextAnimation : MonoBehaviour {

	private Vector2 pos = new Vector2 (-168, -85.88f);
	private Text text;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable()
	{
		this.GetComponent<RectTransform> ().anchoredPosition = pos;
	}

	public void Up()
	{
		this.GetComponent<RectTransform> ().anchoredPosition = pos;
		text = this.GetComponent<Text> ();
		Fly (text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Fly(Graphic graph)
	{
		RectTransform rt = graph.rectTransform;
		Color col = graph.color;
		Sequence list = DOTween.Sequence ();
		Tweener move1 = rt.DOMoveY (rt.position.y + 5, 0.5f);
		Tweener move2 = rt.DOMoveY (rt.position.y + 10, 0.5f);
		Tweener alpha1 = graph.DOColor (new Color (col.r, col.g, col.b, 1), 0.5f);
		Tweener alpha2 = graph.DOColor (new Color (col.r, col.g, col.b, 0), 0.5f);
		list.Append (move1);
		list.Join (alpha1);
		list.AppendInterval (1);
		list.Append (move2);
		list.Join (alpha2);
	}
}
