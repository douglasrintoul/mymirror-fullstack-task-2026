using MediatR;

namespace TeamPulse.Application;

public class SubmitTeamPulseCommand : IRequest<SubmitTeamPulseResponseDTO>
{
    public required SubmitTeamPulseDto Request { get; set; }
}

public class CreateTaskSubmitTeamPulseCommandHandler : IRequestHandler<SubmitTeamPulseCommand, SubmitTeamPulseResponseDTO>
{
    public Task<SubmitTeamPulseResponseDTO> Handle(SubmitTeamPulseCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}