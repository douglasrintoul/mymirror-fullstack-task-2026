using System.ComponentModel.DataAnnotations;

namespace TeamPulse.Domain;

public class PulseEntry
{
    public const int MaxCommentLength = 500;

    [Key]
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set;}
    public PulseScore Score { get; private set; }
    [Required]
    public Guid CategoryId { get; private set; }
    [MaxLength(MaxCommentLength)]
    public string? Comment { get; private set; }
    public PulseEntry(PulseScore score, Guid categoryId, string? comment = null)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Score = score;
        CategoryId = categoryId;
        Comment = comment;
    }
}