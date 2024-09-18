using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Calculator
    {

        readonly static private int maxOption = 6;
        readonly static private int minOption = 1;
        private List<float> history = new List<float>();

        public void showHistory()
        {
            int length = history.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Result of operation " + i + ": " + history[i]);
            }
            Console.ReadLine();
            Console.Write("\n");
        }

        public void operation(int operation)
        {
            float firstValue = 0, secondValue = 0;
            bool firstCheck = false;
            bool secondCheck = false;

            while (!firstCheck)
            {
                Console.WriteLine("Please choose the first operand");
                firstCheck = float.TryParse(Console.ReadLine(), out firstValue);
                Console.Write("\n");
                if (!firstCheck)
                {
                    Console.WriteLine("Make sure to insert a float value");
                }
            }

            while (!secondCheck)
            {
                Console.WriteLine("Please choose the second operand");
                secondCheck = float.TryParse(Console.ReadLine(), out secondValue);
                if (!secondCheck)
                {
                    Console.WriteLine("Make sure to insert a float value");
                }
            }
            bool flag = true;
            float result = 0;
            String final = "The result is ";
            switch (operation)
            {
                case 1:
                    result = firstValue + secondValue;
                    break;
                case 2:
                    result = firstValue - secondValue;
                    break;
                case 3:
                    result = firstValue * secondValue;
                    break;
                case 4:
                    while (flag)
                    {
                        if (firstValue % secondValue == 0)
                        {
                            result = firstValue / secondValue;
                            flag = false;
                        }
                        else
                        {
                            Console.Write("\n");
                            Console.WriteLine("The result must be an integer while doing a division");
                            flag = float.TryParse(Console.ReadLine(), out secondValue);

                        }
                    }
                    break;

            }
            Console.Write("\n");
            Console.WriteLine("The final result is: " + result);
            history.Add(result);
            Console.Write("\n");
            Console.ReadLine();
        }



        public void calculator()
        {
            Calculator mathGame = new Calculator();
            bool ingame = true;
            while (ingame)
            {
                String operations = "1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) See History\n6) Exit";

                Console.WriteLine("Please choose an option");
                Console.WriteLine(operations);
                String inputOption = Console.ReadLine();

                int option;
                bool result = int.TryParse(inputOption, out option);
                Console.Write("\n");
                if (!result)
                {
                    Console.WriteLine("Invalid character!\n");
                    continue;
                }
                if (option < minOption || option > maxOption)
                {
                    Console.WriteLine("Invalid option!\n");
                    continue;
                }
                if (option == maxOption)
                {
                    break;
                }
                else if (option == 5)
                {
                    mathGame.showHistory();
                }
                else
                {
                    mathGame.operation(option);
                }
                Console.WriteLine("=====================");
            }
        }


    }
}
