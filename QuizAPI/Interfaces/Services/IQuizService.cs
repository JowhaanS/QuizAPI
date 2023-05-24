using QuizAPI.Models;

namespace QuizAPI
{
    public interface IQuizService
    {
        public Task<QuizModel?> GetQuiz();
        public QuizSolution EvaluateQuizAnswer(QuizAnswer quizAnswer);
        public QuizModel? GetDbQuiz();
        public Task<QuizModel> GetTriviaQuiz();
        public bool isAnswerCorrect(Answer answer);
        public bool DoesQuizExistinDb(Guid id);
        public QuizModel AddQuizToDatabase(QuizModel quiz);
        public void UpdateQuizInDatabase(QuizModel quiz);
        public void DeleteQuizFromDatabase(QuizModel quiz);
    }
}