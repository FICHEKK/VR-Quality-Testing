using System.Collections;
using UnityEngine;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private GameObject barrel;
        [SerializeField] private Transform spawnPoint;

        public GameObject Barrel => barrel;

        public float MinShootForce { get; set; }
        public float MaxShootForce { get; set; }
        public float MinDurationBetweenShots { get; set; }
        public float MaxDurationBetweenShots { get; set; }
        public float MinBoxSize { get; set; }
        public float MaxBoxSize { get; set; }

        private float _timeBetweenShots;
        private float _time;

        private void Awake()
        {
            _timeBetweenShots = Random.Range(MinDurationBetweenShots, MaxDurationBetweenShots);
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time > _timeBetweenShots)
            {
                StartCoroutine(Shoot());
                _timeBetweenShots = Random.Range(MinDurationBetweenShots, MaxDurationBetweenShots);
                _time = 0;
            }
        }

        private IEnumerator Shoot()
        {
            yield return StartCoroutine(StretchBarrel());
            ShootObjectFromBarrel();
            yield return StartCoroutine(ReleaseBarrel());
        }

        private IEnumerator StretchBarrel() => AnimateBarrel(true);
        private IEnumerator ReleaseBarrel() => AnimateBarrel(false);

        private IEnumerator AnimateBarrel(bool isStretch)
        {
            const int framesPerAnimation = 10;
            const float scaleDeltaXY = 0.04f;
            const float scaleDeltaZ = 0.03f;
            float factor = isStretch ? 1 : -1;

            for (var i = 0; i < framesPerAnimation; i++)
            {
                var newScale = barrel.transform.localScale;
                newScale.x += scaleDeltaXY * factor;
                newScale.y += scaleDeltaXY * factor;
                newScale.z -= scaleDeltaZ * factor;
                barrel.transform.localScale = newScale;
                yield return null;
            }
        }

        private void ShootObjectFromBarrel()
        {
            var obj = Instantiate(objectToShoot);
            obj.transform.position = spawnPoint.position;
            obj.transform.rotation = Random.rotation;

            var size = Random.Range(MinBoxSize, MaxBoxSize);
            obj.transform.localScale = new Vector3(size, size, size);

            var rigidBody = obj.GetComponent<Rigidbody>();
            rigidBody.AddForce(Barrel.transform.forward * Random.Range(MinShootForce, MaxShootForce), ForceMode.VelocityChange);
        }
    }
}
