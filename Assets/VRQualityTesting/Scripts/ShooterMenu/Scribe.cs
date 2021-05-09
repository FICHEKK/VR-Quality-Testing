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
            minDistanceField.text = Settings.GetFloat(ShooterKeys.MinDistance, defaultValue: 8f).ToString(CultureInfo.InvariantCulture);
            maxDistanceField.text = Settings.GetFloat(ShooterKeys.MaxDistance, defaultValue: 12f).ToString(CultureInfo.InvariantCulture);
            minHeightField.text = Settings.GetFloat(ShooterKeys.MinHeight, defaultValue: 3f).ToString(CultureInfo.InvariantCulture);
            maxHeightField.text = Settings.GetFloat(ShooterKeys.MaxHeight, defaultValue: 7f).ToString(CultureInfo.InvariantCulture);
            spawnAngleField.text = Settings.GetFloat(ShooterKeys.SpawnAngle, defaultValue: 90f).ToString(CultureInfo.InvariantCulture);
            spawnCountField.text = Settings.GetInt(ShooterKeys.SpawnCount, defaultValue: 3).ToString(CultureInfo.InvariantCulture);
            durationBetweenSpawnsField.text = Settings.GetFloat(ShooterKeys.DurationBetweenSpawns, defaultValue: 0f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeTargetSettings()
        {
            minSizeField.text = Settings.GetFloat(ShooterKeys.MinSize, defaultValue: 0.5f).ToString(CultureInfo.InvariantCulture);
            maxSizeField.text = Settings.GetFloat(ShooterKeys.MaxSize, defaultValue: 2f).ToString(CultureInfo.InvariantCulture);
            movingProbabilityField.text = Settings.GetFloat(ShooterKeys.MovingProbability, defaultValue: 0.2f).ToString(CultureInfo.InvariantCulture);
            minVelocityField.text = Settings.GetFloat(ShooterKeys.MinVelocity, defaultValue: 0.5f).ToString(CultureInfo.InvariantCulture);
            maxVelocityField.text = Settings.GetFloat(ShooterKeys.MaxVelocity, defaultValue: 5f).ToString(CultureInfo.InvariantCulture);
            minOffsetField.text = Settings.GetFloat(ShooterKeys.MinOffset, defaultValue: 2f).ToString(CultureInfo.InvariantCulture);
            maxOffsetField.text = Settings.GetFloat(ShooterKeys.MaxOffset, defaultValue: 8f).ToString(CultureInfo.InvariantCulture);
        }

        private void InitializeWeaponSettings()
        {
            weaponTypeDropdown.value = Settings.GetInt(ShooterKeys.WeaponType);
            useLaserToggle.isOn = Settings.GetBool(ShooterKeys.UseLaser, defaultValue: true);
            showBulletTrajectoryToggle.isOn = Settings.GetBool(ShooterKeys.ShowBulletTrajectory, defaultValue: true);
            showMuzzleFlashToggle.isOn = Settings.GetBool(ShooterKeys.ShowMuzzleFlash, defaultValue: true);
        }

        private void InitializeRoundSettings()
        {
            roundDurationField.text = Settings.GetFloat(ShooterKeys.RoundDuration, defaultValue: 60f).ToString(CultureInfo.InvariantCulture);
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
            Settings.SetFloat(ShooterKeys.MinDistance, float.Parse(minDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MaxDistance, float.Parse(maxDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MinHeight, float.Parse(minHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MaxHeight, float.Parse(maxHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.SpawnAngle, float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture));
            Settings.SetInt(ShooterKeys.SpawnCount, int.Parse(spawnCountField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.DurationBetweenSpawns, float.Parse(durationBetweenSpawnsField.text, CultureInfo.InvariantCulture));
        }

        private void SaveTargetSettings()
        {
            Settings.SetFloat(ShooterKeys.MinSize, float.Parse(minSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MaxSize, float.Parse(maxSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MovingProbability, float.Parse(movingProbabilityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MinVelocity, float.Parse(minVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MaxVelocity, float.Parse(maxVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MinOffset, float.Parse(minOffsetField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(ShooterKeys.MaxOffset, float.Parse(maxOffsetField.text, CultureInfo.InvariantCulture));
        }

        private void SaveWeaponSettings()
        {
            Settings.SetInt(ShooterKeys.WeaponType, weaponTypeDropdown.value);
            Settings.SetBool(ShooterKeys.UseLaser, useLaserToggle.isOn);
            Settings.SetBool(ShooterKeys.ShowBulletTrajectory, showBulletTrajectoryToggle.isOn);
            Settings.SetBool(ShooterKeys.ShowMuzzleFlash, showMuzzleFlashToggle.isOn);
        }

        private void SaveRoundSettings()
        {
            Settings.SetFloat(ShooterKeys.RoundDuration, float.Parse(roundDurationField.text, CultureInfo.InvariantCulture));
        }
    }
}
