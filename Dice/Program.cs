namespace Dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice1 = new Dice();

            Console.WriteLine(Dice.count);
            Console.WriteLine(dice1.Value());
            Console.WriteLine(dice1.images[dice1.imgId]);

            Dice dice2 = new Dice(1);

            Console.WriteLine(Dice.count);
            Console.WriteLine(dice2.Value());
            Console.WriteLine(dice2.images[dice2.imgId]);
        }
    }

    class Dice
    {
        public static int count = 0;
        static Random ran = new Random();

        public string[] images = { "kosc0.jpg", "kosc1.jpg", "kosc2.jpg", "kosc3.jpg", "kosc4.jpg", "kosc5.jpg", "kosc6.jpg" };
        public int result = 0;
        public int imgId = 0;
        public bool isAvialable = true;

        public Dice(int value)
        {
            if (value <= 0 && value > 6) value = 0;

            result = value;
            imgId = value;
            isAvialable = true;
            count++;
        }

        public Dice()
        {
            int temp = ran.Next(7);

            result = temp;
            imgId = temp;
            isAvialable = true;
            count++;
        }

        public void Throw()
        {
            if (!isAvialable) return;
            int temp = ran.Next(7);

            result = temp;
            imgId = temp;
        }

        public void Lock()
        {
            isAvialable = false;
        }

        public string Value()
        {
            switch (result)
            {
                case 0: return "zero";
                case 1: return "jeden";
                case 2: return "dwa";
                case 3: return "trzy";
                case 4: return "cztery";
                case 5: return "pięć";
                case 6: return "sześć";
                default: return "zero";
            }
        }
    }
}
