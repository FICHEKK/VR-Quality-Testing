using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRQualityTesting.Scripts.MainMenu
{
    public class Router : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown gamePicker;

        public IReadOnlyDictionary<string, string> GameTitleToSceneName { get; } = new Dictionary<string, string>
        {
            {"Shooter", "ShooterMenu"},
            {"Box Smasher", "BoxSmasherMenu"}
        };

        public void RouteToNextScene()
        {
            var selectedGame = gamePicker.options[gamePicker.value].text;
            var sceneName = GameTitleToSceneName[selectedGame];
            SceneManager.LoadScene(sceneName);
        }
    }
}
