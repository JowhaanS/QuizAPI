namespace QuizAPI.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string TriviaId { get; set; }
        public string Text { get; set; }
        public string Category { get; set; } 


        public Question(string text, string triviaId, string category) 
        {
            this.Id = Guid.NewGuid(); 
            this.TriviaId = triviaId;
            this.Text = text;
            this.Category = category;

        }
    }
}