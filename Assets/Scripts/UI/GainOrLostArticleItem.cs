using UnityEngine;

using System.Collections;

using UnityEngine.UI;

using UnityEngine.EventSystems;


namespace SwordsmanGame
{
    public class GainOrLostArticleItem : Button
    {
        public string m_key;
        private ConfGameArticle confGameArticle;
        private string m_name;
        private string m_des;
        private GameObject info;
        private bool isMouseOnButton;
        // Use this for initialization
        protected override void Start()
        {
            //SQLiteLoad.LoadSQLite();
            //ConfGameArticle.GetConfig(m_key, out confGameArticle);
            //m_name = confGameArticle.Name;
            //m_des = confGameArticle.Describe;
            info = GameObject.Find("Canvas/taskComplete/Info");
            info.SetActive(false);
            isMouseOnButton = false;
        }
        void Update()
        {
            if (isMouseOnButton)
            {
                Debug.Log(Input.mousePosition);
                //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); 
                //info.GetComponent<RectTransform>().position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + info.GetComponent<RectTransform>().sizeDelta / 2;
                info.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                info.transform.localPosition = info.transform.localPosition - new Vector3(0, 0, info.transform.localPosition.z) + (Vector3)info.GetComponent<RectTransform>().sizeDelta / 2;
            }
            else
            {
                
            }
        }
        protected override void DoStateTransition(SelectionState state, bool instant)

        {

            base.DoStateTransition(state, instant);

            switch (state)

            {

                case SelectionState.Disabled:

                    break;

                case SelectionState.Highlighted:

                    Debug.Log("鼠标移到button上！");
                    isMouseOnButton = true;
                    info.SetActive(true);
                    break;

                case SelectionState.Normal:

                    Debug.Log("鼠标离开Button！");
                    isMouseOnButton = false;
                    info.SetActive(false);
                    break;

                case SelectionState.Pressed:

                    break;

                default:

                    break;

            }

        }
    }

}
