namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            try
            {
                List<Indirizzo> indirizzi = new List<Indirizzo>();

                StreamReader file = File.OpenText("addresses.csv");
                
                while (!file.EndOfStream)
                {
                    if (i > 0)
                    {
                        string riga = file.ReadLine();
                        string[] parole = riga.Split(",");

                        string name = parole[0];
                        string surname = parole[1];
                        string street = parole[2];
                        string city = parole[3];
                        string province = parole[4];
                        string zip = parole[5];

                        Indirizzo newIndirizzo = new Indirizzo(name, surname, street, city, province, zip);
                        Console.WriteLine($"Indirizzo n° {i}: {name}, {surname}, {street}, {city}, {province}, {zip}\n");
                        indirizzi.Add(newIndirizzo);
                    }
                    i++;
                    
                }

                file.Close();
            }
            catch(Exception error)
            {
                Console.WriteLine($"Si è verificato un errore con l'indirizzo n: '{i}' {error.Message}\n");
            }
            


        }
    }
}