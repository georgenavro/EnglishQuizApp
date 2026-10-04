using English_QA.Models.DatabaseModels;
using English_QA.Globals;
using Microsoft.EntityFrameworkCore;

namespace English_QA.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source = " + Variables.DatabasePath);

        public DbSet<Usertype> UserType { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<QA> QA { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<AnswerTypes> AnswerTypes { get; set; }
        public DbSet<TestResults> TestResults { get; set; }
        public DbSet<UserTest> UserTest { get; set; }
      

    }
}
