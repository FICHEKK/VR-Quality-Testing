using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VRQualityTesting.Scripts.Core;
using VRQualityTesting.Scripts.MainMenu;
using VRQualityTesting.Scripts.ShooterMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Session : ISession
    {
        private const string WeaponHitsInformationHeader = "Distance to target, Distance to center, Lifetime, Size, Velocity, Offset, Hand side";

        public string StudyID => Settings.GetString(MainMenuKeys.StudyID);
        public string ParticipantID => Settings.GetString(MainMenuKeys.ParticipantID);
        public GameTitle GameTitle => GameTitle.Shooter;

        private readonly int _totalShotsFired;
        private readonly List<TargetHit> _hits;

        public Session(int totalShotsFired, List<TargetHit> hits)
        {
            _totalShotsFired = totalShotsFired;
            _hits = hits;
        }

        public List<string> GeneralInformation
        {
            get
            {
                var hits = _hits.Count;
                var hitsByRightHand = _hits.Count(hit => hit.HandSide == HandSide.Right);
                var hitsByLeftHand = hits - hitsByRightHand;

                return new List<string>
                {
                    "# Round results",
                    $"Total shots fired: {_totalShotsFired}",
                    $"Hits: {hits}",
                    $"Hits by right hand: {hitsByRightHand}",
                    $"Hits by left hand: {hitsByLeftHand}",
                    $"Misses: {_totalShotsFired - hits}",
                    $"Accuracy: {((float) hits / _totalShotsFired).ToString(CultureInfo.InvariantCulture)}",
                    $"Duration: {Settings.GetFloat(ShooterKeys.RoundDuration).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Target spawner settings",
                    $"Min distance: {Settings.GetFloat(ShooterKeys.MinDistance).ToString(CultureInfo.InvariantCulture)}",
                    $"Max distance: {Settings.GetFloat(ShooterKeys.MaxDistance).ToString(CultureInfo.InvariantCulture)}",
                    $"Min height: {Settings.GetFloat(ShooterKeys.MinHeight).ToString(CultureInfo.InvariantCulture)}",
                    $"Max height: {Settings.GetFloat(ShooterKeys.MaxHeight).ToString(CultureInfo.InvariantCulture)}",
                    $"Spawn angle: {Settings.GetFloat(ShooterKeys.SpawnAngle).ToString(CultureInfo.InvariantCulture)}",
                    $"Spawn count: {Settings.GetInt(ShooterKeys.SpawnCount).ToString(CultureInfo.InvariantCulture)}",
                    $"Duration between spawns: {Settings.GetFloat(ShooterKeys.DurationBetweenSpawns).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Target settings",
                    $"Min size: {Settings.GetFloat(ShooterKeys.MinSize).ToString(CultureInfo.InvariantCulture)}",
                    $"Max size: {Settings.GetFloat(ShooterKeys.MaxSize).ToString(CultureInfo.InvariantCulture)}",
                    $"Moving probability: {Settings.GetFloat(ShooterKeys.MovingProbability).ToString(CultureInfo.InvariantCulture)}",
                    $"Min velocity: {Settings.GetFloat(ShooterKeys.MinVelocity).ToString(CultureInfo.InvariantCulture)}",
                    $"Max velocity: {Settings.GetFloat(ShooterKeys.MaxVelocity).ToString(CultureInfo.InvariantCulture)}",
                    $"Min offset: {Settings.GetFloat(ShooterKeys.MinOffset).ToString(CultureInfo.InvariantCulture)}",
                    $"Max offset: {Settings.GetFloat(ShooterKeys.MaxOffset).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Weapon settings",
                    $"Type: {(WeaponType) Settings.GetInt(ShooterKeys.WeaponType)}",
                    $"Use laser: {Settings.GetBool(ShooterKeys.UseLaser)}",
                    $"Show bullet trajectory: {Settings.GetBool(ShooterKeys.ShowBulletTrajectory)}",
                    $"Show muzzle flash: {Settings.GetBool(ShooterKeys.ShowMuzzleFlash)}",
                    $"Bullet trajectory time: {Settings.GetFloat(ShooterKeys.BulletTrajectoryTime).ToString(CultureInfo.InvariantCulture)}",
                };
            }
        }

        public List<string> DetailedInformation
        {
            get
            {
                var detailedInformation = new List<string> {WeaponHitsInformationHeader};
                detailedInformation.AddRange(_hits.Select(shot => $"{shot.DistanceFromTarget.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.DistanceFromHitToCenter.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.TargetLifeDurationInMs.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.TargetSize.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.TargetVelocity.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.TargetOffset.ToString(CultureInfo.InvariantCulture)}, " +
                                                          $"{shot.HandSide}"));
                return detailedInformation;
            }
        }
    }
}