using System.Collections.Generic;
using DefaultNamespace;
using Serialization;
using UnityEngine;

public class SessionReporter : MonoBehaviour
{
    private const string SuccessfulHitTag = "Target";

    private readonly List<WeaponShot> _weaponShots = new List<WeaponShot>();
    private int _totalHits;

    public void OnWeaponShot() => _totalHits++;

    public void OnWeaponHit(RaycastHit hit)
    {
        if (!hit.transform.CompareTag(SuccessfulHitTag)) return;

        var distanceFromTarget = hit.distance;
        Debug.Log($"Target was hit from {distanceFromTarget}");

        var distanceFromHitToCenter = (hit.point - hit.transform.position).magnitude;
        Debug.Log($"Distance to center was {distanceFromHitToCenter}");

        _weaponShots.Add(new WeaponShot(distanceFromTarget, distanceFromHitToCenter));
    }

    public void OnTimerRunOut()
    {
        ShooterSessionPublisher.Publish(new ShooterSession(14, _totalHits, _weaponShots));
    }
}
