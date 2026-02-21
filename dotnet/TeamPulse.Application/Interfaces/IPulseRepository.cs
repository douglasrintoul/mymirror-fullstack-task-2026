using TeamPulse.Domain;

namespace TeamPulse.Application;

public interface IPulseRepository
{
    Task AddEntryAsync(PulseEntry entry);
    Task<List<PulseEntry>> GetAllEntriesAsync();
    Task<List<PulseCategory>> GetAllCategoriesAsync();
    Task<bool> CategoryExistsAsync(Guid categoryId);
}