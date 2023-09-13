using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class HandleScene : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
