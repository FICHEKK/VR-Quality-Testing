using UnityEngine;
using UnityEngine.Events;

public class SessionTimer : MonoBehaviour
{
    public UnityEvent onTimerRunOut;

    [SerializeField] [Min(0)] private float roundDuration;
    private float _currentDuration;

    private void Start()
    {
        roundDuration = ShooterSettings.RoundDuration;
    }

    private void Update()
    {
        _currentDuration += Time.deltaTime;

        if (_currentDuration >= roundDuration)
        {
            Debug.Log("Time is up!");
            onTimerRunOut?.Invoke();
            Destroy(this);
        }
    }
}
