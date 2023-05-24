using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI
{
    public interface IQuizDatabaseContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public int Save();
    }
}