using MediatR;

namespace TeamPulse.Application;

public record GetTeamPulseSummaryQuery() : IRequest<TeamPulseSummaryDTO>;

public class GetTeamPulseSummaryQueryHandler : IRequestHandler<GetTeamPulseSummaryQuery, TeamPulseSummaryDTO>
{
    private readonly IPulseRepository _repository;

    public GetTeamPulseSummaryQueryHandler(IPulseRepository repository)
    {
        _repository = repository;
    }

    public async Task<TeamPulseSummaryDTO> Handle(GetTeamPulseSummaryQuery request, CancellationToken cancellationToken)
    {
        // NOTE: This loads all entries into memory. Depending on architecture and load, this might need to be refactored
        // in future to do the aggregation on the database side. For now though, I've chosen to do this in-memory
        // for development speed and because this is very unlikely to be a performance issue given the application.
        var entries = await _repository.GetAllEntriesAsync();
        var categories = await _repository.GetAllCategoriesAsync();

        var count = entries.Count;
        var averageScore = count > 0
            ? Math.Round((decimal)entries.Average(e => e.Score.Value), 2)
            : 0m;

        // Using Enumerable.Range to display scores with zero-count. If we want to only return scores that appear
        // in the set of entries, we would remove this.
        var scores = Enumerable.Range(1, 5).ToDictionary(
            score => score,
            score => entries.Count(e => e.Score.Value == score)
        );

        var categoryDtos = categories.Select((cat, index) => new TeamPulseSummaryCategoryDTO
        {
            Id = index + 1,
            Name = cat.Name,
            Count = entries.Count(e => e.CategoryId == cat.Id)
        }).ToList();

        return new TeamPulseSummaryDTO
        {
            Count = count,
            AverageScore = averageScore,
            Scores = scores,
            Categories = categoryDtos
        };
    }
}
