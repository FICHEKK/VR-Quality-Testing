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
            var smashedBy = wasSmashed ? collision.gameObject.name : "-";
            var size = box.transform.localScale.x;

            _boxResults.Add(new BoxResult(wasSmashed, smashedBy, size));
        }

        public void PublishReport() => SessionPublisher.Publish(new Session(_boxResults));
    }
}