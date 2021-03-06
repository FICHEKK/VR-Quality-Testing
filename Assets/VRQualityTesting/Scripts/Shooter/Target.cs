using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Target : MonoBehaviour
    {
        private const float DirectionChangeCooldownDuration = 0.1f;

        public DateTime BirthTimestamp { get; } = DateTime.Now;
        public float Velocity { get; set; }
        public float Offset { get; set; }

        private Vector3 _initialPosition;
        private Vector2 _moveDirection;
        private float _directionChangeCooldown;

        private void Awake()
        {
            _initialPosition = transform.position;
            _moveDirection = Random.insideUnitCircle.normalized;
        }

        private void Start() => StartCoroutine(ExpandFromSingularity());

        private void Update()
        {
            transform.position += transform.right * (_moveDirection.x * Velocity * Time.deltaTime);
            transform.position += transform.up * (_moveDirection.y * Velocity * Time.deltaTime);

            _directionChangeCooldown -= Time.deltaTime;

            if (_directionChangeCooldown <= 0 && (transform.position - _initialPosition).magnitude > Offset)
            {
                _moveDirection *= -1;
                _directionChangeCooldown = DirectionChangeCooldownDuration;
            }
        }

        private IEnumerator ExpandFromSingularity()
        {
            var startScale = Vector3.zero;
            var finishScale = transform.localScale;

            for (var percentage = 0f; percentage <= 1f; percentage += 0.01f)
            {
                transform.localScale = Vector3.Lerp(startScale, finishScale, percentage);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
