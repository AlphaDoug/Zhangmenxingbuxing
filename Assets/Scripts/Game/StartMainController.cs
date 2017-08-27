using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMainController : MonoBehaviour
{
    public GameObject littlePersonAnimation;
    public int loadIndex;

    private Sprite []sprite;
    // Use this for initialization
    void Start ()
    {
        sprite = new Sprite[2];
        sprite[0] = Resources.Load("Sprite/UI/Writing_1", typeof(Sprite)) as Sprite;
        sprite[1] = Resources.Load("Sprite/UI/Writing_2", typeof(Sprite)) as Sprite;
        StartCoroutine(PlayAnimation());
        StartCoroutine(LoadScene(loadIndex));
    }	
    /// <summary>
    /// 控制动画循环播放
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; ; i++)
        {
            if (i >= 2)
            {
                i = 0;
            }
            littlePersonAnimation.GetComponent<Image>().sprite = sprite[i];            
            yield return new WaitForSeconds(0.2f);
        }     
    }
    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="index">待加载的场景的下标</param>
    /// <returns></returns>
    IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(2);
        var async = SceneManager.LoadSceneAsync(index);
        yield return async;
        StopAllCoroutines();
    }
}
