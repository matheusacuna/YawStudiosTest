using System;
using UnityEngine;

namespace Managers
{ 
    public class HealthManager : MonoBehaviour
    {
        [Header("Health Settings")]
        public int healthPoint;
        public GameObject prefabHealthIcon;
        public Transform containerHealthIcon;

        public static Action<int> ACT_IncrementHealth;
        public static Action<int> ACT_DecrementHealth;

        private GameObject[] healthIcons;

        public static HealthManager instance;
        private void Awake()
        {
            if (instance == null)
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
            ACT_IncrementHealth += IncrementHealth;
            ACT_DecrementHealth += DecrementHealth;
        }

        private void OnDisable()
        {
            ACT_IncrementHealth -= IncrementHealth;
            ACT_DecrementHealth -= DecrementHealth;
        }

        private void Start()
        {
            InstantiateHealthIcons();
        }

        private void InstantiateHealthIcons()
        {
            healthIcons = new GameObject[healthPoint]; 

            for (int i = 0; i < healthPoint; i++)
            {
                healthIcons[i] = Instantiate(prefabHealthIcon, containerHealthIcon);
            }
        }

        public void IncrementHealth(int value)
        {
            healthPoint += value;

            if (healthPoint > healthIcons.Length)
            {           
                int lastIndex = healthIcons.Length - 1;
                if (lastIndex >= 0)
                {
                    healthIcons[lastIndex].SetActive(true);
                }
            }
        }

        public void DecrementHealth(int value)
        {
            healthPoint -= value;

            for (int i = healthIcons.Length - 1; i >= 0; i--)
            {
                if (healthPoint >= i + 1)
                {                   
                    healthIcons[i].SetActive(true);
                }
                else
                {                   
                    healthIcons[i].SetActive(false);
                }
            }
        }
    }
}
