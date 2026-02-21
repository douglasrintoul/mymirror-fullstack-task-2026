using TeamPulse.Domain;

namespace TeamPulse.Tests;

[TestFixture]
public class PulseScoreTests
{

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void ValidScoreShouldCreate(int value)
    {
        var score = new PulseScore(value);
        Assert.That(score.Value, Is.EqualTo(value));
    }

    [TestCase(-1)]
    [TestCase(6)]
    [TestCase(0)]
    [TestCase(38462876)]
    [TestCase(-2837265)]
    public void InvalidScoreShouldThrowArgumentException(int value)
    {
        Assert.That(() => new PulseScore(value), Throws.TypeOf<ArgumentException>());
    }
}
