using Microsoft.EntityFrameworkCore;

namespace ProjektZiotest.Models
{
    public class QuizDB : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
     optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZioTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
