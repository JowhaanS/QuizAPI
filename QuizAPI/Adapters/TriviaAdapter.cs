using QuizAPI.Models;
using QuizAPI.Repositories;

namespace QuizAPI.Adapters
{
    
    public class TriviaAdapter
    {
        private TriviaRepository _triviaRepository;

        public TriviaAdapter()
        {
            _triviaRepository = new TriviaRepository();
        }


        public async Task<QuizModel> GetOneTriviaQuiz()
        {
            var response = await _triviaRepository.GetTriviaAsync();

            QuizModel responseQuiz = null;

            foreach (TriviaModel quiz in response)
            {
                List<Answer> answers = new List<Answer>();
                responseQuiz = new QuizModel(quiz.Category, quiz.Id, answers, quiz.Question);
                responseQuiz.Answers.Add(new Answer(quiz.CorrectAnswer, responseQuiz.Id, true));

                foreach (string answer in quiz.IncorrectAnswers)
                {
                    responseQuiz.Answers.Add(new Answer(answer, responseQuiz.Id, false));
                }
            }

            return responseQuiz;
        }
    }
}