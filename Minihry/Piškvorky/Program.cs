using System.Diagnostics;

namespace Šibenice
{
    internal class Program
    {
        static char[,] board = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        static char currentPlayer = 'X';

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                VykresliHraciPole();

                Console.WriteLine($"Hráč {currentPlayer}, zadej řádek a sloupec (0-2):");
                Console.Write("Řádek: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Sloupec: ");
                int col = int.Parse(Console.ReadLine());

                if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
                {
                    Console.WriteLine("Neplatný tah, zkus to znovu.");
                    Console.ReadKey();
                    continue;
                }
                board[row, col] = currentPlayer;

                if (Vyhra(currentPlayer))
                {
                    Console.Clear();
                    VykresliHraciPole();
                    Console.WriteLine($"Hráč {currentPlayer} vyhrál!");
                    break;
                }
                if (Remiza())
                {
                    Console.Clear();
                    VykresliHraciPole();
                    Console.WriteLine("Remíza!");
                    break;
                }

                //Zmena hrace
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        static void VykresliHraciPole()
        {
            Console.WriteLine("  0   1   2 ");
            for (int r = 0; r < 3; r++)
            {
                Console.Write(r + " ");
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(board[r, c]);
                    if (c < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (r < 2) Console.WriteLine(" ---+---+---");
            }
        }
        static bool Vyhra(char hrac)
        {
            // radky a sloupce
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == hrac && board[i, 1] == hrac && board[i, 2] == hrac) return true;
                if (board[0, i] == hrac && board[1, i] == hrac && board[2, i] == hrac) return true;
            }

            // diagonaly
            if (board[0, 0] == hrac && board[1, 1] == hrac && board[2, 2] == hrac) return true;
            if (board[0, 2] == hrac && board[1, 1] == hrac && board[2, 0] == hrac) return true;

            return false;
        }

        static bool Remiza()
        {
            foreach (char c in board)
            {
                if (c == ' ') return false;
            }
            return true;
        }
    }
}