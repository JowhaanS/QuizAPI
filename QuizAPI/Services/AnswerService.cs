using QuizAPI.Models;

namespace QuizAPI.Services
{
    public class AnswerService
    {
        private AnswerAdapter _adapter;

        public AnswerService(AnswerAdapter adapter)
        {
            _adapter = adapter;
        }


        public List<Answer> GetAllAnswers()
        {
            return _adapter.GetAllAnswers();
        }

        public List<Answer> GetAnswerByID(Guid id)
        {
            return _adapter.GetAllAnswers().Where(answer => answer.Id == id).ToList();
        }

        public Answer PostAnswer(Answer answer)
        {
            _adapter.SaveNewAnswer(answer);
            return (answer);
        }

        public bool PutAnswer(Answer answer)
        {
            var foundAnswer = _adapter.GetAllAnswers().Where(x => x.Id == answer.Id).FirstOrDefault();
            if (foundAnswer == null)
            {
                return false;
            }
            _adapter.DeleteAnswer(foundAnswer);
            _adapter.SaveNewAnswer(answer);
            return true;
        }

        public bool DeleteAnswer(Guid id)
        {
            var foundAnswer = _adapter.GetAllAnswers().Where(x => x.Id == id).FirstOrDefault();
            if (foundAnswer == null)
            {
                return false;
            }
            _adapter.DeleteAnswer(foundAnswer);
            return true;
        }
    }
}