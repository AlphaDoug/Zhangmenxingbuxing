using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordsmanGame;

public class UIController : MonoBehaviour
{
    [Serializable]
    public class MoveArea
    {
        public float x1;
        public float x2;
        public float y1;
        public float y2;
    }
    /// <summary>
    /// 用于设置摄像机移动的灵敏度
    /// </summary>
    public float moveSensitivity = 0.001f;
    public GameObject[] buildClickBoundary;
    public MoveArea cameraMoveArea;
    public GameObject missionBtn;

    private bool isCharacterChoosen;
    private Ray ray = new Ray();
    private Camera mainCamera;
    private bool isMouseButtonDown_RightKey;
    private Vector2 mouseDownPosition_RightKey;
    private Vector2 mouseDeltaPosition;
    private bool isUIAble;
    // Use this for initialization
    void Start ()
    {
        mainCamera = Camera.main;
        isMouseButtonDown_RightKey = false;
        //StartCoroutine(UIStateMonitor());
        isCharacterChoosen = false;
        CharactersController.OnMouseEnterEvent_Character += OnMouseEnterCharacter;
        HighLightBuild.OnMouseEnterEvent_Build += OnMouseEnterBuild;
        HighLightBuild.OnMouseDownEvent_Build += OnMouseDownBuild;
        HighLightBuild.OnMouseExitEvent_Build += HighLightBuild_OnMouseExitEvent_Build;
        
    }

   

    private void OnDestroy()
    {
        CharactersController.OnMouseEnterEvent_Character -= OnMouseEnterCharacter;
        HighLightBuild.OnMouseEnterEvent_Build -= OnMouseEnterBuild;
        HighLightBuild.OnMouseDownEvent_Build -= OnMouseDownBuild;
        HighLightBuild.OnMouseExitEvent_Build -= HighLightBuild_OnMouseExitEvent_Build;

    }
    // Update is called once per frame
    void Update ()
    {     
        
        if (Input.GetMouseButtonDown(1))
        {
            isMouseButtonDown_RightKey = true;
            mouseDownPosition_RightKey = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMouseButtonDown_RightKey = false;
        }
        UpdateCameraPosition();
    }
    IEnumerator UIStateMonitor()
    {
        yield return new WaitForSeconds(1);
      
    }

    private void UpdateCameraPosition()
    {
        if (isMouseButtonDown_RightKey)
        {
            
            mouseDeltaPosition = (Vector2)Input.mousePosition - mouseDownPosition_RightKey;
            var newPosition = mainCamera.gameObject.transform.position + (Vector3)mouseDeltaPosition * moveSensitivity;
            mainCamera.gameObject.transform.position = new Vector3
                (
                    Mathf.Clamp(newPosition.x, cameraMoveArea.x1, cameraMoveArea.x2),
                    Mathf.Clamp(newPosition.y, cameraMoveArea.y2, cameraMoveArea.y1),
                    mainCamera.gameObject.transform.position.z
                );
        }
    }
    private void HighLightBuild_OnMouseExitEvent_Build(object sender, int index)
    {
        if (!isUIAble)
        {
            ((GameObject)sender).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
            
    }

    private void OnMouseEnterCharacter()
    {
       
    }
    private void OnMouseEnterBuild(object sender ,int index)
    {
        if (!isUIAble)
        {
            ((GameObject)sender).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        
    }
    private void OnMouseDownBuild(object sender, int index)
    {
        if (!isUIAble && buildClickBoundary[index - 1] != null)
        {
            buildClickBoundary[index - 1].SetActive(true);
            isUIAble = true;
        }
        
    }
    public void SetisUIAble(bool b)
    {
        isUIAble = b;
    }
}
