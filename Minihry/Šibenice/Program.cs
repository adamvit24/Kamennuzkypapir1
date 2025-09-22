using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // slova pro hadani
        string[] slova = { "vyvojsoftwaru", "aplikacnisoftware", "matika", "fyzika", "operacnisystemy", "cestina" };
        Random rnd = new Random();
        string tajneSlovo = slova[rnd.Next(slova.Length)];

        HashSet<char> hadanaPismena = new HashSet<char>();
        int maxChyb = 7;
        int chyby = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ŠIBENICE ===");
            Console.WriteLine();
            Console.WriteLine("Slovo: " + ZobrazSlovo(tajneSlovo, hadanaPismena));
            Console.WriteLine("Špatné pokusy: " + chyby + "/" + maxChyb);
            Console.WriteLine();

            // kontrola vyhry
            if (Uhadnuto(tajneSlovo, hadanaPismena))
            {
                Console.WriteLine("🎉 Gratuluji, uhodl jsi slovo!");
                break;
            }

            if (chyby >= maxChyb)
            {
                Console.WriteLine("💀 Prohrál jsi! Slovo bylo: " + tajneSlovo);
                break;
            }

            Console.Write("Zadej písmeno: ");
            string vstup = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(vstup) || vstup.Length != 1)
            {
                Console.WriteLine("Zadej jen jedno písmeno. Stiskni Enter pro pokračování.");
                Console.ReadLine();
                continue;
            }

            char pismeno = vstup[0];

            if (hadanaPismena.Contains(pismeno))
            {
                Console.WriteLine("Toto písmeno už jsi zkoušel. Stiskni Enter pro pokračování.");
                Console.ReadLine();
                continue;
            }

            hadanaPismena.Add(pismeno);

            if (!tajneSlovo.Contains(pismeno))
            {
                chyby++;
            }
        }
    }

    static string ZobrazSlovo(string slovo, HashSet<char> hadana)
    {
        string vysledek = "";
        foreach (char c in slovo)
        {
            if (hadana.Contains(c))
                vysledek += c + " ";
            else
                vysledek += "_ ";
        }
        return vysledek;
    }

    static bool Uhadnuto(string slovo, HashSet<char> hadana)
    {
        foreach (char c in slovo)
        {
            if (!hadana.Contains(c))
                return false;
        }
        return true;
    }
}