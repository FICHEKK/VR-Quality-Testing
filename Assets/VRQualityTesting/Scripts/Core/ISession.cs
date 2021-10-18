using System.Collections.Generic;

namespace VRQualityTesting.Scripts.Core
{
    /// <summary>
    /// Represents a single game session (round) which generates results once finished.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// What exactly is being tested?
        /// </summary>
        public string StudyID { get; }

        /// <summary>
        /// Who are we testing?
        /// </summary>
        public string ParticipantID { get; }

        /// <summary>
        /// Which game do we test on?
        /// </summary>
        public GameTitle GameTitle { get; }

        /// <summary>
        /// Returns summary of the session without going into small details.
        /// </summary>
        public List<string> GeneralInformation { get; }

        /// <summary>
        /// Returns details of the session which are used for a more thorough analysis.
        /// </summary>
        public List<string> DetailedInformation { get; }
    }
}
