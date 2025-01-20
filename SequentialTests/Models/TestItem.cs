using System.ComponentModel.DataAnnotations;

namespace SequentialTests.Models;

public class TestItem
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    [MaxLength(150)]
    public required string Question { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Task { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsTrueFalseAnswer { get; set; } = false;

    public bool BoolAnswer { get; set; } = false;

    public int IntAnswer { get; set; } = 0;
}
