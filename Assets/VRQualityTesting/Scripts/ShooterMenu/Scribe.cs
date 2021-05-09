using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.ShooterMenu
{
    public class Scribe : MonoBehaviour
    {
        [SerializeField] private TMP_InputField minDistanceField;
        [SerializeField] private TMP_InputField maxDistanceField;
        [SerializeField] private TMP_InputField minHeightField;
        [SerializeField] private TMP_InputField maxHeightField;
        [SerializeField] private TMP_InputField spawnAngleField;
        [SerializeField] private TMP_InputField spawnCountField;
        [SerializeField] private TMP_InputField durationBetweenSpawnsField;

        [SerializeField] private TMP_InputField minSizeField;
        [SerializeField] private TMP_InputField maxSizeField;
        [SerializeField] private TMP_InputField movingProbabilityField;
        [SerializeField] private TMP_InputField minVelocityField;
        [SerializeField] private TMP_InputField maxVelocityField;
        [SerializeField] private TMP_InputField minOffsetField;
        [SerializeField] private TMP_InputField maxOffsetField;

        [SerializeField] private TMP_Dropdown weaponTypeDropdown;
        [SerializeField] private Toggle useLaserToggle;
        [SerializeField] private Toggle showBulletTrajectoryToggle;
        [SerializeField] private Toggle showMuzzleFlashToggle;

        [SerializeField] private TMP_InputField roundDurationField;

        private void Start() => InitializeSettings();

        private void InitializeSettings()
        {
            InitializeTargetSpawnerSettings();
            InitializeTargetSettings();
            InitializeWeaponSettings();
            InitializeRoundSettings();
        }

        private void InitializeTargetSpawnerSettings()
        {
            minDistanceField.text = Settings.GetFloat(SettingsKeys.Shooter.MinDistance, defaultValue: 8f).ToString(CultureInfo.InvariantCulture);
            maxDistanceField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxDistance, defaultValue: 12f).ToString(CultureInfo.InvariantCulture);
            minHeightField.text = Settings.GetFloat(SettingsKeys.Shooter.MinHeight, defaultValue: 3f).ToString(CultureInfo.InvariantCulture);
            maxHeightField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxHeight, defaultValue: 7f).ToString(CultureInfo.InvariantCulture);
            spawnAngleField.text = Settings.GetFloat(SettingsKeys.Shooter.SpawnAngle, defaultValue: 90f).ToString(CultureInfo.InvariantCulture);
            spawnCountField.text = Settings.GetInt(SettingsKeys.Shooter.SpawnCount, defaultValue: 3).ToString(CultureInfo.InvariantCulture);
            durationBetweenSpawnsField.text = Settings.GetFloat(SettingsKeys.Shooter.DurationBetweenSpawns, defaultValue: 0f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeTargetSettings()
        {
            minSizeField.text = Settings.GetFloat(SettingsKeys.Shooter.MinSize, defaultValue: 0.5f).ToString(CultureInfo.InvariantCulture);
            maxSizeField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxSize, defaultValue: 2f).ToString(CultureInfo.InvariantCulture);
            movingProbabilityField.text = Settings.GetFloat(SettingsKeys.Shooter.MovingProbability, defaultValue: 0.2f).ToString(CultureInfo.InvariantCulture);
            minVelocityField.text = Settings.GetFloat(SettingsKeys.Shooter.MinVelocity, defaultValue: 0.5f).ToString(CultureInfo.InvariantCulture);
            maxVelocityField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxVelocity, defaultValue: 5f).ToString(CultureInfo.InvariantCulture);
            minOffsetField.text = Settings.GetFloat(SettingsKeys.Shooter.MinOffset, defaultValue: 2f).ToString(CultureInfo.InvariantCulture);
            maxOffsetField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxOffset, defaultValue: 8f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeWeaponSettings()
        {
            weaponTypeDropdown.value = Settings.GetInt(SettingsKeys.Shooter.WeaponType);
            useLaserToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.UseLaser, defaultValue: true);
            showBulletTrajectoryToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.ShowBulletTrajectory, defaultValue: true);
            showMuzzleFlashToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.ShowMuzzleFlash, defaultValue: true);
        }

        private void InitializeRoundSettings()
        {
            roundDurationField.text = Settings.GetFloat(SettingsKeys.Shooter.RoundDuration, defaultValue: 60f).ToString(CultureInfo.InvariantCulture);
        }

        public void SaveSettings()
        {
            SaveTargetSpawnerSettings();
            SaveTargetSettings();
            SaveWeaponSettings();
            SaveRoundSettings();
        }

        private void SaveTargetSpawnerSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.MinDistance, float.Parse(minDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxDistance, float.Parse(maxDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinHeight, float.Parse(minHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxHeight, float.Parse(maxHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.SpawnAngle, float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture));
            Settings.SetInt(SettingsKeys.Shooter.SpawnCount, int.Parse(spawnCountField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.DurationBetweenSpawns, float.Parse(durationBetweenSpawnsField.text, CultureInfo.InvariantCulture));
        }

        private void SaveTargetSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.MinSize, float.Parse(minSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxSize, float.Parse(maxSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MovingProbability, float.Parse(movingProbabilityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinVelocity, float.Parse(minVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxVelocity, float.Parse(maxVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinOffset, float.Parse(minOffsetField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxOffset, float.Parse(maxOffsetField.text, CultureInfo.InvariantCulture));
        }

        private void SaveWeaponSettings()
        {
            Settings.SetInt(SettingsKeys.Shooter.WeaponType, weaponTypeDropdown.value);
            Settings.SetBool(SettingsKeys.Shooter.UseLaser, useLaserToggle.isOn);
            Settings.SetBool(SettingsKeys.Shooter.ShowBulletTrajectory, showBulletTrajectoryToggle.isOn);
            Settings.SetBool(SettingsKeys.Shooter.ShowMuzzleFlash, showMuzzleFlashToggle.isOn);
        }

        private void SaveRoundSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.RoundDuration, float.Parse(roundDurationField.text, CultureInfo.InvariantCulture));
        }
    }
}
