using MediatR;
using TeamPulse.Domain;

namespace TeamPulse.Application;

public class SubmitTeamPulseCommand : IRequest<SubmitTeamPulseResponseDTO>
{
    public required SubmitTeamPulseDTO Request { get; set; }
}

public class SubmitTeamPulseCommandHandler : IRequestHandler<SubmitTeamPulseCommand, SubmitTeamPulseResponseDTO>
{
    private readonly IPulseRepository _repository;

    public SubmitTeamPulseCommandHandler(IPulseRepository repository)
    {
        _repository = repository;
    }

    public async Task<SubmitTeamPulseResponseDTO> Handle(SubmitTeamPulseCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Request;

        if (dto.Comment != null && dto.Comment.Length > PulseEntry.MaxCommentLength)
        {
            return new SubmitTeamPulseResponseDTO { Success = false, Error = $"Comment must not exceed {PulseEntry.MaxCommentLength} characters" };
        }

        var categoryExists = await _repository.CategoryExistsAsync(dto.CategoryId);
        if (!categoryExists)
        {
            return new SubmitTeamPulseResponseDTO { Success = false, Error = "Category doesn't exist" };
        }

        PulseScore? score;
        try
        {
            score = new PulseScore(dto.Score);
        } catch (ArgumentException)
        {
            return new SubmitTeamPulseResponseDTO { Success = false, Error = "Invalid score" };
        }
 
        var entry = new PulseEntry(score, dto.CategoryId, dto.Comment);
        await _repository.AddEntryAsync(entry);

        return new SubmitTeamPulseResponseDTO { Success = true, Id = entry.Id };
    }
}
