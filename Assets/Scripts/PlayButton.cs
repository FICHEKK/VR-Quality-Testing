using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private const string ShooterGameScene = "ShooterGame";

    [SerializeField] private TMP_InputField minDistanceField;
    [SerializeField] private TMP_InputField maxDistanceField;
    [SerializeField] private TMP_InputField minHeightField;
    [SerializeField] private TMP_InputField maxHeightField;
    [SerializeField] private TMP_InputField spawnAngleField;
    [SerializeField] private TMP_InputField spawnCountField;
    [SerializeField] private TMP_InputField durationBetweenSpawnsField;
    [SerializeField] private TMP_InputField roundDurationField;

    private void Start()
    {
        minDistanceField.text = ShooterSettings.MinDistance.ToString(CultureInfo.InvariantCulture);
        maxDistanceField.text = ShooterSettings.MaxDistance.ToString(CultureInfo.InvariantCulture);
        minHeightField.text = ShooterSettings.MinHeight.ToString(CultureInfo.InvariantCulture);
        maxHeightField.text = ShooterSettings.MaxHeight.ToString(CultureInfo.InvariantCulture);
        spawnAngleField.text = ShooterSettings.SpawnAngle.ToString(CultureInfo.InvariantCulture);
        spawnCountField.text = ShooterSettings.SpawnCount.ToString(CultureInfo.InvariantCulture);
        durationBetweenSpawnsField.text = ShooterSettings.DurationBetweenSpawns.ToString(CultureInfo.InvariantCulture);
        roundDurationField.text = ShooterSettings.RoundDuration.ToString(CultureInfo.InvariantCulture);
    }

    public void OnClick()
    {
        ShooterSettings.MinDistance = float.Parse(minDistanceField.text, CultureInfo.InvariantCulture);
        ShooterSettings.MaxDistance = float.Parse(maxDistanceField.text, CultureInfo.InvariantCulture);
        ShooterSettings.MinHeight = float.Parse(minHeightField.text, CultureInfo.InvariantCulture);
        ShooterSettings.MaxHeight = float.Parse(maxHeightField.text, CultureInfo.InvariantCulture);
        ShooterSettings.SpawnAngle = float.Parse(spawnAngleField.text, CultureInfo.InvariantCulture);
        ShooterSettings.SpawnCount = int.Parse(spawnCountField.text, CultureInfo.InvariantCulture);
        ShooterSettings.DurationBetweenSpawns = float.Parse(durationBetweenSpawnsField.text, CultureInfo.InvariantCulture);
        ShooterSettings.RoundDuration = float.Parse(roundDurationField.text, CultureInfo.InvariantCulture);

        SceneManager.LoadScene(ShooterGameScene);
    }
}
