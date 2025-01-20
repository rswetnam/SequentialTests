namespace SequentialTests.Models;

public class TestModel
{
    public int[] SortOrders { get; set; } = new int[6];
    public string[] Questions { get; set; } = new string[6];
    public string[] Tasks { get; set; } = new string[6];
    public Guid[] QuestionIds { get; set; } = new Guid[6];
    public bool[] BoolAnswers { get; set; } = new bool[6];
    public int[] IntAnswers { get; set; } = new int[6];
    public bool[] IsTrueFalseAnswer { get; set; } = new bool[6];
}
