using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleReturn : MonoBehaviour {
    public int result;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SetReturn());
        result = -1;
    }

    IEnumerator SetReturn()
    {
        yield return new WaitForSeconds(5);
        result = Random.Range(0, 2);

    }
}
