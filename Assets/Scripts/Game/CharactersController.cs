using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace SwordsmanGame
{
    public class CharactersController : MonoBehaviour
    {

        public enum CharacterState
        {
            walkUp = 1,
            walkDown = 2,
            walkRight = 3,
            walkLeft = 4,
            standUp = 5,
            standDown = 6,
            standRight = 7,
            standLeft = 8,
        }
        public float m_speed = 1.0f;
        public float m_notMoveDistance = 0.5f;
        public float m_moveTimeInterval = 3.0f;
        public float m_moveArea = 0.5f;
        public GameObject characterInfo;
        public GameObject characterAnswer;
        public float characterInfoDeviation = 120.0f;
        public float characterAnswerDeviation = 5.0f;

        public static event GameController.OnMouseEnter_Character OnMouseEnterEvent_Character;

        private Vector2 lastPosition;
        private Vector2 currentPosition;
        private Animator m_Animator;
        private CharacterState m_CharacterState;
        private int animationIndex;

        void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_CharacterState = CharacterState.standDown;
            lastPosition = transform.position;
            currentPosition = lastPosition;
            animationIndex = Random.Range(0, 4);
            m_Animator.Play("StandDownAnimation" + animationIndex.ToString());
        }

        // Update is called once per frame
        void Update()
        {
            SetCharacterState();

           // UpdateInfoPosition();

            #region 控制角色行走动画
            //if (Vector3.Distance(m_targetPosition, this.transform.position) > m_notMoveDistance)
            //{
            //    this.transform.Translate(m_speed * Time.deltaTime * (Vector2)Vector3.Normalize(m_targetPosition - (Vector2)this.transform.position));
            //}
            if (m_CharacterState == CharacterState.standDown && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "StandDownAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("StandDownAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.walkDown && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "WalkDownAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("WalkDownAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.standRight && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "StandRightAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("StandRightAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.standUp && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "StandUpAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("StandUpAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.walkRight && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "WalkRightAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("WalkRightAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.walkUp && m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "WalkUpAnimation" + animationIndex.ToString())
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_Animator.Play("WalkUpAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.standLeft)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                m_Animator.Play("StandRightAnimation" + animationIndex.ToString());
            }
            if (m_CharacterState == CharacterState.walkLeft)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                m_Animator.Play("WalkRightAnimation" + animationIndex.ToString());
            }
            #endregion
        }
        /// <summary>
        /// Called every frame to set the newest state of character
        /// </summary>
        private void SetCharacterState()
        {
            var deltaPosition = currentPosition - lastPosition;
            lastPosition = currentPosition;
            currentPosition = transform.position;
            deltaPosition = Vector3.Normalize(deltaPosition);
            if (deltaPosition == Vector2.zero)
            {
                if (m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkRightAnimation" + animationIndex.ToString())
                {
                    m_CharacterState = CharacterState.standRight;
                }
                if (m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkRightAnimation" + animationIndex.ToString() && this.GetComponent<SpriteRenderer>().flipX)
                {
                    m_CharacterState = CharacterState.standLeft;
                }
                if (m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkDownAnimation" + animationIndex.ToString())
                {
                    m_CharacterState = CharacterState.standDown;
                }
                if (m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkUpAnimation" + animationIndex.ToString())
                {
                    m_CharacterState = CharacterState.standUp;
                }
                return;
            }
            var angle = Vector2.Angle(Vector2.up, deltaPosition);
            if (angle < 45)
            {
                m_CharacterState = CharacterState.walkUp;
            }
            if (angle > 135)
            {
                m_CharacterState = CharacterState.walkDown;
            }
            if (angle >= 45 && angle <= 135 && deltaPosition.x > 0)
            {
                m_CharacterState = CharacterState.walkRight;
            }
            if (angle >= 45 && angle <= 135 && deltaPosition.x <= 0)
            {
                m_CharacterState = CharacterState.walkLeft;
            }

        }
        private void UpdateInfoPosition()
        {
            characterInfo.transform.localPosition = Camera.main.WorldToScreenPoint(transform.position) - new Vector3(Screen.width / 2, (Screen.height / 2) - characterInfoDeviation, 0);
            //characterAnswer.transform.localPosition = Camera.main.WorldToScreenPoint(transform.position) - new Vector3((Screen.width / 2) - characterAnswerDeviation, Screen.height / 2 - 120, 0);
        }

        private void SetAnswerTrue()
        {
            //characterAnswer.SetActive(true);
        }
        private void SetAnswerFalse()
        {
            //characterAnswer.SetActive(false);
        }
        private void OnMouseEnter()
        {
            if (OnMouseEnterEvent_Character != null)
            {
                OnMouseEnterEvent_Character();
            }
            SetAnswerTrue();
            Invoke("SetAnswerFalse", 2.0f);
        }

        
    }

}
