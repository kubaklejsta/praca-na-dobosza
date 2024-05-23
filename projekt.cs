class Ksiazka
{
    public string Tytul { get; set; }
    public Autor Autor { get; set; }
    public Kategoria Kategoria { get; set; }
    public string Opis { get; set; }
    static void DodajKsiazke()
    {
        Console.Write("Podaj tytuł książki: ");
        string tytul = Console.ReadLine();

        Console.Write("Podaj imię autora: ");
        string imieAutora = Console.ReadLine();

        Console.Write("Podaj nazwisko autora: ");
        string nazwiskoAutora = Console.ReadLine();

        Console.Write("Podaj kategorię książki: ");
        string kategoria = Console.ReadLine();

        Console.Write("Podaj numer ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Podaj opis książki: ");
        string opis = Console.ReadLine();

        Ksiazka ksiazka = new Ksiazka()
        {
            Tytul = tytul,
            Autor = new Autor() { Imie = imieAutora, Nazwisko = nazwiskoAutora },
            Kategoria = new Kategoria() { Nazwa = kategoria },
             Opis = opis
        };

        string json = JsonConvert.SerializeObject(ksiazka);

        string[] ksiazki = File.ReadAllLines("biblioteka.json");
        List<Ksiazka> listaKsiazek = new List<Ksiazka>();

        foreach (string ksiazkaJson in ksiazki)
        {
            listaKsiazek.Add(JsonConvert.DeserializeObject<Ksiazka>(ksiazkaJson));
        }

        listaKsiazek.Add(ksiazka);

        string[] nowaListaKsiazek = listaKsiazek.Select(k => JsonConvert.SerializeObject(k)).ToArray();
        File.WriteAllLines("biblioteka.json", nowaListaKsiazek);

        Console.WriteLine("Książka została dodana.");
    }

}

class Autor
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
}

class Kategoria
{
    public string Nazwa { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        static void WyswietlListeKsiazek()
        {
            string[] ksiazkiJson = File.ReadAllLines("ksiazki.json");
            List<Ksiazka> listaKsiazek = new List<Ksiazka>();

            foreach (string ksiazkaJson in ksiazkiJson)
            {
                listaKsiazek.Add(JsonConvert.DeserializeObject<Ksiazka>(ksiazkaJson));
            }

            if (listaKsiazek.Count == 0)
            {
                Console.WriteLine("Brak książek w bazie.");
                return;
            }

            Console.WriteLine("Lista książek:");

          

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Aplikacja zarządzania książkami");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Edytuj książkę");
            Console.WriteLine("3. Usuń książkę");
            Console.WriteLine("4. Wyszukaj książkę");
            Console.WriteLine("5. Wyświetl listę książek");
            Console.WriteLine("6. Wyjdź");

            Console.Write("Wybierz opcję: ");
            int opcja = int.Parse(Console.ReadLine());

            switch (opcja)
            {
                case 1:
                    DodajKsiazke();
                    break;
                case 2:
                    EdytujKsiazke();
                    break;
                case 3:
                    UsunKsiazke();
                    break;
                case 4:
                    WyszukajKsiazke();
                    break;
                case 5:
                    WyswietlListeKsiazke();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }
    }