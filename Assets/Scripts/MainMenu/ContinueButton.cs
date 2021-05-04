using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private TMP_InputField studyIdField;
        [SerializeField] private TMP_InputField participantIdField;
        [SerializeField] private TMP_Dropdown gamePicker;
        [SerializeField] private TMP_Text errorText;

        private readonly Dictionary<string, string> _gameToSceneName = new Dictionary<string, string>();

        private void Awake()
        {
            _gameToSceneName["Shooter"] = "ShooterSettings";
            _gameToSceneName["Fruit Ninja"] = "FruitNinjaSettings";
            _gameToSceneName["Pick And Place"] = "PickAndPlaceSettings";

            gamePicker.options = _gameToSceneName.Keys.Select(pickerOption => new TMP_Dropdown.OptionData(pickerOption)).ToList();
        }

        public void RouteToSelectedGame()
        {
            if (!AllFieldsAreFilledIn()) return;
            UpdateMainMenuSettings();

            var selectedGame = gamePicker.options[gamePicker.value].text;
            var sceneName = _gameToSceneName[selectedGame];
            SceneManager.LoadScene(sceneName);
        }

        private bool AllFieldsAreFilledIn()
        {
            if (string.IsNullOrEmpty(studyIdField.text))
            {
                errorText.text = "Study ID is required!";
                return false;
            }

            if (string.IsNullOrEmpty(participantIdField.text))
            {
                errorText.text = "Participant ID is required!";
                return false;
            }

            return true;
        }

        private void UpdateMainMenuSettings()
        {
            MainMenuSettings.StudyID = studyIdField.text;
            MainMenuSettings.ParticipantID = participantIdField.text;
        }
    }
}
