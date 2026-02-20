using System.ComponentModel.DataAnnotations;

namespace TeamPulse.Domain;

public class PulseEntry
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set;}
    public PulseScore Score { get; set; }
    public Guid CategoryId { get; set; }
    public string? Comment { get; set; }
    public PulseEntry(PulseScore score, Guid categoryId, string? comment = null)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Score = score;
        CategoryId = categoryId;
        Comment = comment;
    }
}