using System.Text.RegularExpressions;

namespace PeselValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pesel = "55030101193";

            if (ValidatePesel.Validate(pesel)) Console.WriteLine($"Pesel {pesel} jest poprawny!");
            else Console.WriteLine($"Pesel {pesel} jest niepoprawny!");

            if (ValidatePesel.checkGender(pesel) == 'M') Console.WriteLine("Ten pesel należy do mężczyzny!");
            else Console.WriteLine("Ten pesel należy do kobiety");
        }
    }

    class ValidatePesel
    {
        static private readonly string peselPattern = @"\d{11}$";

        static private int[] digits = new int[11];

        static private readonly int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        static public bool Validate(string pesel)
        {
            if (Regex.IsMatch(pesel, peselPattern))
            {
                for (int i = 0; i < pesel.Length; i++)
                {
                    int temp = int.Parse(pesel[i].ToString());
                    digits[i] = temp;
                }

                if (CheckChecksum(digits)) return true;
                else return false;

            }
            else return false;
        }

        static private bool CheckChecksum(int[] pesel)
        {
            int[] temp = new int[weights.Length];

            foreach (int i in weights)
            {
                temp[i] = pesel[i] * weights[i];
            }

            int sum = temp.Sum();
            int rmod = (sum % 10 == 0) ? 0 : 10 - (sum % 10);

            if (rmod == pesel.Last()) return true;
            else return false;
        }

        static public char checkGender(string pesel)
        {
            if (!Validate(pesel)) throw new Exception("Podany pesel nie jest poprawny!");

            int temp = Convert.ToInt32(pesel[9]);

            if (temp % 2 == 0) return 'K';
            else return 'M';
        }

    }
}
