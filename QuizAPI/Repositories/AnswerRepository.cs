using QuizAPI.Models;

namespace QuizAPI
{
    public class AnswerRepository : IAnswerRepository
    {
        private IQuizDatabaseContext _context;

        public AnswerRepository(IQuizDatabaseContext context)
        {
            _context = context;
        }


        public List<Answer> Get()
        {
            return _context.Answers.ToList();
        }

        public Answer? Get(Guid Id)
        {
            return _context.Answers.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Answer> GetAnswerByQuestionId(Guid questionId)
        {
            return _context.Answers.Where(answer => answer.QuestionId == questionId).ToList();
        }

        public Answer Post(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.Save();
            return answer;
        }

        public Answer? Put(Answer answer)
        {
            var answerToUpdate = _context.Answers.Where(x => x.Id == answer.Id).FirstOrDefault();

            if (answerToUpdate != null)
            {

                answerToUpdate.Id = answer.Id;
                answerToUpdate.AnswerText = answer.AnswerText;
                answerToUpdate.IsCorrectAnswer = answer.IsCorrectAnswer; ;

                var updatedAnswer = _context.Answers.Update(answerToUpdate);

                _context.Save();
                return updatedAnswer.Entity;
            }
            return null;
        }

        public bool Delete(Answer answer)
        {
            var foundAnswer = _context.Answers.Where(x => x.Id == answer.Id).FirstOrDefault();
            
            if (foundAnswer == null)
            {
                return false;
            }
            _context.Answers.Remove(foundAnswer);
            _context.Save();
            return true;
        }
    }
}