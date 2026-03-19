using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Transactions;
using System.Xml.Linq;

namespace FetchAPI
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            Fetcher fetcher = new Fetcher();

            while (true)
            {
                Console.WriteLine("Name of the Country:");
                string country = Console.ReadLine();

                await fetcher.Show(country);

                Console.WriteLine("Do you want to Continue?(Y/N)");

                char temp = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (temp != 'Y' && temp != 'y')
                {
                    break;
                }
            }
        }
    }

    class Fetcher
    {
        List<Country> result;

        static private string url = "https://restcountries.com/v3.1/name/";

        public string country { get; set; }

        private async Task Fetch(string country)
        {
            using HttpClient client = new HttpClient();

            string fullUrl = url + country;

            try
            {
                string response = await client.GetStringAsync(fullUrl);
                result = JsonSerializer.Deserialize<List<Country>>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task Show(string country)
        {
            await Fetch(country);

            if (result == null || result.Count == 0)
            {
                Console.WriteLine("Country not found.");
                return;
            }

            Country res = result[0];

            Console.WriteLine($"Name: {res.altSpellings[^1]}");
            Console.WriteLine($"Region: {res.region}");
            Console.WriteLine($"Capital(s):");
            foreach (var capital in res.capital)
            {
                Console.WriteLine($"    {capital}");
            }
            Console.WriteLine($"Currency/Currencies:");
            foreach (var currency in res.currencies)
            {
                Console.WriteLine($"    {currency.Key} - {currency.Value.name}({currency.Value.symbol})");
            }
            Console.WriteLine($"Population: {res.population}");
            Console.WriteLine($"Area: {res.area}km2");

            res = null;
            result = null;
        }

    }

    public class Country
    {
        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }

        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }

        public Idd idd { get; set; }

        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }

        public string region { get; set; }
        public string subregion { get; set; }

        public bool landlocked { get; set; }

        public List<string> borders { get; set; }

        public double area { get; set; }

        public Maps maps { get; set; }

        public int population { get; set; }

        public string fifa { get; set; }

        public Car car { get; set; }

        public List<string> timezones { get; set; }

        public List<string> continents { get; set; }

        public string flag { get; set; }

        public Name name { get; set; }

        public Dictionary<string, Currency> currencies { get; set; }

        public Dictionary<string, string> languages { get; set; }

        public List<double> latlng { get; set; }

        public Demonyms demonyms { get; set; }

        public Dictionary<string, Translation> translations { get; set; }

        public Dictionary<string, double> gini { get; set; }

        public Flags flags { get; set; }

        public CoatOfArms coatOfArms { get; set; }

        public string startOfWeek { get; set; }

        public CapitalInfo capitalInfo { get; set; }

        public PostalCode postalCode { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public List<string> suffixes { get; set; }
    }

    public class Maps
    {
        public string googleMaps { get; set; }
        public string openStreetMaps { get; set; }
    }

    public class Car
    {
        public List<string> signs { get; set; }
        public string side { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }

        public Dictionary<string, NativeName> nativeName { get; set; }
    }

    public class NativeName
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Currency
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Demonyms
    {
        public Gender eng { get; set; }
        public Gender fra { get; set; }
    }

    public class Gender
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Translation
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Flags
    {
        public string png { get; set; }
        public string svg { get; set; }
        public string alt { get; set; }
    }

    public class CoatOfArms
    {
        public string png { get; set; }
        public string svg { get; set; }
    }

    public class CapitalInfo
    {
        public List<double> latlng { get; set; }
    }

    public class PostalCode
    {
        public string format { get; set; }
        public string regex { get; set; }
    }

}
