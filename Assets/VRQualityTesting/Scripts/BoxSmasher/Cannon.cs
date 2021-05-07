using UnityEngine;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private float minForceMultiplier;
        [SerializeField] private float maxForceMultiplier;
        [SerializeField] private float minTimeBetweenShots;
        [SerializeField] private float maxTimeBetweenShots;
        [SerializeField] private float minBoxSize;
        [SerializeField] private float maxBoxSize;

        private float _timeBetweenShots;
        private float _time;

        private void Awake()
        {
            _timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

        void Update()
        {
            _time += Time.deltaTime;

            if (_time > _timeBetweenShots)
            {
                Shoot();
                _timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
                _time = 0;
            }
        }

        private void Shoot()
        {
            var obj = Instantiate(objectToShoot);
            obj.transform.position = spawnPoint.position;
            obj.transform.rotation = Random.rotation;

            var size = Random.Range(minBoxSize, maxBoxSize);
            obj.transform.localScale = new Vector3(size, size, size);

            var rigidBody = obj.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.up * Random.Range(minForceMultiplier, maxForceMultiplier), ForceMode.VelocityChange);
        }
    }
}
