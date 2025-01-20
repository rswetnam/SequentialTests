using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialTests.Models.Sessions;
public class TestResult
{
    public Guid Id { get; set; }
    public Guid TestInstanceId { get; set; }
    public Guid TestId { get; set; }
    public Guid QuestionId { get; set; }
    public int SortOrder { get; set; }  
    public bool BoolAnswer1 { get; set; } = false;
    public int IntAnswer1 { get; set; } = 0;
}
