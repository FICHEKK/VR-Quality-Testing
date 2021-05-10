using VRQualityTesting.Scripts.Core;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class BoxResult
    {
        public bool WasSmashed { get; }
        public HandSide? HandSide { get; }
        public float Size { get; }

        public BoxResult(bool wasSmashed, HandSide? handSide, float size)
        {
            WasSmashed = wasSmashed;
            HandSide = handSide;
            Size = size;
        }
    }
}