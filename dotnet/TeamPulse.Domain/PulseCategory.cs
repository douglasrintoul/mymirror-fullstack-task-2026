using System.ComponentModel.DataAnnotations;

namespace TeamPulse.Domain;

public class PulseCategory
{
    [Key]
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public PulseCategory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public PulseCategory(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}