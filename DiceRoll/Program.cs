namespace DiceRoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Roller diceRoll = new Roller();

            diceRoll.Roll();
        }
    }

    class Roller
    {
        static private Random random = new Random();

        private List<int> nums = new List<int>();

        private int count = 3;
        private int result = 0;

        public void Roll()
        {
            result = 0;
            nums.Clear();

            count = GetDiceCount();
            for (int i = 0; i < count; i++)
            {
                nums.Add(random.Next(1, 7));

                Console.WriteLine($"Kostka {i}: {nums[i]}");
            }

            var temp = nums
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .ToArray();

            foreach (var item in temp)
            {
                result += item;
            }

            Console.WriteLine($"Liczba uzyskanych punktów: {result}");

            Console.WriteLine("Jeszcze raz? (t/n)");
            bool again = Console.ReadLine() == "t";

            if (again) Roll();
        }

        private int GetDiceCount()
        {
            int temp = 0;
            do
            {
                Console.WriteLine("Ile kostek chcesz rzucić? (3-10)");
                temp = int.TryParse(Console.ReadLine(), out int r) ? r : 0;
            } while (temp <= 3 || temp >= 10);
            return temp;
        }

    }
}
