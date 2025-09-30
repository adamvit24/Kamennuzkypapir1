namespace KamenNuzkyPapir
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            string[] moznosti = { "kámen", "nůžky", "papír" };

            while (true)
            {
                Console.WriteLine("Vyber si: kámen, nůžky, papír (nebo 'konec' pro ukončení):");
                string hracVolba = Console.ReadLine().ToLower();

                if (hracVolba == "konec")
                    break;

                if (Array.IndexOf(moznosti, hracVolba) == -1)
                {
                    Console.WriteLine("Neplatná volba, zkus to znovu.");
                    continue;
                }

                string pcVolba = moznosti[rnd.Next(moznosti.Length)];
                Console.WriteLine($"Počítač vybral: {pcVolba}");

                // Určení výsledku
                if (hracVolba == pcVolba)
                {
                    Console.WriteLine("Remíza!");
                }
                else if (
                    (hracVolba == "kámen" && pcVolba == "nůžky") ||
                    (hracVolba == "nůžky" && pcVolba == "papír") ||
                    (hracVolba == "papír" && pcVolba == "kámen")
                )
                {
                    Console.WriteLine("Vyhrál jsi!");
                }
                else
                {
                    Console.WriteLine("Prohrál jsi!");
                }

                Console.WriteLine(); // prázdný řádek pro přehlednost
            }

            Console.WriteLine("Díky za hru!");
        }
    }
}