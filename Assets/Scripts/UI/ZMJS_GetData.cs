using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ZMJS_GetData : MonoBehaviour {

	private ConfZMJS entity;
	private int entityId;
	private Text name;
	private Text level;
	private Text income;
	private Text outcome;
	private Text rsdz;
	private Text wmdz;

	void Start(){
		bool pd;
		entityId = 1;
		pd = ConfZMJS.GetConfig (entityId,out entity);
		name=GameObject.Find ("mpName").GetComponentInChildren<Text>();
		level=GameObject.Find ("mpLevel").GetComponentInChildren<Text>();
		income=GameObject.Find ("mpIncome").GetComponentInChildren<Text>();
		outcome=GameObject.Find ("mpOutcome").GetComponentInChildren<Text>();
		rsdz=GameObject.Find ("mpRsdz").GetComponentInChildren<Text>();
		wmdz=GameObject.Find ("mpWmdz").GetComponentInChildren<Text>();
		level.text = "门派等级：" + entity.sn.ToString ();
		income.text = "每日收入：" + entity.input.ToString ();
		outcome.text = "每日支出：" + (entity.output_rsdztime * 4 + entity.output_wmdztime * 0).ToString ();
		rsdz.text = "入室弟子：4/" + entity.rsdz.ToString();
		wmdz.text = "外门弟子：0/" + entity.wmdz.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LevelUp()
	{
		bool pd;
		if (entityId < 20) {
			entityId++;
			pd = ConfZMJS.GetConfig (entityId, out entity);
		}
		level.text = "门派等级：" + entity.sn.ToString ();
		income.text = "每日收入：" + entity.input.ToString ();
		outcome.text = "每日支出：" + (entity.output_rsdztime * 4 + entity.output_wmdztime * 0).ToString ();
		rsdz.text = "入室弟子：4/" + entity.rsdz.ToString();
		wmdz.text = "外门弟子：0/" + entity.wmdz.ToString ();

	}
}
