using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicInfoShow : MonoBehaviour
{
    public Text name;
    public Text gold;
    public Text prestige;
    public Slider goodAndEvilValues;
    // Use this for initialization
    void Start ()
    {
        SetBasicInfo();
        StartCoroutine(UpdataBasicInfo());
    }
    private void SetBasicInfo()
    {
        name.text = GameDataManager.data.menpaimingcheng;
        gold.text = GameDataManager.data.huobi.ToString();
        prestige.text = GameDataManager.data.shengwangzhi.ToString();
        goodAndEvilValues.value = GameDataManager.data.shanezhi / 1000.0f;
    }

    IEnumerator UpdataBasicInfo()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            SetBasicInfo();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
