using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SequentialTests.Models;
using SequentialTests.Models.Sessions;
using System.Reflection.Emit;

namespace SequentialTests.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Test> Tests { get; set; }

        public DbSet<TestInstance> TestInstances { get; set; }

        public DbSet<TestItem> TestItems { get; set; }

        public DbSet<TestResult> TestResults { get; set; }

    }

}
