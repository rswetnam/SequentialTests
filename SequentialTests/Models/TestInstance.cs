namespace SequentialTests.Models;

public class TestInstance
{
    public Guid Id { get; set; } = new Guid();
    public Guid TestId { get; set; } = new Guid();

    public string Name { get; set; } = string.Empty;

    public DateTimeOffset WhenCompleted { get; set; }

}
