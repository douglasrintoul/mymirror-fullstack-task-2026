using MediatR;

namespace TeamPulse.Application;

public record GetTeamPulseCategoriesQuery() : IRequest<List<TeamPulseCategoryDTO>>;

public class GetTeamPulseCategoriesQueryHandler : IRequestHandler<GetTeamPulseCategoriesQuery, List<TeamPulseCategoryDTO>>
{
    private readonly IPulseRepository _repository;

    public GetTeamPulseCategoriesQueryHandler(IPulseRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TeamPulseCategoryDTO>> Handle(GetTeamPulseCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllCategoriesAsync();

        return categories.Select(c => new TeamPulseCategoryDTO
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}
