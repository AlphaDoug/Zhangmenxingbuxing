using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordsmanGame
{
    public class GameController : MonoBehaviour
    {
        public GameObject character;
        public GameObject characterInfo;
        public GameObject characterInfoAnswer;
        public Vector2[] randomCreatPosition;
        public int initialNum;

        #region  委托的统一声明
        public delegate void OnMouseEnter_Character();
        public delegate void OnMouseEnter_Build(object sender, int index);
        public delegate void OnMouseExit_Build(object sender, int index);
        public delegate void OnMouseDown_Build(object sender,int index);
        public delegate void OnMouseDown_Choice(object sender, int index);
        public delegate void HaveNewTasks(bool a);
        #endregion
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < initialNum; i++)
            {
                CreatDisciple();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        /// <summary>
        /// 创建一个弟子并随机放置在场景中一个位置
        /// </summary>
        private void CreatDisciple()
        {
            var newCharacter = Instantiate(character, new Vector3(0, 0, 0), new Quaternion(), GameObject.FindGameObjectWithTag("CharacterItem").transform);
            newCharacter.transform.position = randomCreatPosition[Random.Range(0, randomCreatPosition.Length)];
            var newCharacterInfo = Instantiate(characterInfo, new Vector3(0, 0, 0), new Quaternion(), GameObject.FindGameObjectWithTag("CharacterInfo").transform);
            newCharacterInfo.transform.localPosition = Vector3.zero;
            foreach (Transform child in newCharacterInfo.transform)
            {
                if (child.gameObject.name == "Answer")
                {
                    newCharacter.GetComponent<CharactersController>().characterAnswer = child.gameObject;
                    child.gameObject.SetActive(false);
                }
                if (child.gameObject.name == "Info")
                {
                    newCharacter.GetComponent<CharactersController>().characterInfo = child.gameObject;
                }
            }
        }

    }

}
