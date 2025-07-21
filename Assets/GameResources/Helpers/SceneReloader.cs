using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sorter
{
    public class SceneReloader : MonoBehaviour
    {
        // Перезагрузить текущую активную сцену
        public void ReloadScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
