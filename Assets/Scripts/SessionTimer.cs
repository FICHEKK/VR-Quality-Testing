using UnityEngine;
using UnityEngine.Events;

public class SessionTimer : MonoBehaviour
{
    public UnityEvent onTimerRunOut;

    [SerializeField] [Min(0)] private float sessionDuration;
    private float _currentDuration;

    private void Update()
    {
        _currentDuration += Time.deltaTime;

        if (_currentDuration >= sessionDuration)
        {
            Debug.Log("Time is up!");
            onTimerRunOut?.Invoke();
            Destroy(this);
        }
    }
}
