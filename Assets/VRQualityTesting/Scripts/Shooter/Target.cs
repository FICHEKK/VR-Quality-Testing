using System;
using System.Collections;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Target : MonoBehaviour
    {
        public DateTime BirthTimestamp { get; } = DateTime.Now;

        private void Start() => StartCoroutine(ExpandFromSingularity());

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
