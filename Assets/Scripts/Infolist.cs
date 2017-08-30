using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Infolist : MonoBehaviour {
    ConfPlayerProperty confPlane;
    public Text dzname;
    public Text level;
    public Text status;
    public Text strength;
    public Text exp;
    public Text hp;
    public Text atk;
    public Text def;
    public Text wx;
    public Text wq;
    public Text sh;
    public Toggle m_toggle;
    private Vector3 ImagePosition = new Vector3(-1.56f, 0, 0);
    public Image Lihui;
    private Sprite value;
    void Awake()
    {
        SQLiteLoad.LoadSQLite();
        ConfPlayerProperty.GetConfig(transform.name, out confPlane);
    }

    // Use this for initialization
    void Start () {
        
    }
    

    // Update is called once per frame
    public void Update () {
        if (m_toggle.isOn)
        {
            dzname.text = "姓名:" + confPlane.nameC;
            level.text = "等级:" + confPlane.level.ToString();
            status.text = "状态:" + confPlane.content;
            strength.text = "体力:" + confPlane.strength.ToString();
            exp.text = "经验:" + confPlane.exp.ToString();
            hp.text = "生命:" + confPlane.hp.ToString();
            atk.text = "攻击力:" + confPlane.attack.ToString();
            def.text = "防御力:" + confPlane.defense.ToString();
            wx.text = "悟性:" + confPlane.WX.ToString();
            wq.text = "武器精通:" + confPlane.WQ.ToString();
            sh.text = "生活精通:" + confPlane.SH.ToString();
            if(ImageDic.imgDic.TryGetValue(transform.name, out value))
                Lihui.sprite = value;
            
           
           
        }


    }

 

}
