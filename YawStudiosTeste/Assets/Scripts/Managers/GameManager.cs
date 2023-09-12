using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Win Game Settings")]
        public GameObject modalWinGame;

        [Header("Lose Game Settings")]
        public GameObject modalLoseGame;

        public bool startGame;
        public static Action<bool> ACT_CanStartGame;
        public static GameManager instance;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                DontDestroyOnLoad(instance);
            }
        }

        private void Start()
        {
            Time.timeScale = 1.0f;
        }

        private void Update()
        {
            LoserGame();
        }

        private void OnEnable()
        {
            ACT_CanStartGame += CanStartGame;
        }

        private void OnDisable()
        {
            ACT_CanStartGame -= CanStartGame;
        }
        public void CanStartGame(bool value)
        {
            startGame = value;
        }

        public void WinGame()
        {
            modalWinGame.SetActive(true);
            Time.timeScale = 0f;
        }

        public void LoserGame()
        {
            if(HealthManager.instance.healthPoint <= 0)
            {
                Time.timeScale = 0f;
                modalLoseGame.SetActive(true);
            }
        }
    }
}
