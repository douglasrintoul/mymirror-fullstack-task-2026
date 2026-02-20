using System.ComponentModel.DataAnnotations;

namespace TeamPulse.Domain;

public class PulseCategory
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public PulseCategory(string name)
    {
        Id = new Guid();
        Name = name;
    }
}