using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        public static GameManager Instance { get; private set; }

        public int PlayerScore { get; set; }

        public Difficult difficult { get; set; }
        public Signs signs { get; set; }


        public int wrongAnswerCount { get; set; }
        public int correctAnswerCount { get; set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Объект не уничтожается при загрузке новой сцены
            }
            else
            {
                Destroy(gameObject);
            }
        }



    private void Update()
    {
        Debug.Log( wrongAnswerCount.ToString());
    }

}
