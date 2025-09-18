using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaladóMenu
{
    internal class Program
    {
        static string nev = "";
        static int szulev = 0;
        static bool ferfi = true;
        static double magassag = 1.7803;
        static void Main()
        {
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
                        InputData();
                        break;
                    case 1:     //adatkiirás
                        Console.WriteLine("***** ADATOK KIÍRÁSA *****");
                        Console.WriteLine($"Neve: {nev}");
                        Console.WriteLine($"Születési dátuma: {szulev}");
                        Console.WriteLine($"Magasság: {magassag:F2} méter");
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
        static void InputData()
        {
            Console.Clear();
            Console.WriteLine("***** ADATBEKÉRÉS *****");
            Console.Write("Add meg a neved: ");
            nev = Console.ReadLine();
            do
            {
                Console.Write("Add meg a születési dátumodat: ");
            } while (!int.TryParse(Console.ReadLine(), out szulev));
            Console.Write("Add meg a magasságodat(méterben): ");
            magassag = Convert.ToDouble(Console.ReadLine());
            Console.Write("Add meg a nemed(f/n): ");
            ferfi = Console.ReadLine().ToLower() == "f";
            Console.WriteLine("Az adatokat sikeresen rögzítettük. Enterre tovább....");
            Console.ReadLine();
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
        //-Console.ReadKey() használata -> Egy billentyűt azonosít be(pl fel nyíl),Console.Key osztály segítí a beazonosítást
        //-Switch case szerkezet -> egy érték alapján több ágú elágazást valósít meg, a switch után adjuk az értéket(pl változóban), a case után kezelünk egyes eseteket. A case ágat "break"-el le kell zárni
        //-Eljárás írás -> kell név és paraméter lista de nem jelzi külön szó hogy eljárást írunk. Az eljárás neve elé a void szót írjuk jelezve hogy nincs visszatérési érték
        //-Formázott kiirás(C# Tutorialba fent van a teljes anyag)
        //Tizedes érték(double) -> F betü jelzi hogy fix tizedes jegyet használunk, az F utáni szám a tizedes helyek számát jelzi 
        //Refaktorálás(refactoring) -> A kód egy részét kiszervezzük külön eljárásba vagy függvénybe, így a kód rövidebb,áttekinthetőbb, a kiszervezett rész újra felhasználható(javaslat: 7 sornál hosszab kód esetén érdemes ezt megfontolni)
        //A visual studio automatizálni tudja a refaktorálást
        //A static kulcsszó használata -> a C# OOP nyelv, az objektumok futásidőben jönnek létre. Az objektum minden tulajdonsága(változó,függvények) onnantól érhetők el hogy elindítjuk a programot és példányosítunk(LÉTREHOzunk onjektumot az osztályból). Ha az osztályban lévő változókat,függvényeket kódolási időben szeretnénk használni akkor ezt külön jeleznünk kell, erre szolgál a static
    }
}
