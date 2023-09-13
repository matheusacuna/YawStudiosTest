using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Script Reference")]
        public StarsManager starsManager;

        [Header("Win Game Settings")]
        public GameObject modalWinGame;
        public TextMeshProUGUI numberStars;

        [Header("Lose Game Settings")]
        public GameObject modalLoseGame;

        public bool startGame;
        public static Action<bool> ACT_CanStartGame;
        public static GameManager instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Time.timeScale = 1.0f;
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
            numberStars.text = starsManager.starsCount.ToString(); 
            Time.timeScale = 0f;
        }

        public void LoserGame()
        {
            Time.timeScale = 0f;
            modalLoseGame.SetActive(true);
        }
    }
}
