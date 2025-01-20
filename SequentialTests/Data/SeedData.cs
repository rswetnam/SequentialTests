using SequentialTests.Models;

namespace SequentialTests.Data;

public class SeedData
{
    public static async Task SeedDomain(IServiceProvider services)
    {
        var testId = new Guid("839C1D11-5DC5-48FC-B203-7E2F1566D861");
        var neckTestId = new Guid("839C1D11-5DC5-48FC-B203-7E2F1566D862");  
        var hipProgramId = new Guid("98379929-29EF-425C-A709-6F1A106EF9D1");
        var neckProgramId = new Guid("6b22e5d0-9672-44b2-acab-e7318ba06185");

        var context = services.GetRequiredService<ApplicationDbContext>();

        if (!context.Tests.Any())
        {
            context.Tests.Add(new Test
            {
                Id = testId,
                Name = "Hip Mobility Test",
                

            });
            context.Tests.Add(new Test
            {
                Id = neckTestId,
                Name = "Neck Pain Test",
                

            });
            context.SaveChanges();

            if (!context.TestItems.Any())
            {
                context.TestItems.Add(new TestItem
                {
                    Id = new Guid("D1D1864D-085F-4E7E-B964-7A99CB7E359B"),
                    TestId = testId,
                    SortOrder = 1,
                    Task = "FADIR Test #1",
                    Question = "Do you feel a pinch and sudden block in the range or does it feel like a stretch?",
                    IsTrueFalseAnswer = true

                });
                context.TestItems.Add(new TestItem
                {
                    Id = new Guid("0910B6FB-C959-4D7E-8AC8-2503BDEC6BD0"),
                    TestId = testId,
                    SortOrder = 2,
                    Task = "FADIR Text #2",
                    Question = "Rate level of discomfort from 1-5 with 5 being extremely uncomfortable.",
                });
                context.TestItems.Add(new TestItem
                {
                    Id = new Guid("E52474DC-3FBB-4F0E-A1C4-F4671DFE05B1"),
                    TestId = testId,
                    SortOrder = 3,
                    Task = "Active Straight Leg Raise",
                    Question = "Can you flex the hip to 90° keeping both knees straight?",
                    IsTrueFalseAnswer = true
                });
                context.TestItems.Add(new TestItem
                {
                    Id = Guid.NewGuid(),
                    TestId = testId,
                    SortOrder = 4,
                    Task = "30 Second Squat #1",
                    Question = "Can you keep a smooth 10:10:10 tempo*? *10-sec descent: 10-sec hold: 10-sec ascent",
                    IsTrueFalseAnswer = true
                });
                context.TestItems.Add(new TestItem
                {
                    Id = new Guid("35244E23-9514-45A4-9DEC-F9615D39AFAC"),
                    TestId = testId,
                    SortOrder = 5,
                    Task = "30 Second Squat #2",
                    Question = "Can you get right down into a deep squat with feet flat?",
                    IsTrueFalseAnswer = true
                });
                context.TestItems.Add(new TestItem
                {
                    Id = new Guid("2337B9E0-DB72-40C9-95FB-3A324EFD5252"),
                    TestId = testId,
                    SortOrder = 6,
                    Task = "30 Second Squat #3",
                    Question = "Can you come back up without hinging or losing a tall posture?",
                    IsTrueFalseAnswer = true
                });
            }
            await context.SaveChangesAsync();
        }

    }
}
