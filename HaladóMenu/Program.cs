using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaladóMenu
{
    internal class Program
    {
        static void Main()
        {
            string nev = "";
            int szulev = 0;
            bool ferfi = true;
            int currentPoint = 0;
            do
            {
                bool selected = false;
                do
                {
                    ShowMenu(currentPoint);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            selected = true;
                            break;

                        case ConsoleKey.UpArrow:
                            if (currentPoint > 0)
                                currentPoint--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentPoint < 2)
                                currentPoint++;
                            break;

                        default:
                            Console.Beep();
                            break;
                    }
                } while (!selected);
                switch (currentPoint)
                {
                    case 0:      //adatbekérés
                        Console.Clear();
                        Console.WriteLine("***** ADATBEKÉRÉS *****");
                        Console.Write("Add meg a neved: ");
                        nev = Console.ReadLine();
                        do
                        {
                            Console.Write("Add meg a születési dátumodat: ");
                        } while (!int.TryParse(Console.ReadLine(), out szulev));

                        Console.Write("Add meg a nemed(f/n): ");
                        ferfi = Console.ReadLine().ToLower() == "f";
                        Console.WriteLine("Az adatokat sikeresen rögzítettük. Enterre tovább....");
                        Console.ReadLine();
                        break;
                    case 1:     //adatkiirás
                        Console.WriteLine("***** ADATOK KIÍRÁSA *****");
                        Console.WriteLine($"Neve: {nev}");
                        Console.WriteLine($"Születési dátuma: {szulev}");
                        if (ferfi)
                            Console.WriteLine("Neme: Férfi");
                        else 
                            Console.WriteLine("Neme: Nő");
                        Console.Write("Enterre tovább....");
                        Console.ReadLine();
                            break;
                    case 2:     //kilepes
                        Console.Clear();
                        Console.Write("Biztosan ki szeretnél lépni?(i/n): ");
                        if (Console.ReadKey().Key != ConsoleKey.I)
                            currentPoint = 0;
                        break;
                }
            }while (currentPoint!=2);
        }

        static void ShowMenu(int cPoint)
        {
            Console.Clear();
            if (cPoint == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("1. Személyes adatok bekérése");
            if (cPoint == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("2. Személyes adatok kiírása");
            if (cPoint == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("3. Kilépés");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
