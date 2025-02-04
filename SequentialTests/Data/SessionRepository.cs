using Microsoft.EntityFrameworkCore;
using SequentialTests.Models;
using SequentialTests.Models.Sessions;


namespace SequentialTests.Data;
public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _context;

    public SessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<TestItem[]> GetTestItemsArray(Guid TestId)
    {
        var hipControlTestItems = await _context.TestItems.Where(t => t.TestId == TestId).OrderBy(o => o.SortOrder).ToArrayAsync();
        var model = new TestModel[hipControlTestItems.Length, 4];

        return hipControlTestItems;
    }

    public async Task<TestModel[]> GetHipControlTestModel(Guid TestId)
    {
        var hipControlTestItems = await _context.TestItems.Where(t => t.TestId == TestId).OrderBy(o => o.SortOrder).ToArrayAsync();
        var model = new TestModel[hipControlTestItems.Length];

        for (int i = 0; i < hipControlTestItems.Length; i++)
        {
            model[i] = new TestModel
            {
                Questions = new string[] { hipControlTestItems[i].Question },
                QuestionIds = new Guid[] { hipControlTestItems[i].Id },
                BoolAnswers = new bool[] { hipControlTestItems[i].BoolAnswer },
                IntAnswers = new int[] { hipControlTestItems[i].IntAnswer },
                IsTrueFalseAnswer = new bool[] { hipControlTestItems[i].IsTrueFalseAnswer }
            };
        }

        return model;
    }


    public async Task<TestInstance> GetTestInstance(Guid TestId)
    {
        TestInstance? test = await _context.TestInstances.FindAsync(TestId);
        return test;
    }

    public async Task<Test> GetTest(Guid TestId)
    {
        Test? test = await _context.Tests.FindAsync(TestId);
        return test;
    }

    public async Task<List<TestItem>> GetTestItems(Guid TestId)
    {
        var testItems = await _context.TestItems.Where(t => t.TestId == TestId).OrderBy(o => o.SortOrder).ToListAsync();

        return testItems;
    }

    Task SubmitTestItems(TestItem[] testItemsArray)
    {
        throw new NotImplementedException();
    }

    Task ISessionRepository.SubmitTestItems(TestItem[] testItemsArray)
    {
        throw new NotImplementedException();
    }
    public async Task SetTestResultsBruteForce(TestModelBruteForce testModel, Guid testInstanceId)
    {
        var TestId = new Guid("839C1D11-5DC5-48FC-B203-7E2F1566D861");
        var questionId1 = new Guid("D1D1864D-085F-4E7E-B964-7A99CB7E359B");
        var questionId2 = new Guid("0910B6FB-C959-4D7E-8AC8-2503BDEC6BD0");
        var questionId3 = new Guid("E52474DC-3FBB-4F0E-A1C4-F4671DFE05B1");
        var questionId4 = new Guid("6C520724-C6B3-4B9E-8A9C-4B4DBADB9D60");
        var questionId5 = new Guid("35244E23-9514-45A4-9DEC-F9615D39AFAC");
        var questionId6 = new Guid("2337B9E0-DB72-40C9-95FB-3A324EFD5252");

        TestResult testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId1,
            IntAnswer1 = testModel.IntAnswer1,
            BoolAnswer1 = testModel.BoolAnswer1,
        };

        await _context.TestResults.AddAsync(testResult);

        testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId2,
            IntAnswer1 = testModel.IntAnswer2,
            BoolAnswer1 = testModel.BoolAnswer2,
        };

        await _context.TestResults.AddAsync(testResult);

        testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId3,
            IntAnswer1 = testModel.IntAnswer3,
            BoolAnswer1 = testModel.BoolAnswer3,
        };

        await _context.TestResults.AddAsync(testResult);

        testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId4,
            IntAnswer1 = testModel.IntAnswer4,
            BoolAnswer1 = testModel.BoolAnswer4,
        };

        await _context.TestResults.AddAsync(testResult);

        testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId5,
            IntAnswer1 = testModel.IntAnswer5,
            BoolAnswer1 = testModel.BoolAnswer5,
        };

        await _context.TestResults.AddAsync(testResult);

        testResult = new TestResult
        {
            Id = Guid.NewGuid(),
            TestInstanceId = testInstanceId,
            TestId = TestId,
            QuestionId = questionId6,
            IntAnswer1 = testModel.IntAnswer6,
            BoolAnswer1 = testModel.BoolAnswer6,
        };

        await _context.TestResults.AddAsync(testResult);

        await _context.SaveChangesAsync();




    }

    public async Task<List<TestResultDto>> GetTestResults(Guid TestId, Guid TestInstanceId)
    {
        var testResultsList = await (from testItem in _context.TestItems
                                     join testResult in _context.TestResults
                                     on testItem.Id equals testResult.QuestionId
                                     where testItem.TestId == TestId && testResult.TestInstanceId == TestInstanceId
                                     select new TestResultDto
                                     {
                                         Id = testResult.Id,
                                         IsTrueFalseAnswer = testItem.IsTrueFalseAnswer,
                                         Task = testItem.Task,
                                         SortOrder = testItem.SortOrder,
                                         Question = testItem.Question,
                                         BoolAnswer1 = testResult.BoolAnswer1,
                                         IntAnswer1 = testResult.IntAnswer1
                                     })
                                     .OrderBy(so => so.SortOrder)
                                     .ToListAsync();

        return testResultsList;
    }

    public Task SetTestResults(TestModel testModel, Guid TestInstanceId, Guid TestId)
    {
        for (int i = 0; i < testModel.Questions.Length; i++)
        {
            //TestResult testResult = new TestResult
            //{
            //    Id = Guid.NewGuid(),
            //    TestInstanceId = TestInstanceId,
            //    TestId = TestId,
            //    QuestionId = item,
            //    IntAnswer1 = testModel.IntAnswers[Array.IndexOf(testModel.QuestionIds, item)],
            //    BoolAnswer1 = testModel.BoolAnswers[Array.IndexOf(testModel.QuestionIds, item)],
            //};
            TestResult testResult = new TestResult();
            testResult.Id = Guid.NewGuid();
            testResult.TestInstanceId = TestInstanceId;
            testResult.TestId = TestId;
            testResult.QuestionId = testModel.QuestionIds[i];
            testResult.IntAnswer1 = testModel.IntAnswers[i];
            testResult.BoolAnswer1 = testModel.BoolAnswers[i];
            _context.TestResults.Add(testResult);
        }
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<TestInstance> CreateResultTestInstance(Test test)
    {
        TestInstance testInstance = new TestInstance
        {
            Id = Guid.NewGuid(),
            TestId = test.Id,
            Name = test.Name,
            WhenCompleted = DateTimeOffset.Now
        };

        _context.TestInstances.Add(testInstance);

        _context.SaveChanges();

        return Task.FromResult(testInstance);
    }

    public async Task<Test> GetTestById(Guid Id)
    {
        return await _context.Tests.FindAsync(Id);
    }

    public async Task<TestModel> PopulateTestModel(Guid TestId)
    {
        var testItems = await _context.TestItems.Where(t => t.TestId == TestId).OrderBy(o => o.SortOrder).ToArrayAsync();
        var testItemsList = await _context.TestItems.OrderBy(o => o.SortOrder).ToListAsync();

        TestModel testModel = new TestModel();

        testModel.Questions = testItemsList.Select(t => t.Question).ToArray();
        testModel.QuestionIds = testItemsList.Select(t => t.Id).ToArray();
        testModel.BoolAnswers = testItemsList.Select(t => t.BoolAnswer).ToArray();
        testModel.IntAnswers = testItemsList.Select(t => t.IntAnswer).ToArray();
        testModel.IsTrueFalseAnswer = testItemsList.Select(t => t.IsTrueFalseAnswer).ToArray();
        testModel.SortOrders = testItemsList.Select(t => t.SortOrder).ToArray();
        testModel.Tasks = testItemsList.Select(t => t.Task).ToArray();
        return testModel;
    }
}
