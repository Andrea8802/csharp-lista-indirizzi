using System.IO;
using System.Net;
using System.Xml.Linq;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Indirizzo> addresses = new List<Indirizzo>();

            Console.WriteLine("------------------\n");

            StreamReader file = File.OpenText("addresses.csv");

            int i = 0;
            while (!file.EndOfStream)
            {

                try
                {
                    string? line = file.ReadLine();
                    string[] words = line.Split(',');

                    if (i < 1)
                    {
                        i++;
                        continue;
                    }

                    if (words.Length == 6)
                    {
                        string name = words[0];
                        string surname = words[1];
                        string street = words[2];
                        string city = words[3];
                        string province = words[4];
                        string zip = words[5];

                        Console.WriteLine($"Indirizzo n° {i}: {name}, {surname}, {street}, {city}, {province}, {zip}\n");

                        addresses.Add(new Indirizzo(name, surname, street, city, province, zip));
                    }
                    else
                    {
                        throw new Exception($"L'indirizzo n° {i} contiene uno o più campi vuoti!");
                    }

                    Console.WriteLine("------------------\n");
                }
                catch (Exception e)
                {

                    Console.WriteLine("Errore! " + e.Message);
                    Console.WriteLine("\n------------------\n");
                }

                i++;
            }

            file.Close();


        }
    }
}