using System.Globalization;
using TMPro;
using UnityEngine;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasherMenu
{
    public class Scribe : MonoBehaviour
    {
        [SerializeField] private TMP_InputField spawnDistanceField;
        [SerializeField] private TMP_InputField spawnAngleField;
        [SerializeField] private TMP_InputField spawnCountField;
        [SerializeField] private TMP_InputField tiltAngleField;

        [SerializeField] private TMP_InputField minShootForceField;
        [SerializeField] private TMP_InputField maxShootForceField;
        [SerializeField] private TMP_InputField minDurationBetweenShotsField;
        [SerializeField] private TMP_InputField maxDurationBetweenShotsField;
        [SerializeField] private TMP_InputField minBoxSizeField;
        [SerializeField] private TMP_InputField maxBoxSizeField;

        [SerializeField] private TMP_Dropdown leftHandWeaponTypeDropdown;
        [SerializeField] private TMP_Dropdown rightHandWeaponTypeDropdown;

        [SerializeField] private TMP_InputField roundDurationField;

        private void Start() => InitializeSettings();

        private void InitializeSettings()
        {
            InitializeCannonSpawnerSettings();
            InitializeCannonSettings();
            InitializeWeaponSettings();
            InitializeRoundSettings();
        }

        private void InitializeCannonSpawnerSettings()
        {
            spawnDistanceField.text = Settings.GetFloat(BoxSmasherKeys.SpawnDistance, defaultValue: 1f).ToString(CultureInfo.InvariantCulture);
            spawnAngleField.text = Settings.GetFloat(BoxSmasherKeys.SpawnAngle, defaultValue: 90f).ToString(CultureInfo.InvariantCulture);
            spawnCountField.text = Settings.GetInt(BoxSmasherKeys.SpawnCount, defaultValue: 4).ToString(CultureInfo.InvariantCulture);
            tiltAngleField.text = Settings.GetFloat(BoxSmasherKeys.TiltAngle, defaultValue: 90f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeCannonSettings()
        {
            minShootForceField.text = Settings.GetFloat(BoxSmasherKeys.MinShootForce, defaultValue: 6f).ToString(CultureInfo.InvariantCulture);
            maxShootForceField.text = Settings.GetFloat(BoxSmasherKeys.MaxShootForce, defaultValue: 7f).ToString(CultureInfo.InvariantCulture);
            minDurationBetweenShotsField.text = Settings.GetFloat(BoxSmasherKeys.MinDurationBetweenShots, defaultValue: 3f).ToString(CultureInfo.InvariantCulture);
            maxDurationBetweenShotsField.text = Settings.GetFloat(BoxSmasherKeys.MaxDurationBetweenShots, defaultValue: 4f).ToString(CultureInfo.InvariantCulture);
            minBoxSizeField.text = Settings.GetFloat(BoxSmasherKeys.MinBoxSize, defaultValue: 0.3f).ToString(CultureInfo.InvariantCulture);
            maxBoxSizeField.text = Settings.GetFloat(BoxSmasherKeys.MaxBoxSize, defaultValue: 0.4f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeWeaponSettings()
        {
            leftHandWeaponTypeDropdown.value = Settings.GetInt(BoxSmasherKeys.LeftHandWeaponType);
            rightHandWeaponTypeDropdown.value = Settings.GetInt(BoxSmasherKeys.RightHandWeaponType);
        }

        private void InitializeRoundSettings()
        {
            roundDurationField.text = Settings.GetFloat(BoxSmasherKeys.RoundDuration, defaultValue: 60f).ToString(CultureInfo.InvariantCulture);
        }

        public void SaveSettings()
        {
            SaveCannonSpawnerSettings();
            SaveCannonSettings();
            SaveWeaponSettings();
            SaveRoundSettings();
        }

        private void SaveCannonSpawnerSettings()
        {
            Settings.SetFloat(BoxSmasherKeys.SpawnDistance, float.Parse(spawnDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.SpawnAngle, float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture));
            Settings.SetInt(BoxSmasherKeys.SpawnCount, int.Parse(spawnCountField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.TiltAngle, float.Parse(tiltAngleField.text, CultureInfo.InvariantCulture));
        }

        private void SaveCannonSettings()
        {
            Settings.SetFloat(BoxSmasherKeys.MinShootForce, float.Parse(minShootForceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.MaxShootForce, float.Parse(maxShootForceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.MinDurationBetweenShots, float.Parse(minDurationBetweenShotsField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.MaxDurationBetweenShots, float.Parse(maxDurationBetweenShotsField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.MinBoxSize, float.Parse(minBoxSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(BoxSmasherKeys.MaxBoxSize, float.Parse(maxBoxSizeField.text, CultureInfo.InvariantCulture));
        }

        private void SaveWeaponSettings()
        {
            Settings.SetInt(BoxSmasherKeys.LeftHandWeaponType, leftHandWeaponTypeDropdown.value);
            Settings.SetInt(BoxSmasherKeys.RightHandWeaponType, rightHandWeaponTypeDropdown.value);
        }

        private void SaveRoundSettings()
        {
            Settings.SetFloat(BoxSmasherKeys.RoundDuration, float.Parse(roundDurationField.text, CultureInfo.InvariantCulture));
        }
    }
}
