using System;
using System.Collections.Generic;
using VRQualityTesting.Scripts.Core;
using VRQualityTesting.Scripts.MainMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.PickAndPlace
{
    public class Session : ISession
    {
        public string StudyID => Settings.GetString(MainMenuKeys.StudyID);
        public string ParticipantID => Settings.GetString(MainMenuKeys.ParticipantID);
        public GameTitle GameTitle => GameTitle.PickAndPlace;

        public List<string> GeneralInformation =>
            throw new NotImplementedException("Return a list of lines that represent general round results.");

        public List<string> DetailedInformation =>
            throw new NotImplementedException("Return a list of lines that represent detailed round results.");
    }
}
