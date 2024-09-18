using System;
using System.Collections.Generic;

namespace MathGame
{
    public class MathGame
    {

        public MathGame()
        {
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please choose one of the options");
                String options = "1) Calculator\n2) Math Game\n3) Exit";
                Console.WriteLine(options);
                int option;
                bool result = int.TryParse(Console.ReadLine(), out option);
                if (!result || (option != 1 && option != 2 && option != 3))
                {
                    Console.WriteLine("\nPlease insert a valid value\n");
                    Console.ReadLine();
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n\n============CALCULATOR=================\n\n");
                        Calculator calculator = new Calculator();
                        calculator.calculator();
                        break;
                    case 2:
                        Console.WriteLine("\n\n============MATH GAME=================\n\n");
                        Game game = new Game();
                        game.Start();
                        break;
                    case 3:
                        return;

                }
            }
        }






    }
}