using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        public void LoadScene() => SceneManager.LoadScene(sceneToLoad);
    }
}
