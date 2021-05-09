using System;
using System.IO;
using UnityEngine;

namespace VRQualityTesting.Scripts.Core
{
    public static class SessionPublisher
    {
        private const string GeneralInformationExtension = ".txt";
        private const string DetailedInformationExtension = ".csv";
        private const string TimestampFormat = "yyyy-MM-dd_HH-mm-ss-fff";
        private static readonly char DirectorySeparator = Path.DirectorySeparatorChar;
        private static readonly string RootSaveDirectory = Application.persistentDataPath;

        public static void Publish(ISession session)
        {
            var filePath = GetSaveFilePath(session);
            File.WriteAllLines(filePath + GeneralInformationExtension, session.GeneralInformation);
            File.WriteAllLines(filePath + DetailedInformationExtension, session.DetailedInformation);
        }

        private static string GetSaveFilePath(ISession session)
        {
            var saveFileDirectory = RootSaveDirectory + DirectorySeparator + session.StudyID + DirectorySeparator + session.ParticipantID;

            if (!Directory.Exists(saveFileDirectory))
            {
                Directory.CreateDirectory(saveFileDirectory);
            }

            return saveFileDirectory + DirectorySeparator + session.GameTitle + "_" + DateTime.Now.ToString(TimestampFormat);
        }
    }
}