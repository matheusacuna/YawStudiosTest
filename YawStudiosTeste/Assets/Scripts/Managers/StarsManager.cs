using System;
using UnityEngine;

namespace Managers
{

    public class StarsManager : MonoBehaviour
    {
        public static Action ACT_IncrementStar;
        public int starsCount;
        public string levelIdentifier;

        private void OnEnable()
        {
            ACT_IncrementStar += IncrementStar;
        }

        private void OnDisable()
        {
            ACT_IncrementStar -= IncrementStar;
        }

        public void IncrementStar()
        {
            starsCount++;
        }

        public void SaveStars()
        {
            PlayerPrefs.SetInt("Stars_" + levelIdentifier, starsCount);
            PlayerPrefs.Save();
            Debug.Log("Estrelas salvas para " + levelIdentifier);
        }
    }
}
