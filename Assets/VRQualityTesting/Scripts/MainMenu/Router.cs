using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRQualityTesting.Scripts.MainMenu
{
    public class Router : MonoBehaviour
    {
        private const string MenuSceneSuffix = "Menu";
        [SerializeField] private TMP_Dropdown gamePicker;

        public void RouteToNextScene()
        {
            var sceneName = gamePicker.options[gamePicker.value].text + MenuSceneSuffix;
            SceneManager.LoadScene(sceneName);
        }
    }
}
