using TMPro;
using UnityEngine;

namespace VRQualityTesting.Scripts.MainMenu
{
    public class Validator : MonoBehaviour
    {
        [SerializeField] private TMP_InputField studyIdField;
        [SerializeField] private TMP_InputField participantIdField;
        [SerializeField] private TMP_Text errorText;

        public bool AreAllSettingsValid()
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
    }
}
