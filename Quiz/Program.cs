namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClosedQuestion question = new ClosedQuestion("Ile nóg ma stonoga?", "stonoga.webp", "100", "2", "84", 'A');
            question.Check('A');
        }
    }

    abstract class Question
    {
        protected string question { get; set; }
        protected string imageSrc { get; set; }
        protected bool isCorrect { get; set; }
        protected Question(string question, string imageSrc)
        {
            this.question = question;
            this.imageSrc = imageSrc;
            this.isCorrect = false;
        }

        public abstract bool Check(char answer);
    }

    class ClosedQuestion : Question
    {
        private string answerA { get; set; }
        private string answerB { get; set; }
        private string answerC { get; set; }
        private char correctAnswer { get; set; }

        public ClosedQuestion(string question, string imageSrc, string answerA, string answerB, string answerC, char correctAnswer) : base(question, imageSrc)
        {
            this.answerA = answerA;
            this.answerB = answerB;
            this.answerC = answerC;
            this.correctAnswer = correctAnswer;
        }

        public override bool Check(char answer)
        {
            if (answer == correctAnswer)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
