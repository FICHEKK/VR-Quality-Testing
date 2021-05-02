using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private int spawnCount;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] [Range(0, 360)] private float spawnAngle;
    [SerializeField] [Range(0, 3)] private float durationBetweenSpawns;

    private float _currentDuration;

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
        var z = radius * Mathf.Sin(angle);

        return new Vector3(x, 0, z);
    }
}
