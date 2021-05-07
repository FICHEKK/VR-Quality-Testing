using BNG;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float damage = 25;
        [SerializeField] private SessionReporter sessionReporter;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.isTrigger) return;

            var hitPosition = collision.contacts[0].point;
            var normal = collision.contacts[0].normal;
            var damageable = collision.collider.GetComponent<Damageable>();

            if (damageable)
            {
                damageable.DealDamage(damage, hitPosition, normal, true, gameObject, collision.collider.gameObject);
                sessionReporter.OnProjectileCollision(collision);
            }

            Destroy(gameObject);
        }
    }
}