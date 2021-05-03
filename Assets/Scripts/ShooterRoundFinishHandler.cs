using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterRoundFinishHandler : MonoBehaviour
{
    private const string ShooterSettingsScene = "ShooterSettings";

    public void OnRoundFinish()
    {
        SceneManager.LoadScene(ShooterSettingsScene);
    }
}
