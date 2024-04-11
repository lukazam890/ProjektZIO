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
            optionsBuilder.UseSqlServer("Data Source=SQL5113.site4now.net;Initial Catalog=db_aa77f9_zio2024ipp;User ID=db_aa77f9_zio2024ipp_admin;Password=ipp2024!;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
