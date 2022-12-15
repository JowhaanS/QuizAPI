namespace QuizAPI.Models;

public class QuizItem : BaseModel
{
    private string TriviaId { get; set; }
    private Question QuizItemQuestion { get; set; }

    public QuizItem(string triviaId, Question question)
    {
        Id = new Guid();
        TriviaId = triviaId;
        QuizItemQuestion = question;
    }
}