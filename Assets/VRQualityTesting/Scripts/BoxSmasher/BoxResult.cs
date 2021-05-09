namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class BoxResult
    {
        public bool WasSmashed { get; }
        public string SmashedBy { get; }
        public float Size { get; }

        public BoxResult(bool wasSmashed, string smashedBy, float size)
        {
            WasSmashed = wasSmashed;
            SmashedBy = smashedBy;
            Size = size;
        }
    }
}