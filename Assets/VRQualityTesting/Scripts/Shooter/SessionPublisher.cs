using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using VRQualityTesting.Scripts.MainMenu;
using VRQualityTesting.Scripts.ShooterMenu;
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
            var studyId = Settings.GetString(MainMenuKeys.StudyID);
            var participantId = Settings.GetString(MainMenuKeys.ParticipantID);
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