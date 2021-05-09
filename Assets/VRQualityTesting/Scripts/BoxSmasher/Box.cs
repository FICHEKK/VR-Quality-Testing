using UnityEngine;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class Box : MonoBehaviour
    {
        private SessionReporter _sessionReporter;

        private void Awake()
        {
            _sessionReporter = FindObjectOfType<SessionReporter>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _sessionReporter.OnBoxCollision(this, collision);
        }
    }
}