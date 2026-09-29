using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundos");
            Console.WriteLine("M = Minutos");
            Console.WriteLine("0 = Sair");
            Console.Write("Escolha uma opção: ");

            string option = Console.ReadLine()?.ToUpper();

            if (option == "0")
                Environment.Exit(0);

            if (option != "S" && option != "M")
            {
                Console.WriteLine("Opção inválida.");
                Thread.Sleep(1500);
                Menu();
                return;
            }

            Console.Write("Digite o tempo: ");
            bool parsed = int.TryParse(Console.ReadLine(), out int time);

            if (!parsed || time <= 0)
            {
                Console.WriteLine("Tempo inválido.");
                Thread.Sleep(1500);
                Menu();
                return;
            }

            int multiplier = option == "M" ? 60 : 1;

            Start(time * multiplier);
        }

        static void Start(int totalSeconds)
        {
            int currentTime = 0;

            while (currentTime < totalSeconds)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine($"Tempo: {currentTime}s");
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronômetro finalizado.");
            Thread.Sleep(2000);
            Menu();
        }
    }
}


