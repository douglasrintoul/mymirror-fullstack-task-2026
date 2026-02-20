using MediatR;

namespace TeamPulse.Application;

public record GetTeamPulseSummaryQuery() : IRequest<TeamPulseSummaryDTO>;

public class GetTeamPulseSummaryQueryHandler : IRequestHandler<GetTeamPulseSummaryQuery, TeamPulseSummaryDTO>
{
    public Task<TeamPulseSummaryDTO> Handle(GetTeamPulseSummaryQuery request, CancellationToken cancellationToken)
    {
        // TODO: Use the interface to load in the summary
        throw new NotImplementedException();
    }
}