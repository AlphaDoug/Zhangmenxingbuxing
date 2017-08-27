using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 文字逐字显示
/// </summary>
public class WordSpeed: MonoBehaviour
{
    public float letterPause = 1f;
    public bool isShowing;
    private string word;
    private Text text;

    void Start()
    {
        word = "1231412523524242353465342";
        text = GetComponent<Text>();
        text.text = "";
        StartCoroutine(TypeText());
    }

    private void Update()
    {
       
    }

    private IEnumerator TypeText()
    {
        isShowing = true;
        foreach (char letter in word.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        Debug.Log("说完了");
        isShowing = false;
    }



}

