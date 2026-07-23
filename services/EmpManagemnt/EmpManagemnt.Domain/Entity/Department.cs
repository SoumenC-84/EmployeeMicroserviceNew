public class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Department(int id, string? name, string? description)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be greater than zero.", nameof(id));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }

        Id = id;
        Name = name;
        Description = description;
    }
}