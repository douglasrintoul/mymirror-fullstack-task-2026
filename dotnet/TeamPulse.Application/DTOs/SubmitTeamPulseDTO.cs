using System.ComponentModel.DataAnnotations;
using TeamPulse.Domain;

namespace TeamPulse.Application;

public class SubmitTeamPulseDto
{
    [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
    public required int Score { get; set; }
    [MaxLength(PulseEntry.MaxCommentLength, ErrorMessage = "Comment must be 500 characters or less")]
    public string? Comment { get; set; }
    public required Guid CategoryId { get; set; }
}