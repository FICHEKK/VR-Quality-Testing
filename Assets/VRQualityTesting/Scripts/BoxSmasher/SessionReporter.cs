using System;
using System.Collections.Generic;
using UnityEngine;
using VRQualityTesting.Scripts.Core;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class SessionReporter : MonoBehaviour
    {
        private const string WeaponTag = "Weapon";

        private readonly List<BoxResult> _boxResults = new List<BoxResult>();

        public void OnBoxCollision(Box box, Collision collision)
        {
            var wasSmashed = collision.transform.CompareTag(WeaponTag);
            var handSide = wasSmashed ? collision.gameObject.GetComponent<WeaponHandSide>().HandSide : (HandSide?) null;
            var size = box.transform.localScale.x;
            var lifetimeInMs = (int) (DateTime.Now - box.BirthTimestamp).TotalMilliseconds;

            _boxResults.Add(new BoxResult(wasSmashed, handSide, size, lifetimeInMs));
        }

        public void PublishReport() => SessionPublisher.Publish(new Session(_boxResults));
    }
}