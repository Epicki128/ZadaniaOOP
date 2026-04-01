namespace FileAnalyser
{
    internal class Program
    {
        static readonly char[] Vowels = { 'a', 'e', 'i', 'y', 'o', 'u', 'A', 'E', 'I', 'O', 'Y', 'U' };

        static void Main(string[] args)
        {
            try
            {
                string fileName;

                if (args.Length >= 1)
                    fileName = args[0];
                else
                {
                    Console.Write("Podaj sciezke do pliku: ");
                    fileName = Console.ReadLine() ?? "";
                }

                if (string.IsNullOrEmpty(fileName))
                    throw new Exception("File name was not provided!");

                int charsCount = 0;
                int linesCount = 0;
                int vowelsCount = 0;
                int consonantsCount = 0;
                int wordsCount = 0;

                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    linesCount++;

                    string[] words = line
                        .Split(' ')
                        .Where(w => w != "\n" && w != "")
                        .ToArray();

                    wordsCount += words.Length;

                    foreach (char ch in line)
                    {
                        if (ch != '\n')
                            charsCount++;

                        if (Vowels.Contains(ch))
                            vowelsCount++;
                        else if (!char.IsWhiteSpace(ch))
                            consonantsCount++;
                    }
                }

                long fileSize = new FileInfo(fileName).Length;

                Console.WriteLine($"size of file: {fileSize} bytes");
                Console.WriteLine($"count of words: {wordsCount}");
                Console.WriteLine($"count of lines: {linesCount}");
                Console.WriteLine($"count of characters (with spaces): {charsCount}");

                Console.WriteLine("------------------------");
                Console.WriteLine("Without whitespaces!");
                Console.WriteLine("------------------------");

                Console.WriteLine($"count of vowels: {vowelsCount}");
                Console.WriteLine($"count of consonants: {consonantsCount}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("[ERROR]: File not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("[ERROR]: File not exist!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }
    }
}
