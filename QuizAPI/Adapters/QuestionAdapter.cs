using QuizAPI.Models;


namespace QuizAPI.Adapters
{
    public class QuestionAdapter
    {
        private IQuestionRepository _repository;

        public QuestionAdapter(IQuestionRepository repository)
        {
            _repository = repository;
        }


        public List<Question> GetAllQuestions()
        {
            return _repository.Get();
        }

        public Question? GetQuestionById(Guid Id)
        {
            return _repository.Get(Id);
        }

        public Question SaveNewQuestion(Question question)
        {
            return _repository.Post(question);
        }

        public Question? UpdateQuestion(Question question)
        {
            return _repository.Put(question);
        }

        public bool DeleteQuestion(Question question)
        {
            return _repository.Delete(question);
        }
    }

}