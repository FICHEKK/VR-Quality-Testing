using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VRQualityTesting.Scripts.Shooter
{
    public class PlayButton : MonoBehaviour
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
        [SerializeField] private TMP_InputField minHorizontalVelocityField;
        [SerializeField] private TMP_InputField maxHorizontalVelocityField;
        [SerializeField] private TMP_InputField minVerticalVelocityField;
        [SerializeField] private TMP_InputField maxVerticalVelocityField;

        [SerializeField] private TMP_Dropdown weaponTypeDropdown;
        [SerializeField] private Toggle useLaserToggle;
        [SerializeField] private Toggle showBulletTrajectoryToggle;
        [SerializeField] private Toggle showMuzzleFlashToggle;

        private void Start()
        {
            minDistanceField.text = Settings.MinDistance.ToString(CultureInfo.InvariantCulture);
            maxDistanceField.text = Settings.MaxDistance.ToString(CultureInfo.InvariantCulture);
            minHeightField.text = Settings.MinHeight.ToString(CultureInfo.InvariantCulture);
            maxHeightField.text = Settings.MaxHeight.ToString(CultureInfo.InvariantCulture);
            spawnAngleField.text = Settings.SpawnAngle.ToString(CultureInfo.InvariantCulture);
            spawnCountField.text = Settings.SpawnCount.ToString(CultureInfo.InvariantCulture);
            durationBetweenSpawnsField.text = Settings.DurationBetweenSpawns.ToString(CultureInfo.InvariantCulture);
            roundDurationField.text = Settings.RoundDuration.ToString(CultureInfo.InvariantCulture);
            minTargetSizeField.text = Settings.MinTargetSize.ToString(CultureInfo.InvariantCulture);
            maxTargetSizeField.text = Settings.MaxTargetSize.ToString(CultureInfo.InvariantCulture);

            movingTargetProbabilityField.text = Settings.MovingTargetProbability.ToString(CultureInfo.InvariantCulture);
            minHorizontalVelocityField.text = Settings.MinVelocity.ToString(CultureInfo.InvariantCulture);
            maxHorizontalVelocityField.text = Settings.MaxVelocity.ToString(CultureInfo.InvariantCulture);
            minVerticalVelocityField.text = Settings.MinOffset.ToString(CultureInfo.InvariantCulture);
            maxVerticalVelocityField.text = Settings.MaxOffset.ToString(CultureInfo.InvariantCulture);

            weaponTypeDropdown.value = (int) Settings.WeaponType;
            useLaserToggle.isOn = Settings.UseLaser;
            showBulletTrajectoryToggle.isOn = Settings.ShowBulletTrajectory;
            showMuzzleFlashToggle.isOn = Settings.ShowMuzzleFlash;
        }

        public void UpdateShooterSettings()
        {
            Settings.MinDistance = float.Parse(minDistanceField.text, CultureInfo.InvariantCulture);
            Settings.MaxDistance = float.Parse(maxDistanceField.text, CultureInfo.InvariantCulture);
            Settings.MinHeight = float.Parse(minHeightField.text, CultureInfo.InvariantCulture);
            Settings.MaxHeight = float.Parse(maxHeightField.text, CultureInfo.InvariantCulture);
            Settings.SpawnAngle = float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture);
            Settings.SpawnCount = int.Parse(spawnCountField.text, CultureInfo.InvariantCulture);
            Settings.DurationBetweenSpawns = float.Parse(durationBetweenSpawnsField.text, CultureInfo.InvariantCulture);
            Settings.RoundDuration = float.Parse(roundDurationField.text, CultureInfo.InvariantCulture);
            Settings.MinTargetSize = float.Parse(minTargetSizeField.text, CultureInfo.InvariantCulture);
            Settings.MaxTargetSize = float.Parse(maxTargetSizeField.text, CultureInfo.InvariantCulture);

            Settings.MovingTargetProbability = float.Parse(movingTargetProbabilityField.text, CultureInfo.InvariantCulture);
            Settings.MinVelocity = float.Parse(minHorizontalVelocityField.text, CultureInfo.InvariantCulture);
            Settings.MaxVelocity = float.Parse(maxHorizontalVelocityField.text, CultureInfo.InvariantCulture);
            Settings.MinOffset = float.Parse(minVerticalVelocityField.text, CultureInfo.InvariantCulture);
            Settings.MaxOffset = float.Parse(maxVerticalVelocityField.text, CultureInfo.InvariantCulture);

            Settings.WeaponType = (WeaponType) weaponTypeDropdown.value;
            Settings.UseLaser = useLaserToggle.isOn;
            Settings.ShowBulletTrajectory = showBulletTrajectoryToggle.isOn;
            Settings.ShowMuzzleFlash = showMuzzleFlashToggle.isOn;
        }
    }
}
