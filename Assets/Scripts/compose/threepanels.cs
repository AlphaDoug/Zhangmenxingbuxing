using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threepanels : MonoBehaviour
{

    public GameObject panel_dizi;
    public GameObject panel_juanzhou;
    public GameObject panel_maobi;

    public void dizi_active()
    {
        panel_dizi.SetActive(true);
        panel_juanzhou.SetActive(false);
        panel_maobi.SetActive(false);
    }

    public void juanzhou_active()
    {
        panel_juanzhou.SetActive(true);
        panel_dizi.SetActive(false);
        panel_maobi.SetActive(false);
    }

    public void maobi_active()
    {
        panel_maobi.SetActive(true);
        panel_juanzhou.SetActive(false);
        panel_dizi.SetActive(false);
    }
}
