using UnityEngine;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private Transform spawnPoint;

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
                Shoot();
                _timeBetweenShots = Random.Range(MinDurationBetweenShots, MaxDurationBetweenShots);
                _time = 0;
            }
        }

        private void Shoot()
        {
            var obj = Instantiate(objectToShoot);
            obj.transform.position = spawnPoint.position;
            obj.transform.rotation = Random.rotation;

            var size = Random.Range(MinBoxSize, MaxBoxSize);
            obj.transform.localScale = new Vector3(size, size, size);

            var rigidBody = obj.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.up * Random.Range(MinShootForce, MaxShootForce), ForceMode.VelocityChange);
        }
    }
}
