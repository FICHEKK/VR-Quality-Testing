using System.Linq;
using TMPro;
using UnityEngine;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.MainMenu
{
    public class Scribe : MonoBehaviour
    {
        [SerializeField] private TMP_InputField studyIdField;
        [SerializeField] private TMP_InputField participantIdField;
        [SerializeField] private TMP_Dropdown gamePicker;
        [SerializeField] private Router router;

        private void Awake() => InitializeSettings();

        private void InitializeSettings()
        {
            studyIdField.text = Settings.GetString(SettingsKeys.MainMenu.StudyID);
            participantIdField.text = Settings.GetString(SettingsKeys.MainMenu.ParticipantID);

            gamePicker.options = router.GameTitleToSceneName.Keys.Select(gameTitle => new TMP_Dropdown.OptionData(gameTitle)).ToList();
            gamePicker.value = Settings.GetInt(SettingsKeys.MainMenu.SelectedGameIndex);
        }

        public void SaveSettings()
        {
            Settings.SetString(SettingsKeys.MainMenu.StudyID, studyIdField.text);
            Settings.SetString(SettingsKeys.MainMenu.ParticipantID, participantIdField.text);
            Settings.SetInt(SettingsKeys.MainMenu.SelectedGameIndex, gamePicker.value);
        }
    }
}