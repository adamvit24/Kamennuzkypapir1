using System;
using System.Collections.Generic;

class Program
{
    const int Size = 10; // velikost hrací plochy
    static int[,] grid = new int[Size, Size];

    // Definice bloků (matice 0/1)
    static List<int[,]> blocks = new List<int[,]>
    {
        new int[,] { {1} },                    // 1x1
        new int[,] { {1,1,1} },                // 1x3
        new int[,] { {1,1}, {1,1} },           // 2x2
        new int[,] { {1,0}, {1,0}, {1,1} }     // L-tvar
    };

    static void Main()
    {
        Random rnd = new Random();

        while (true)
        {
            Console.Clear();
            PrintGrid();

            // Vyber náhodný blok
            int[,] shape = blocks[rnd.Next(blocks.Count)];
            Console.WriteLine("Dostal jsi blok:");
            PrintShape(shape);

            Console.WriteLine("Zadej pozici X Y (levý horní roh) nebo -1 pro konec:");
            int x = int.Parse(Console.ReadLine());
            if (x == -1) break;
            int y = int.Parse(Console.ReadLine());

            if (CanPlaceBlock(shape, x, y))
            {
                PlaceBlock(shape, x, y);
                ClearLines();
            }
            else
            {
                Console.WriteLine("Nelze umístit blok!");
                Console.ReadKey();
            }
        }
    }

    static void PrintGrid()
    {
        // Osa X nahoře
        Console.Write("    ");
        for (int j = 0; j < Size; j++)
            Console.Write(j + " ");
        Console.WriteLine();

        Console.Write("   ");
        for (int j = 0; j < Size * 2; j++)
            Console.Write("-");
        Console.WriteLine();

        // Hrací plocha s osou Y vlevo
        for (int i = 0; i < Size; i++)
        {
            Console.Write(i + " | "); // číslo řádku
            for (int j = 0; j < Size; j++)
                Console.Write(grid[i, j] == 1 ? "█ " : ". ");
            Console.WriteLine();
        }
    }

    static void PrintShape(int[,] shape)
    {
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
                Console.Write(shape[i, j] == 1 ? "█" : ".");
            Console.WriteLine();
        }
    }

    static bool CanPlaceBlock(int[,] shape, int x, int y)
    {
        int h = shape.GetLength(0);
        int w = shape.GetLength(1);

        if (x < 0 || y < 0 || x + w > Size || y + h > Size)
            return false;

        for (int i = 0; i < h; i++)
            for (int j = 0; j < w; j++)
                if (shape[i, j] == 1 && grid[y + i, x + j] == 1)
                    return false;

        return true;
    }

    static void PlaceBlock(int[,] shape, int x, int y)
    {
        int h = shape.GetLength(0);
        int w = shape.GetLength(1);

        for (int i = 0; i < h; i++)
            for (int j = 0; j < w; j++)
                if (shape[i, j] == 1)
                    grid[y + i, x + j] = 1;
    }

    static void ClearLines()
    {
        // Mazání řádků
        for (int i = 0; i < Size; i++)
        {
            bool full = true;
            for (int j = 0; j < Size; j++)
                if (grid[i, j] == 0) full = false;

            if (full)
                for (int j = 0; j < Size; j++)
                    grid[i, j] = 0;
        }

        // Mazání sloupců
        for (int j = 0; j < Size; j++)
        {
            bool full = true;
            for (int i = 0; i < Size; i++)
                if (grid[i, j] == 0) full = false;

            if (full)
                for (int i = 0; i < Size; i++)
                    grid[i, j] = 0;
        }
    }
}