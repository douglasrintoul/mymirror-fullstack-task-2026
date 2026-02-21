using Microsoft.EntityFrameworkCore;
using TeamPulse.Application;
using TeamPulse.Domain;

namespace TeamPulse.Infrastructure;

public class PulseRepository : IPulseRepository
{
    private readonly TeamPulseDbContext _context;

    public PulseRepository(TeamPulseDbContext context)
    {
        _context = context;
    }

    public async Task AddEntryAsync(PulseEntry entry)
    {
        _context.PulseEntries.Add(entry);
        await _context.SaveChangesAsync();
    }
    public async Task<List<PulseEntry>> GetAllEntriesAsync()
    {
        return await _context.PulseEntries.ToListAsync();
    }

    public async Task<bool> CategoryExistsAsync(Guid categoryId)
    {
        return await _context.PulseCategories.AnyAsync<PulseCategory>(x => x.Id == categoryId);
    }


    public async Task<List<PulseCategory>> GetAllCategoriesAsync()
    {
        return await _context.PulseCategories.ToListAsync();
    }
}