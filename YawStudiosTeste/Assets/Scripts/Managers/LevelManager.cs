using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Level Manager Settings")]
        [SerializeField] private GameObject prefabLevelButton;
        [SerializeField] private Transform container;
        [SerializeField] private HandleScene handleScene;

        void Start()
        {
            InstantiateLevelsButtons();
        }

        private void InstantiateLevelsButtons()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings - 1;

            for (int i = 0; i < sceneCount; i++)
            {
                int levelIndex = i + 1;
                GameObject obj = Instantiate(prefabLevelButton, container);
                obj.GetComponent<Button>().onClick.AddListener(() => handleScene.LoadScene($"Level{levelIndex}"));
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelIndex.ToString();
                obj.GetComponent<StarsDisplayManager>().levelIdentifier = $"{levelIndex}";
            }
        }
    }
}
