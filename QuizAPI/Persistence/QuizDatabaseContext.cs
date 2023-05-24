using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;


namespace QuizAPI.Persistance
{
    public class QuizDatabaseContext : DbContext, IQuizDatabaseContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizDatabaseContext()
        {
            this.Database.EnsureCreated(); 
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=quiz.sqlite"); 
        }


        public int Save()
        {
            return this.SaveChanges();
        }
    }
}