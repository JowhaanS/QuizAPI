using QuizAPI.Models;

namespace QuizAPI
{
    public interface IQuizAdapter
    {
        public Question? GetQuestionById(Guid Id);
        public Answer? GetAnswerById(Guid Id);
        public QuizModel? GetRandomQuizFromDb();
        public bool DoesQuizExist(Guid id);
        public void Post(QuizModel quiz);
        public void Put(QuizModel quiz);
        public void Delete(QuizModel quiz);
    }
}