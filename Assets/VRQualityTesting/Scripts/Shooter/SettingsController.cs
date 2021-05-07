using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.Shooter
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField minDistanceField;
        [SerializeField] private TMP_InputField maxDistanceField;
        [SerializeField] private TMP_InputField minHeightField;
        [SerializeField] private TMP_InputField maxHeightField;
        [SerializeField] private TMP_InputField spawnAngleField;
        [SerializeField] private TMP_InputField spawnCountField;
        [SerializeField] private TMP_InputField durationBetweenSpawnsField;
        [SerializeField] private TMP_InputField roundDurationField;
        [SerializeField] private TMP_InputField minTargetSizeField;
        [SerializeField] private TMP_InputField maxTargetSizeField;

        [SerializeField] private TMP_InputField movingTargetProbabilityField;
        [SerializeField] private TMP_InputField minVelocityField;
        [SerializeField] private TMP_InputField maxVelocityField;
        [SerializeField] private TMP_InputField minOffsetField;
        [SerializeField] private TMP_InputField maxOffsetField;

        [SerializeField] private TMP_Dropdown weaponTypeDropdown;
        [SerializeField] private Toggle useLaserToggle;
        [SerializeField] private Toggle showBulletTrajectoryToggle;
        [SerializeField] private Toggle showMuzzleFlashToggle;

        private void Start() => InitializeSettings();

        private void InitializeSettings()
        {
            minDistanceField.text = Settings.GetFloat(SettingsKeys.Shooter.MinDistance).ToString(CultureInfo.InvariantCulture);
            maxDistanceField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxDistance).ToString(CultureInfo.InvariantCulture);
            minHeightField.text = Settings.GetFloat(SettingsKeys.Shooter.MinHeight).ToString(CultureInfo.InvariantCulture);
            maxHeightField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxHeight).ToString(CultureInfo.InvariantCulture);
            spawnAngleField.text = Settings.GetFloat(SettingsKeys.Shooter.SpawnAngle).ToString(CultureInfo.InvariantCulture);
            spawnCountField.text = Settings.GetInt(SettingsKeys.Shooter.SpawnCount).ToString(CultureInfo.InvariantCulture);
            durationBetweenSpawnsField.text = Settings.GetFloat(SettingsKeys.Shooter.DurationBetweenSpawns).ToString(CultureInfo.InvariantCulture);
            roundDurationField.text = Settings.GetFloat(SettingsKeys.Shooter.RoundDuration).ToString(CultureInfo.InvariantCulture);
            minTargetSizeField.text = Settings.GetFloat(SettingsKeys.Shooter.MinSize).ToString(CultureInfo.InvariantCulture);
            maxTargetSizeField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxSize).ToString(CultureInfo.InvariantCulture);

            movingTargetProbabilityField.text = Settings.GetFloat(SettingsKeys.Shooter.MovingProbability).ToString(CultureInfo.InvariantCulture);
            minVelocityField.text = Settings.GetFloat(SettingsKeys.Shooter.MinVelocity).ToString(CultureInfo.InvariantCulture);
            maxVelocityField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxVelocity).ToString(CultureInfo.InvariantCulture);
            minOffsetField.text = Settings.GetFloat(SettingsKeys.Shooter.MinOffset).ToString(CultureInfo.InvariantCulture);
            maxOffsetField.text = Settings.GetFloat(SettingsKeys.Shooter.MaxOffset).ToString(CultureInfo.InvariantCulture);

            weaponTypeDropdown.value = Settings.GetInt(SettingsKeys.Shooter.WeaponType);
            useLaserToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.UseLaser);
            showBulletTrajectoryToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.ShowBulletTrajectory);
            showMuzzleFlashToggle.isOn = Settings.GetBool(SettingsKeys.Shooter.ShowMuzzleFlash);
        }

        public void UpdateSettings()
        {
            UpdateRoundSettings();
            UpdateTargetSpawnerSettings();
            UpdateTargetSettings();
            UpdateWeaponSettings();
        }

        private void UpdateRoundSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.RoundDuration, float.Parse(roundDurationField.text, CultureInfo.InvariantCulture));
        }

        private void UpdateTargetSpawnerSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.MinDistance, float.Parse(minDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxDistance, float.Parse(maxDistanceField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinHeight, float.Parse(minHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxHeight, float.Parse(maxHeightField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.SpawnAngle, float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture));
            Settings.SetInt(SettingsKeys.Shooter.SpawnCount, int.Parse(spawnCountField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.DurationBetweenSpawns, float.Parse(durationBetweenSpawnsField.text, CultureInfo.InvariantCulture));
        }

        private void UpdateTargetSettings()
        {
            Settings.SetFloat(SettingsKeys.Shooter.MinSize, float.Parse(minTargetSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxSize, float.Parse(maxTargetSizeField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MovingProbability, float.Parse(movingTargetProbabilityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinVelocity, float.Parse(minVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxVelocity, float.Parse(maxVelocityField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MinOffset, float.Parse(minOffsetField.text, CultureInfo.InvariantCulture));
            Settings.SetFloat(SettingsKeys.Shooter.MaxOffset, float.Parse(maxOffsetField.text, CultureInfo.InvariantCulture));
        }

        private void UpdateWeaponSettings()
        {
            Settings.SetInt(SettingsKeys.Shooter.WeaponType, weaponTypeDropdown.value);
            Settings.SetBool(SettingsKeys.Shooter.UseLaser, useLaserToggle.isOn);
            Settings.SetBool(SettingsKeys.Shooter.ShowBulletTrajectory, showBulletTrajectoryToggle.isOn);
            Settings.SetBool(SettingsKeys.Shooter.ShowMuzzleFlash, showMuzzleFlashToggle.isOn);
        }
    }
}
