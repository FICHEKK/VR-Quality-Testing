using UnityEngine;
using UnityEngine.Events;

namespace VRQualityTesting.Scripts.Utility
{
    public class Timer : MonoBehaviour
    {
        private const float DefaultTimeLeft = 60;

        public float TimeLeft { get; set; } = DefaultTimeLeft;
        public UnityEvent onTimerRunOut;

        private void Update()
        {
            if (TimeLeft <= 0) return;
            TimeLeft -= Time.deltaTime;

            if (TimeLeft <= 0)
            {
                onTimerRunOut?.Invoke();
            }
        }
    }
}
