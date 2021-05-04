using System.Globalization;
using TMPro;
using UnityEngine;

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
        }
    }
}
