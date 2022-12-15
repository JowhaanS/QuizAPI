namespace QuizAPI.Models;

public class Question : BaseModel
{
    private string QuestionText { get; set; }
    private string TriviaId { get; set; }
    private List<Answer> Answers { get; set; }

    public Question(string questionText, string triviaId, List<Answer> answers)
    {
        Id = new Guid();
        QuestionText = questionText;
        TriviaId = triviaId;
        Answers = answers;
    }
}