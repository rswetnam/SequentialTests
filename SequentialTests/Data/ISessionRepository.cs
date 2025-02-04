using SequentialTests.Models;

namespace SequentialTests.Data;
public interface ISessionRepository
{

    Task<TestInstance> GetTestInstance(Guid TestId);

    Task<List<TestItem>> GetTestItems(Guid TestId);

    Task<TestItem[]> GetTestItemsArray(Guid TestId);

    Task SubmitTestItems(TestItem[]? testItemsArray);

    Task<TestModel> PopulateTestModel(Guid TestId);

    Task SetTestResultsBruteForce(TestModelBruteForce testModel, Guid sessionId);

    Task SetTestResults(TestModel testModel, Guid TestInstanceId, Guid TestId);

    Task<List<TestResultDto>> GetTestResults(Guid TestId, Guid SessionId);

    Task<TestInstance> CreateResultTestInstance(Test test);

    Task<Test> GetTestById(Guid Id);
}


