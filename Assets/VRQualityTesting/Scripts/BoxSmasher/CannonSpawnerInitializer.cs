using UnityEngine;
using VRQualityTesting.Scripts.BoxSmasherMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class CannonSpawnerInitializer : MonoBehaviour
    {
        [SerializeField] private CannonSpawner cannonSpawner;

        private void Awake() => InitializeCannonSpawner();

        private void InitializeCannonSpawner()
        {
            cannonSpawner.SpawnDistance = Settings.GetFloat(BoxSmasherKeys.SpawnDistance);
            cannonSpawner.SpawnHeight = Settings.GetFloat(BoxSmasherKeys.SpawnHeight);
            cannonSpawner.SpawnAngle = Settings.GetFloat(BoxSmasherKeys.SpawnAngle);
            cannonSpawner.SpawnCount = Settings.GetInt(BoxSmasherKeys.SpawnCount);
            cannonSpawner.TiltAngle = Settings.GetFloat(BoxSmasherKeys.TiltAngle);
        }
    }
}