using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRQualityTesting.Scripts.Utility
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        public void LoadScene() => SceneManager.LoadScene(sceneToLoad);
    }
}
