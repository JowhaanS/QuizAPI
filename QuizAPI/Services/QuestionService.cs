using QuizAPI.Models;
using QuizAPI.Adapters;

namespace QuizAPI.Services
{
    public class QuestionService
    {
        private QuestionAdapter _adapter;


        public QuestionService(QuestionAdapter adapter)
        {
            _adapter = adapter;
        }



        public List<Question> Get()
        {
            return _adapter.GetAllQuestions();
        }

        public Question? Get(Guid Id)
        {
            return _adapter.GetQuestionById(Id);
        }

        public Question Post(Question question)
        {
            return _adapter.SaveNewQuestion(question);
        }

        public Question? Put(Question question)
        {
            return _adapter.UpdateQuestion(question);
        }

        public bool Delete(Question question)
        {
            return _adapter.DeleteQuestion(question);
        }
    }
}