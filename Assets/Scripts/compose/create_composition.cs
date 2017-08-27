using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_composition : MonoBehaviour {

	public GameObject prefab;
	public Transform inspos;
	public Transform parent;

	public GameObject text_length;

	void Start () {
		
	}

	void Update () {
		
	}
		
	public void createComposition()
	{
		GameObject temp = GameObject.Instantiate(prefab,inspos.position,Quaternion.identity);
		temp.transform.SetParent (parent);
		temp.transform.localScale = Vector3.one;
	}

	public void changeLength()
	{
		Vector2 size = text_length.GetComponent<RectTransform> ().sizeDelta;
		text_length.GetComponent<RectTransform> ().sizeDelta = new Vector2 (size.x + 450, size.y);
	}
}
