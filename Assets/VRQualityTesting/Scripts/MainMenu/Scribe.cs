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
            studyIdField.text = Settings.GetString(MainMenuKeys.StudyID);
            participantIdField.text = Settings.GetString(MainMenuKeys.ParticipantID);

            gamePicker.options = router.GameTitleToSceneName.Keys.Select(gameTitle => new TMP_Dropdown.OptionData(gameTitle)).ToList();
            gamePicker.value = Settings.GetInt(MainMenuKeys.SelectedGameIndex);
        }

        public void SaveSettings()
        {
            Settings.SetString(MainMenuKeys.StudyID, studyIdField.text);
            Settings.SetString(MainMenuKeys.ParticipantID, participantIdField.text);
            Settings.SetInt(MainMenuKeys.SelectedGameIndex, gamePicker.value);
        }
    }
}