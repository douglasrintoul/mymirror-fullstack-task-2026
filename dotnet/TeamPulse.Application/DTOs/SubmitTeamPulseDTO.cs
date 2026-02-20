namespace TeamPulse.Application;

public class SubmitTeamPulseDto
{
    public required int Score { get; set; }
    public string? Comment { get; set; }
    public required Guid CategoryId { get; set; }
}