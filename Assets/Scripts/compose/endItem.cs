using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endItem : MonoBehaviour {

	public static string endItem_name;
	public Text text_endItem;

	public void end()
	{		
		if (item_hecheng.endItem_num == 1)
        {
			endItem_name = "青城心法";
			text_endItem.text = "弟子正在创作<color=white>"+endItem_name+"</color>！";
		}
        if (item_hecheng.endItem_num == 2)
        {
            endItem_name = "青山剑法";
            text_endItem.text = "弟子正在创作<color=white>" + endItem_name + "</color>！";
        }
        if (item_hecheng.endItem_num == 3)
        {
            endItem_name = "鹰爪功";
            text_endItem.text = "弟子正在创作<color=white>" + endItem_name + "</color>！";
        }
        if (item_hecheng.endItem_num == 1)
        {
            endItem_name = "青城心法";
            text_endItem.text = "弟子正在创作<color=white>" + endItem_name + "</color>！";
        }
		if (item_hecheng.endItem_num == 4)
        {
			endItem_name = "警世通言";
			text_endItem.text = "弟子正在创作<color=green>"+endItem_name+"</color>！";
		}
		if (item_hecheng.endItem_num == 5)
        {
			endItem_name = "北冥神功";
			text_endItem.text = "弟子正在创作<color=blue>"+endItem_name+"</color>！";
		}
		if (item_hecheng.endItem_num == 6)
        {
			endItem_name = "伤寒论";
			text_endItem.text = "弟子正在创作<color=purple>"+endItem_name+"</color>！";
		}
		if (item_hecheng.endItem_num == 7)
        {
			endItem_name = "九阴真经";
			text_endItem.text = "弟子正在创作<color=orange>"+endItem_name+"</color>！";
		}
	}
}
