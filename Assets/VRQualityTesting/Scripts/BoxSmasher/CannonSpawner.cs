using UnityEngine;
using VRQualityTesting.Scripts.BoxSmasherMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class CannonSpawner : MonoBehaviour
    {
        public float SpawnDistance { get; set; }
        public float SpawnAngle { get; set; }
        public int SpawnCount { get; set; }
        public float TiltAngle { get; set; }

        [SerializeField] private GameObject cannonPrefab;

        private void Start() => SpawnCannons();

        private void SpawnCannons()
        {
            var angleStep = SpawnAngle / SpawnCount;

            for (var i = 0; i < SpawnCount; i++)
            {
                var angle = (i * angleStep - SpawnAngle / 2) * Mathf.Deg2Rad;
                var x = SpawnDistance * Mathf.Cos(angle);
                var z = SpawnDistance * Mathf.Sin(angle);

                var cannon = Instantiate(cannonPrefab, new Vector3(x, 2, z), Quaternion.identity);

                cannon.transform.LookAt(2 * cannon.transform.position);

                var newRotation = cannon.transform.eulerAngles;
                newRotation.x = -90;
                cannon.transform.eulerAngles = newRotation;

                cannon.transform.Rotate(TiltAngle, 0, 0);

                InitializeCannon(cannon.GetComponent<Cannon>());
            }
        }

        private void InitializeCannon(Cannon cannon)
        {
            cannon.MinShootForce = Settings.GetFloat(BoxSmasherKeys.MinShootForce);
            cannon.MaxShootForce = Settings.GetFloat(BoxSmasherKeys.MaxShootForce);
            cannon.MinDurationBetweenShots = Settings.GetFloat(BoxSmasherKeys.MinDurationBetweenShots);
            cannon.MaxDurationBetweenShots = Settings.GetFloat(BoxSmasherKeys.MaxDurationBetweenShots);
            cannon.MinBoxSize = Settings.GetFloat(BoxSmasherKeys.MinBoxSize);
            cannon.MaxBoxSize = Settings.GetFloat(BoxSmasherKeys.MaxBoxSize);
        }
    }
}