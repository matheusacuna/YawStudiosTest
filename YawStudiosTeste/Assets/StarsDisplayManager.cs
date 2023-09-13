using UnityEngine;
using TMPro;

namespace Managers
{
    public class StarsDisplayManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI starsText;
        public string levelIdentifier; 

        private void Start()
        {
            int starsCount = PlayerPrefs.GetInt("Stars_" + levelIdentifier);
            starsText.text = starsCount.ToString();
        }
    }
}
