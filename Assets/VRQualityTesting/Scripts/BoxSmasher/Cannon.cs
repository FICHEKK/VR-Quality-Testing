using UnityEngine;

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

    private float timeBetweenShots;
    private float time;

    private void Awake()
    {
        timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timeBetweenShots)
        {
            Shoot();
            timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            time = 0;
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
