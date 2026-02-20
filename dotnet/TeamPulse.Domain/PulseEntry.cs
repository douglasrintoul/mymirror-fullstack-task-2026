namespace TeamPulse.Domain;

public class PulseEntry
{
    public PulseEntry(int score, Guid categoryId, string? comment = null)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Score = new PulseScore(score);
        CategoryId = categoryId;
        Comment = comment;
    }

    public Guid Id { get; }
    public DateTime CreatedAt { get; set;}
    public PulseScore Score { get; set; }
    public Guid CategoryId { get; set; }
    public string? Comment { get; set; }
}