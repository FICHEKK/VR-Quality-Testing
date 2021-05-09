using System.Collections.Generic;

namespace VRQualityTesting.Scripts.Core
{
    public interface ISession
    {
        public string StudyID { get; }
        public string ParticipantID { get; }
        public GameTitle GameTitle { get; }

        public List<string> GeneralInformation { get; }
        public List<string> DetailedInformation { get; }
    }
}