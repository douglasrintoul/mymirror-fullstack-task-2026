namespace TeamPulse.Application;

public class TeamPulseSummaryDTO
{
    public required int Count { get; set; }
    public required decimal AverageScore { get; set; }
    public required Dictionary<int, int> Scores { get; set; }
    public required List<TeamPulseSummaryCategoryDTO> Categories { get; set; }
}