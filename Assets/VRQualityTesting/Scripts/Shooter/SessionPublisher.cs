using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public static class SessionPublisher
    {
        private const string GeneralInformationExtension = ".txt";
        private const string WeaponHitsInformationExtension = ".csv";
        private const string WeaponHitsInformationHeader = "Distance from target, Distance from hit to center, Target life duration (ms)";
        private const string TimestampFormat = "yyyy-MM-dd_HH-mm-ss-fff";

        private static readonly string Divider = string.Empty;
        private static readonly string RootSaveDirectory = Application.persistentDataPath;

        public static void Publish(Session session)
        {
            var filePath = GetSaveFilePath();
            PublishGeneralInformation(filePath, session);
            PublishTargetHitsInformation(filePath, session);
        }

        private static string GetSaveFilePath()
        {
            var studyId = VrQualityTesting.Scripts.MainMenu.Settings.StudyID;
            var participantId = VrQualityTesting.Scripts.MainMenu.Settings.ParticipantID;
            var saveFileDirectory = RootSaveDirectory + "/" + studyId + "/Shooter/" + participantId;

            if (!Directory.Exists(saveFileDirectory))
            {
                Directory.CreateDirectory(saveFileDirectory);
            }

            return saveFileDirectory + "/" + DateTime.Now.ToString(TimestampFormat);
        }

        private static void PublishGeneralInformation(string filePath, Session session)
        {
            var fileContents = new List<string>
            {
                $"Total: {session.TotalShotsFired}",
                $"Hits: {session.Hits.Count}",
                $"Misses: {session.TotalShotsFired - session.Hits.Count}",
                $"Accuracy: {((float) session.Hits.Count / session.TotalShotsFired).ToString(CultureInfo.InvariantCulture)}",
                $"{Divider}",
                $"Min distance: {Settings.MinDistance.ToString(CultureInfo.InvariantCulture)}",
                $"Max distance: {Settings.MaxDistance.ToString(CultureInfo.InvariantCulture)}",
                $"Min height: {Settings.MinHeight.ToString(CultureInfo.InvariantCulture)}",
                $"Max height: {Settings.MaxHeight.ToString(CultureInfo.InvariantCulture)}",
                $"Spawn angle: {Settings.SpawnAngle.ToString(CultureInfo.InvariantCulture)}",
                $"Spawn count: {Settings.SpawnCount.ToString(CultureInfo.InvariantCulture)}",
                $"Duration between spawns: {Settings.DurationBetweenSpawns.ToString(CultureInfo.InvariantCulture)}",
                $"Round duration: {Settings.RoundDuration.ToString(CultureInfo.InvariantCulture)}",
            };

            File.WriteAllLines(filePath + GeneralInformationExtension, fileContents);
        }

        private static void PublishTargetHitsInformation(string filePath, Session session)
        {
            var fileContents = new List<string> {WeaponHitsInformationHeader};
            fileContents.AddRange(session.Hits.Select(shot => $"{shot.DistanceFromTarget.ToString(CultureInfo.InvariantCulture)}," +
                                                               $"{shot.DistanceFromHitToCenter.ToString(CultureInfo.InvariantCulture)}," +
                                                               $"{shot.TargetLifeDurationInMs.ToString(CultureInfo.InvariantCulture)}"));

            File.WriteAllLines(filePath + WeaponHitsInformationExtension, fileContents);
        }
    }
}