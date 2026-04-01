namespace SaveToFile
{
    internal class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Club { get; set; }

        public Player(int id, string name, int age, string club)
        {
            Id = id;
            Name = name;
            Age = age;
            Club = club;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Player> players = new List<Player>
            {
                new Player(1, "Paulo",    20, "FC Potato"),
                new Player(2, "Karl",     30, "FC Tomato"),
                new Player(3, "Grzegorz", 25, "FC Polako"),
                new Player(4, "John",     24, "FC Uralto"),
                new Player(5, "Fabiano",  22, "FC Utarto"),
            };

                string fileName;

                if (args.Length < 1)
                {
                    Console.Write("Podaj nazwe pliku do ktorego chcesz zapisac dane (z .txt): ");
                    fileName = Console.ReadLine() ?? "";
                }
                else
                {
                    fileName = args[0];
                }

                using StreamWriter writer = new StreamWriter(fileName);

                foreach (Player player in players)
                {
                    writer.WriteLine($"Gracz o ID: {player.Id}");
                    writer.WriteLine(player.Name);
                    writer.WriteLine(player.Age);
                    writer.WriteLine(player.Club);
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
