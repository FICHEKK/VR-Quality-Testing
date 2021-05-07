using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.Shooter
{
    public static class SessionPublisher
    {
        private const string GeneralInformationExtension = ".txt";
        private const string WeaponHitsInformationExtension = ".csv";
        private const string WeaponHitsInformationHeader = "Dst to target, Dst to center, Lifetime, Size, Velocity, Offset";
        private const string TimestampFormat = "yyyy-MM-dd_HH-mm-ss-fff";
        private static readonly string RootSaveDirectory = Application.persistentDataPath;

        public static void Publish(Session session)
        {
            var filePath = GetSaveFilePath();
            PublishGeneralInformation(filePath, session);
            PublishTargetHitsInformation(filePath, session);
        }

        private static string GetSaveFilePath()
        {
            var studyId = Settings.GetString(SettingsKeys.MainMenu.StudyID);
            var participantId = Settings.GetString(SettingsKeys.MainMenu.ParticipantID);
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
                "# Round results",
                $"Total shots fired: {session.TotalShotsFired}",
                $"Hits: {session.Hits.Count}",
                $"Misses: {session.TotalShotsFired - session.Hits.Count}",
                $"Accuracy: {((float) session.Hits.Count / session.TotalShotsFired).ToString(CultureInfo.InvariantCulture)}",
                $"Duration: {Settings.GetFloat(SettingsKeys.Shooter.RoundDuration).ToString(CultureInfo.InvariantCulture)}",

                $"{Environment.NewLine}# Target spawner settings",
                $"Min distance: {Settings.GetFloat(SettingsKeys.Shooter.MinDistance).ToString(CultureInfo.InvariantCulture)}",
                $"Max distance: {Settings.GetFloat(SettingsKeys.Shooter.MaxDistance).ToString(CultureInfo.InvariantCulture)}",
                $"Min height: {Settings.GetFloat(SettingsKeys.Shooter.MinHeight).ToString(CultureInfo.InvariantCulture)}",
                $"Max height: {Settings.GetFloat(SettingsKeys.Shooter.MaxHeight).ToString(CultureInfo.InvariantCulture)}",
                $"Spawn angle: {Settings.GetFloat(SettingsKeys.Shooter.SpawnAngle).ToString(CultureInfo.InvariantCulture)}",
                $"Spawn count: {Settings.GetInt(SettingsKeys.Shooter.SpawnCount).ToString(CultureInfo.InvariantCulture)}",
                $"Duration between spawns: {Settings.GetFloat(SettingsKeys.Shooter.DurationBetweenSpawns).ToString(CultureInfo.InvariantCulture)}",

                $"{Environment.NewLine}# Target settings",
                $"Min size: {Settings.GetFloat(SettingsKeys.Shooter.MinSize).ToString(CultureInfo.InvariantCulture)}",
                $"Max size: {Settings.GetFloat(SettingsKeys.Shooter.MaxSize).ToString(CultureInfo.InvariantCulture)}",
                $"Moving probability: {Settings.GetFloat(SettingsKeys.Shooter.MovingProbability).ToString(CultureInfo.InvariantCulture)}",
                $"Min velocity: {Settings.GetFloat(SettingsKeys.Shooter.MinVelocity).ToString(CultureInfo.InvariantCulture)}",
                $"Max velocity: {Settings.GetFloat(SettingsKeys.Shooter.MaxVelocity).ToString(CultureInfo.InvariantCulture)}",
                $"Min offset: {Settings.GetFloat(SettingsKeys.Shooter.MinOffset).ToString(CultureInfo.InvariantCulture)}",
                $"Max offset: {Settings.GetFloat(SettingsKeys.Shooter.MaxOffset).ToString(CultureInfo.InvariantCulture)}",

                $"{Environment.NewLine}# Weapon settings",
                $"Type: {(WeaponType) Settings.GetInt(SettingsKeys.Shooter.WeaponType)}",
                $"Use laser: {Settings.GetBool(SettingsKeys.Shooter.UseLaser)}",
                $"Show bullet trajectory: {Settings.GetBool(SettingsKeys.Shooter.ShowBulletTrajectory)}",
                $"Show muzzle flash: {Settings.GetBool(SettingsKeys.Shooter.ShowMuzzleFlash)}",
            };

            File.WriteAllLines(filePath + GeneralInformationExtension, fileContents);
        }

        private static void PublishTargetHitsInformation(string filePath, Session session)
        {
            var fileContents = new List<string> {WeaponHitsInformationHeader};
            fileContents.AddRange(session.Hits.Select(shot => $"{shot.DistanceFromTarget.ToString(CultureInfo.InvariantCulture)}, " +
                                                               $"{shot.DistanceFromHitToCenter.ToString(CultureInfo.InvariantCulture)}, " +
                                                               $"{shot.TargetLifeDurationInMs.ToString(CultureInfo.InvariantCulture)}, " +
                                                               $"{shot.TargetSize.ToString(CultureInfo.InvariantCulture)}, " +
                                                               $"{shot.TargetVelocity.ToString(CultureInfo.InvariantCulture)}, " +
                                                               $"{shot.TargetOffset.ToString(CultureInfo.InvariantCulture)}"));

            File.WriteAllLines(filePath + WeaponHitsInformationExtension, fileContents);
        }
    }
}