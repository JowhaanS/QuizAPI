using QuizAPI.Models;

namespace QuizAPI
{
    public interface IAnswerRepository
    {
        public List<Answer> Get();
        public Answer? Get(Guid Id);
        public List<Answer> GetAnswerByQuestionId(Guid questionId);
        public Answer Post(Answer answer);
        public Answer? Put(Answer answer);
        public bool Delete(Answer answer);
    }
}