using UnityEngine;
using VRQualityTesting.Scripts.BoxSmasherMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class TimerInitializer : MonoBehaviour
    {
        [SerializeField] private Timer timer;

        private void Awake() => InitializeTimer();

        private void InitializeTimer()
        {
            timer.TimeLeft = Settings.GetFloat(BoxSmasherKeys.RoundDuration);
        }
    }
}