using System;
using VRQualityTesting.Scripts.Core;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class BoxResult
    {
        public bool WasSmashed { get; }
        public HandSide? HandSide { get; }
        public float Size { get; }
        public int LifetimeInMs { get; }
        public DateTime BirthTimestamp { get; }
        public DateTime DeathTimestamp { get; }

        public BoxResult(bool wasSmashed, HandSide? handSide, float size, int lifetimeInMs, DateTime birthTimestamp, DateTime deathTimestamp)
        {
            WasSmashed = wasSmashed;
            HandSide = handSide;
            Size = size;
            LifetimeInMs = lifetimeInMs;
            BirthTimestamp = birthTimestamp;
            DeathTimestamp = deathTimestamp;
        }
    }
}