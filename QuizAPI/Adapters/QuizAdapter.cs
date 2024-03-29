using QuizAPI.Models;

namespace QuizAPI.Adapters
{
    
    public class QuizAdapter : IQuizAdapter
    {
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;
        private TriviaAdapter _triviaAdapter;

        public QuizAdapter(IQuestionRepository questionRepository, IAnswerRepository answerRepository, TriviaAdapter triviaAdapter)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _triviaAdapter = triviaAdapter;
        }

        
        public List<Question> GetAllQuestions()
        {
            return _questionRepository.Get();
        }

        public Question? GetQuestionById(Guid Id)
        {
            return _questionRepository.Get(Id);
        }

        public Question SaveNewQuestion(Question question)
        {
            return _questionRepository.Post(question);
        }

        public Question? UpdateQuestion(Question question)
        {
            return _questionRepository.Put(question);
        }

        public bool DeleteQuestion(Question question)
        {
            return _questionRepository.Delete(question);
        }
        
        public List<Answer> GetAllAnswers()
        {
            return _answerRepository.Get();
        }

        public Answer? GetAnswerById(Guid Id)
        {
            return _answerRepository.Get(Id);
        }

        public Answer SaveNewAnswer(Answer answer)
        {
            return _answerRepository.Post(answer);
        }

        public Answer? UpdateAnswer(Answer answer)
        {
            return _answerRepository.Put(answer);
        }

        public bool DeleteAnswer(Answer answer)
        {
            return _answerRepository.Delete(answer);
        }
        
        public QuizModel? GetRandomQuizFromDb()
        {
            Question question;
            QuizModel quiz;
            var questions = _questionRepository.Get();
            if (questions.Count() > 0)
            {
                var random = new Random();
                int index = random.Next(questions.Count);
                question = questions[index];
                var answers = _answerRepository.Get().Where(x => x.QuestionId == question.Id).ToList();
                quiz = new QuizModel(question.Category, question.TriviaId, answers, question.Text);

                return quiz;
            }
            return null;
        }


        public async Task<QuizModel> GetTriviaQuiz()
        {
            return (await _triviaAdapter.GetOneTriviaQuiz());
        }
        
        public async Task<QuizModel> GetQuiz()
        {
            var dbQuiz = GetRandomQuizFromDb();
            var random = new Random();
            int source = random.Next(2); // 2 sources: Trivia and DB.

            return (await _triviaAdapter.GetOneTriviaQuiz());
        }
        
        public bool DoesQuizExist(Guid id)
        {
            if (_questionRepository.Get().Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }


        public void Post(QuizModel quiz)
        {
            Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
            _questionRepository.Post(question);

            foreach (Answer answer in quiz.Answers)
            {
                answer.QuestionId = question.Id;
                _answerRepository.Post(answer);
            }
        }


        public void Put(QuizModel quiz)
        {
            Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
            _questionRepository.Put(question);

            foreach (Answer answer in quiz.Answers)
            {
                _answerRepository.Put(answer);
            }
        }


        public void Delete(QuizModel quiz)
        {
            Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
            _questionRepository.Delete(question);

            foreach (Answer answer in quiz.Answers)
            {
                _answerRepository.Delete(answer);
            }
        }
    }
}