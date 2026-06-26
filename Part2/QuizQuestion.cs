namespace Part2
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public QuizQuestion(string q, string a)
        {
            Question = q;
            Answer = a;
        }
    }
}