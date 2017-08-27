using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBtnRedPint : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //MissionController.HaveNewTasksEvent += MissionController_HaveNewTasksEvent;

    }

    public void MissionController_HaveNewTasksEvent(bool a)
    {
        transform.GetChild(0).gameObject.SetActive(a);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnDestroy()
    {
        //MissionController.HaveNewTasksEvent -= MissionController_HaveNewTasksEvent;

    }
}
