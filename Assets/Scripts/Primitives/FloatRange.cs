using System;

[Serializable]
public class FloatRange
{
    public float LowerBound;
    public float UpperBound;

    private static Random rand = new Random();

    public FloatRange(float lowerBound, float upperBound)
    {
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    public float RandomBetween()
    {
        return (float)rand.NextDouble() * (UpperBound - LowerBound) + UpperBound;
    }


}
