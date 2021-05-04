using UnityEngine;
using Random = UnityEngine.Random;

namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetSpawner : MonoBehaviour
    {
        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public int SpawnCount { get; set; }
        public float DurationBetweenSpawns { get; set; }
        public float SpawnAngle { get; set; }

        [SerializeField] private GameObject targetPrefab;
        private float _currentDuration;

        private void Update()
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= DurationBetweenSpawns)
            {
                SpawnTargets();
                _currentDuration = 0;
            }
        }

        private void SpawnTargets()
        {
            for (var i = 0; i < SpawnCount; i++)
            {
                var target = Instantiate(targetPrefab, GetRandomTargetPosition(), Quaternion.identity);
                target.transform.LookAt(2 * target.transform.position);
            }
        }

        private Vector3 GetRandomTargetPosition()
        {
            var radius = Random.Range(MinDistance, MaxDistance);

            var minAngle = -SpawnAngle / 2 * Mathf.Deg2Rad;
            var maxAngle = +SpawnAngle / 2 * Mathf.Deg2Rad;
            var angle = Random.Range(minAngle, maxAngle);

            var x = radius * Mathf.Cos(angle);
            var y = Random.Range(MinHeight, MaxHeight);
            var z = radius * Mathf.Sin(angle);

            return new Vector3(x, y, z);
        }
    }
}
