using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsmanGame
{
    public class HighLightBuild : MonoBehaviour
    {
        public static event GameController.OnMouseEnter_Build OnMouseEnterEvent_Build;
        public static event GameController.OnMouseDown_Build OnMouseDownEvent_Build;
        public static event GameController.OnMouseExit_Build OnMouseExitEvent_Build;
        private SpriteRenderer spriteRenderer;
        // Use this for initialization
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseEnter()
        {
            if (OnMouseEnterEvent_Build != null)
            {
                OnMouseEnterEvent_Build(gameObject, Convert.ToInt32(gameObject.name));
            }
            //spriteRenderer.color = new Color(255, 255, 255, 255);
        }
        private void OnMouseExit()
        {
            if (OnMouseExitEvent_Build != null)
            {
                OnMouseExitEvent_Build(gameObject, Convert.ToInt32(gameObject.name));
            }
            //spriteRenderer.color = new Color(255, 255, 255, 0);
        }
        private void OnMouseDown()
        {
            if (OnMouseDownEvent_Build != null)
            {
                OnMouseDownEvent_Build(this,Convert.ToInt32(gameObject.name));
            }
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}

