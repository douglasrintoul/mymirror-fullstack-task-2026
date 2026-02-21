namespace TeamPulse.Application;

public class SubmitTeamPulseResponseDTO
{
    public required bool Success { get; set; }
    public Guid? Id { get; set; }
    public string? Error { get; set; }
}