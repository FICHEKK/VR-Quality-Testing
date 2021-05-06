using UnityEngine;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private TargetSpawner targetSpawner;

        private void Start()
        {
            InitializeTimer();
            InitializeTargetSpawner();
        }

        private void InitializeTimer()
        {
            timer.TimeLeft = Settings.RoundDuration;
        }

        private void InitializeTargetSpawner()
        {
            targetSpawner.MinDistance = Settings.MinDistance;
            targetSpawner.MaxDistance = Settings.MaxDistance;
            targetSpawner.MinHeight = Settings.MinHeight;
            targetSpawner.MaxHeight = Settings.MaxHeight;
            targetSpawner.SpawnAngle = Settings.SpawnAngle;
            targetSpawner.SpawnCount = Settings.SpawnCount;
            targetSpawner.DurationBetweenSpawns = Settings.DurationBetweenSpawns;
            targetSpawner.MinTargetSize = Settings.MinTargetSize;
            targetSpawner.MaxTargetSize = Settings.MaxTargetSize;

            targetSpawner.MovingTargetProbability = Settings.MovingTargetProbability;
            targetSpawner.MinVelocity = Settings.MinVelocity;
            targetSpawner.MaxVelocity = Settings.MaxVelocity;
            targetSpawner.MinOffset = Settings.MinOffset;
            targetSpawner.MaxOffset = Settings.MaxOffset;
        }
    }
}
