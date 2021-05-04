using UnityEngine;
using Random = UnityEngine.Random;

namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject targetPrefab;

        [Header("Spawn distance")]
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        [Header("Spawn height")]
        [SerializeField] [Min(0)] private float minHeight;
        [SerializeField] [Min(0)] private float maxHeight;

        [Header("Spawn miscellaneous")]
        [SerializeField] [Min(1)] private int spawnCount;
        [SerializeField] [Min(0)] private float durationBetweenSpawns;
        [SerializeField] [Range(0, 360)] private float spawnAngle;

        private float _currentDuration;

        private void Start()
        {
            minDistance = Settings.MinDistance;
            maxDistance = Settings.MaxDistance;
            minHeight = Settings.MinHeight;
            maxHeight = Settings.MaxHeight;
            spawnAngle = Settings.SpawnAngle;
            spawnCount = Settings.SpawnCount;
            durationBetweenSpawns = Settings.DurationBetweenSpawns;
        }

        private void Update()
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= durationBetweenSpawns)
            {
                SpawnTargets();
                _currentDuration = 0;
            }
        }

        private void SpawnTargets()
        {
            for (var i = 0; i < spawnCount; i++)
            {
                var target = Instantiate(targetPrefab, GetRandomTargetPosition(), Quaternion.identity);
                target.transform.LookAt(Vector3.zero);

                var scale = target.transform.localScale;
                scale.z *= -1;
                target.transform.localScale = scale;
            }
        }

        private Vector3 GetRandomTargetPosition()
        {
            var radius = Random.Range(minDistance, maxDistance);

            var minAngle = -spawnAngle / 2 * Mathf.Deg2Rad;
            var maxAngle = +spawnAngle / 2 * Mathf.Deg2Rad;
            var angle = Random.Range(minAngle, maxAngle);

            var x = radius * Mathf.Cos(angle);
            var y = Random.Range(minHeight, maxHeight);
            var z = radius * Mathf.Sin(angle);

            return new Vector3(x, y, z);
        }
    }
}
