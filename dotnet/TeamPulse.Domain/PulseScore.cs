namespace TeamPulse.Domain;

public class PulseScore
{
    public int Value { get; }

    public PulseScore(int value)
    {
        if (value < 1 || value > 5)
            throw new ArgumentException("PulseScore must be between 1 and 5.");
        Value = value;
    }
}
