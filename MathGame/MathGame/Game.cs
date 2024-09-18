using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    
    internal class Game
    {

        private bool randomOn = false;
        private int currentDifficulty;
        private int currentOperation;
        private List<History> history;

        public Game() {
            history = new List<History>();
        }

        public String ConvertDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    return "Easy";
                case 2:
                    return "Medium";
                case 3:
                    return "Hard";
            }
            return " ";
        }

        public void ShowHistory()
        {
            foreach (var item in history)
            {
                String diff = ConvertDifficulty(item.getDiff());
                Console.WriteLine("Difficulty : " + diff + "; Question: " + item.getCalculation() + "; Your answer: " + item.getUserResponse() + "; Correct Answer: " + item.getCorrectResponse() + "; result: " + item.isCorrect());
            }
            Console.ReadLine();
        }

        public int Difficulty()
        {
            while (true)
            {
                String difficulty = "1) Easy\n2) Normal\n3) Hard\n4) View History";
                Console.WriteLine(difficulty);
                int response;
                bool flag = int.TryParse(Console.ReadLine(), out response);
                if (!flag || (response != 1 && response != 2 && response != 3 && response != 4))
                {
                    Console.WriteLine("\nInvalid value\n");
                    Console.WriteLine(response);
                    continue;
                }
                return response;
            }
        }

        public int Operation()
        {
            while (true)
            {
                String operation = "1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Random\n6) Back";
                Console.WriteLine(operation);
                int response;
                bool flag = int.TryParse(Console.ReadLine(), out response);
                if (!flag || (response < 1 || response > 6))
                {
                    Console.WriteLine("\nInvalid value\n");
                    Console.WriteLine(response);
                    continue;
                }
                if (response == 5) randomOn = true; 
                return response;
            }
        }



        public int GenerateValue(int difficulty, int operation, Random rand)
        {
            int value = 0;
            switch (difficulty)
            {
                case 1:
                    value = rand.Next(0, 11);
                    break;
                case 2:
                    value = rand.Next(-101, 101);
                    break;
                case 3:
                    if (operation == 4) value = rand.Next(-101, 101);
                    else value = rand.Next(-1001, 1001);
                    break;
            }
            return value;
        }

        public int GetAnswer(int firstValue, int secondValue, int operation)
        {
            switch (operation)
            {
                case 1:
                    return firstValue + secondValue;
                case 2:
                    return firstValue - secondValue;
                case 3:
                    return firstValue * secondValue;
                case 4:
                    return firstValue / secondValue;
            }
            return 0;
        }


        public char ConvertOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    return '+';
                case 2:
                    return '-';
                case 3:
                    return '*';
                case 4:
                    return '/';
            }
            return ' ';
        }
        public void GameStart(int difficulty, int operation) {
            while (true)
            {
                Random rand = new Random();
                if (randomOn) operation = rand.Next(1,5);
                Console.WriteLine(operation);
                bool flag = true;
                int firstValue = 0;
                int secondValue = 0;
                Console.WriteLine("\nQuestion:");
                while (flag)
                {
                    firstValue = GenerateValue(difficulty, operation, rand);
                    secondValue = GenerateValue(difficulty, operation, rand);
                    flag = false;
                    if (operation == 4)
                    {
                        if (secondValue <= 0 || secondValue > 100)
                        {
                            flag = true;
                        }
                        else if (firstValue % secondValue != 0)
                        {
                            flag = true;
                        }
                    }
                }
                int correctAnswer = GetAnswer(firstValue, secondValue, operation);
                int userAnswer;
                char op = ConvertOperation(operation);
                String question = firstValue + " " + op + " " + secondValue;
                Console.WriteLine("What's the result of " + question + "?");
                bool parse = int.TryParse(Console.ReadLine(), out userAnswer);
                bool correct = false;
                if (parse && userAnswer == correctAnswer)
                {
                    Console.WriteLine("\nCongrats! You got the correct answer!");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("\nWrong, the correct answer was " + correctAnswer + " :/");
                }
                History historyValue = new History(currentDifficulty, question, userAnswer, correctAnswer, correct);
                history.Add(historyValue);
                Console.WriteLine("\n1) New Question\n2) Back");
                while (true)
                {
                    int back = 0;
                    bool exit = int.TryParse(Console.ReadLine(), out back);
                    if (!exit || back < 0 || back > 2)
                    {
                        Console.WriteLine("\nInvalid option");
                        continue;
                    }
                    else if (back == 1) break;
                    else
                    {
                        randomOn = false;
                        return;
                    }
                }

            }
        }

        public void Start()
        {
            while(true)
            {
                Console.WriteLine("\nPlease choose a difficulty");
                int diff = Difficulty();
                if (diff == 4)
                {
                    ShowHistory();
                }
                currentDifficulty = diff;
                while (true)
                {
                    Console.WriteLine("\nPlease choose an operation (or random game)");
                    currentOperation = Operation();
                    if (currentOperation == 6) break;
                    GameStart(currentDifficulty, currentOperation);
                }
            }
        }
    }
}
