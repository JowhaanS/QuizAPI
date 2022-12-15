namespace QuizAPI.Models;

public class Answer : BaseModel
{
    private string AnswerText { get; set; }
    private bool IsCorrect { get; set; }
    private Guid QuestionId { get; set; }

    public Answer(string answerText, bool isCorrect, Guid questionId)
    {
        Id = new Guid();
        AnswerText = answerText;
        IsCorrect = isCorrect;
        QuestionId = questionId;
    }
}