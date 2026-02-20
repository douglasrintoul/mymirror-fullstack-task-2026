using MediatR;

namespace TeamPulse.Application;

public record GetTeamPulseCategoriesQuery() : IRequest<TeamPulseCategoryDTO>;

public class GetTeamPulseCategoriesQueryHandler : IRequestHandler<GetTeamPulseCategoriesQuery, TeamPulseCategoryDTO>
{
    public Task<TeamPulseCategoryDTO> Handle(GetTeamPulseCategoriesQuery request, CancellationToken cancellationToken)
    {
        // TODO: Use the interface to load the categories
        throw new NotImplementedException();
    }
}