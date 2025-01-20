namespace SequentialTests.Models;
public class TestResultDto
{
    public Guid Id { get; set; }
    public int SortOrder { get; set; }

    public string? Task { get; set; }   
    public required string Question { get; set; }

    public bool IsTrueFalseAnswer { get; set; } = false; 
    public bool BoolAnswer1 { get; set; } = false;
    public int IntAnswer1 { get; set; } = 0;
}
