using SequentialTests.Models;

namespace SequentialTests.Data;
public interface ISessionRepository
{

    Task<TestInstance> GetTestInstance(Guid TestId);

    Task<List<TestItem>> GetTestItems(Guid TestId);

    Task<TestItem[]> GetTestItemsArray(Guid TestId);

    Task SubmitTestItems(TestItem[]? testItemsArray);

    Task<TestModel> PopulateTestModel(Guid TestId);

    Task SetTestResults(TestModelBruteForce testModel, Guid sessionId);

    Task<List<TestResultDto>> GetTestResults(Guid TestId, Guid SessionId);

    Task<TestInstance> CreateTestInstance(Test test);

    Task<Test> GetTestById(Guid Id);
}


