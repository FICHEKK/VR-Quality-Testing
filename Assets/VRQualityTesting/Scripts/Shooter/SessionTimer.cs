using UnityEngine;
using UnityEngine.Events;

namespace VRQualityTesting.Scripts.Shooter
{
    public class SessionTimer : MonoBehaviour
    {
        public UnityEvent onTimerRunOut;

        [SerializeField] [Min(0)] private float roundDuration;
        private float _currentDuration;

        private void Start()
        {
            roundDuration = Settings.RoundDuration;
        }

        private void Update()
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= roundDuration)
            {
                onTimerRunOut?.Invoke();
                Destroy(this);
            }
        }
    }
}
