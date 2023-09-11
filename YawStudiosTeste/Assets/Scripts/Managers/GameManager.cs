using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
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
    }
}
