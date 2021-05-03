using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Serialization
{
    public static class ShooterSessionPublisher
    {
        private const string GeneralInformationExtension = ".txt";
        private const string WeaponHitsInformationExtension = ".csv";
        private static readonly string Divider = new string('=', 10);

        private static readonly string SaveDirectory = Application.persistentDataPath;

        public static void Publish(ShooterSession session)
        {
            var filePath = SaveDirectory + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            Debug.Log($"Saving to {filePath}");
            PublishGeneralInformation(filePath, session);
            PublishWeaponHitsInformation(filePath, session);
        }

        private static void PublishGeneralInformation(string filePath, ShooterSession session)
        {
            var fileContents = new List<string>
            {
                $"Total: {session.TotalShotCount}",
                $"Hits: {session.Shots.Count}",
                $"Misses: {session.TotalShotCount - session.Shots.Count}",
                $"Accuracy: {((float) session.Shots.Count / session.TotalShotCount).ToString(CultureInfo.InvariantCulture)}",
                $"{Divider}",
                $"Min distance: {ShooterSettings.MinDistance.ToString(CultureInfo.InvariantCulture)}",
                $"Max distance: {ShooterSettings.MaxDistance.ToString(CultureInfo.InvariantCulture)}",
                $"Min height: {ShooterSettings.MinHeight.ToString(CultureInfo.InvariantCulture)}",
                $"Max height: {ShooterSettings.MaxHeight.ToString(CultureInfo.InvariantCulture)}",
                $"Spawn angle: {ShooterSettings.SpawnAngle.ToString(CultureInfo.InvariantCulture)}",
                $"Spawn count: {ShooterSettings.SpawnCount.ToString(CultureInfo.InvariantCulture)}",
                $"Duration between spawns: {ShooterSettings.DurationBetweenSpawns.ToString(CultureInfo.InvariantCulture)}",
                $"Round duration: {ShooterSettings.RoundDuration.ToString(CultureInfo.InvariantCulture)}",
            };

            File.WriteAllLines(filePath + GeneralInformationExtension, fileContents);
        }

        private static void PublishWeaponHitsInformation(string filePath, ShooterSession session)
        {
            var fileContents = new List<string> {"Distance from target, Distance from hit to center"};
            fileContents.AddRange(session.Shots.Select(shot => $"{shot.DistanceFromTarget.ToString(CultureInfo.InvariantCulture)}," +
                                                               $"{shot.DistanceFromHitToCenter.ToString(CultureInfo.InvariantCulture)}"));

            File.WriteAllLines(filePath + WeaponHitsInformationExtension, fileContents);
        }
    }
}