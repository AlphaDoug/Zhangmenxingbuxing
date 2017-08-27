using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDic : MonoBehaviour {
    public Sprite LXH;
    public Sprite JHM;
    public Sprite BHY;
    public Sprite FXY;
    public static Dictionary<string, Sprite> imgDic = new Dictionary<string, Sprite>();
	// Use this for initialization
	void Start () {
        imgDic.Add("LXH", LXH);
        imgDic.Add("JHM", JHM);
        imgDic.Add("BHY", BHY);
        imgDic.Add("FXY", FXY);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
