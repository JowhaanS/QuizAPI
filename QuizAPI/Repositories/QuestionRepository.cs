using QuizAPI.Models;

namespace QuizAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private IQuizDatabaseContext _context;


        public QuestionRepository(IQuizDatabaseContext context)
        {
            _context = context;
        }



        public List<Question> Get()
        {
            return _context.Questions.ToList();
        }

        public Question? Get(Guid Id)
        {
            return _context.Questions.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Question Post(Question question)
        {
            var addedQuestion =
                _context.Questions.Add(question);
            _context.Save();
            return addedQuestion.Entity;
        }

        public Question? Put(Question question)
        {
            var questionToUpdate = _context.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

            if (questionToUpdate != null)
            {
                
                questionToUpdate.Id = question.Id;
                questionToUpdate.Text = question.Text;
                questionToUpdate.Category = question.Category; ;

                var updatedQuestion = _context.Questions.Update(questionToUpdate);

                _context.Save();
                return updatedQuestion.Entity;
            }
            return null;
        }

        public bool Delete(Question question)
        {
            var foundQuestion = _context.Questions.Where(x => x.Id == question.Id).FirstOrDefault();
            
            if (foundQuestion == null)
            {
                return false;
            }
            _context.Questions.Remove(foundQuestion);
            _context.Save();
            return true;
        }
    }
}