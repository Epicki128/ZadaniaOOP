namespace ZadaniaOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string text;
            Console.WriteLine("Podaj tekst:");
            text = Console.ReadLine();
            int vovelCount = EditText.countVovels(text);
            Console.WriteLine($"Liczba samogłosek: {vovelCount}");
            string editedText = EditText.removeRepeatedChars(text);
            Console.WriteLine($"Tekst po usunięciu powtórzonych znaków: \"{editedText}\"");
        }
    }

    class EditText
    {

        static public int countVovels(string text)
        {
            int count = 0;
            string vowels = "aąeęioóuAĄEĘIOÓU";
            foreach (char c in text)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            return count;
        }

        static public string removeRepeatedChars(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                if (result.EndsWith(c))
                {
                    continue;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }
}
