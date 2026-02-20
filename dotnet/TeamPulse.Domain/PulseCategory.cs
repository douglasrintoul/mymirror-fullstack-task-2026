namespace TeamPulse.Domain;

public class PulseCategory
{
    public Guid Id { get; }
    public string Name { get; set; }

    public PulseCategory(string name)
    {
        Name = name;
    }
}