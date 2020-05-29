using CIPSA.Util.ConsoleApp.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CIPSA.Util.ConsoleApp
{
    public static class ConsoleAppUtil
    {
        #region .: Public Methods :.
        public static string LineSeparator = "--------------------------------------------------------------";

        public static string ShowExerciseOption(string answerOfQuestion,
            List<int> exerciseNumbers, List<string> correctAnswerOfExerciseOption)
        {
            if (answerOfQuestion != string.Empty) return answerOfQuestion;

            PrintExerciseOptions(exerciseNumbers);

            answerOfQuestion = Console.ReadLine();

            if (!correctAnswerOfExerciseOption.Exists(ca => ca.Equals(answerOfQuestion)))
            {
                ConsoleAppPrintUtil.PrintTextWithLineSeparator("Lo siento pero la respuesta debe ser " + String.Join("/", exerciseNumbers) + " o E");
                answerOfQuestion = string.Empty;
                answerOfQuestion = ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);
            }

            return answerOfQuestion;
        }
        
        public static int Max(int firstNumber, int secondNumber)
        {
            return Math.Max(firstNumber, secondNumber);
        }

        public static int Max(ArrayList numbers)
        {
            int max = int.MinValue;

            for (int i = 0; i < numbers.Count; i++)
                max = Math.Max(max, (int)numbers[i]);

            return max;
        }

        public static int Min(ArrayList numbers)
        {
            int min = int.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
                min = Math.Min(min, (int)numbers[i]);

            return min;
        }

        public static long Sum(ArrayList numbers)
        {
            long sum = 0;

            foreach (var number in numbers)
                checked
                {
                    sum += long.Parse(number.ToString());
                }

            return sum;
        }

        public static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        public static bool TryFactorial(int number, out int factorialAnswer)
        {
            try
            {
                factorialAnswer = 1;
                checked
                {
                    for (int i = 2; i <= number; ++i)
                    {
                        factorialAnswer = factorialAnswer * i;
                    }
                }
            }
            catch (Exception)
            {
                factorialAnswer = 0;
            }

            return factorialAnswer > 0;
        }

        public static bool TryFactorialRecursive(int number, out int factorialAnswer)
        {
            if (number <= 1)
                factorialAnswer = 1;
            else
            {
                try
                {
                    int factorialAnswerRecursive;
                    checked
                    {
                        TryFactorialRecursive(number - 1, out factorialAnswerRecursive);
                        factorialAnswer = number * factorialAnswerRecursive;
                    }
                }
                catch (Exception)
                {
                    factorialAnswer = 0;
                }
            }

            return factorialAnswer > 0;
        }

        public static string Reverse(string answer)
        {
            var answerToReverse = answer.ToList();
            answerToReverse.Reverse();
            return string.Concat(answerToReverse);
        }

        public static TransferDataResultEnum TransferDataFromFile(string fileFromPath, string fileToPath)
        {
            var transferDataFromFile = TransferDataResultEnum.Transfer;
            try
            {
                var fileFrom = new StreamReader(fileFromPath);
                var fileTo = new StreamWriter(fileToPath);
                while (fileFrom.Peek() != -1) {
                    string buffer = fileFrom.ReadLine();
                    buffer = buffer.ToUpper();
                    fileTo.WriteLine(buffer);
                }
                fileFrom.Close();
                fileTo.Close();
            }
            catch (FileNotFoundException)
            {
                transferDataFromFile = TransferDataResultEnum.FileNotFound;
            }
            catch (Exception)
            {
                transferDataFromFile = TransferDataResultEnum.Unknown;
            }
            return transferDataFromFile;
        }

        public static ArrayList GetAbecedario(){
            var abecedario = new ArrayList(27) {
               "a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"
            };
            return abecedario;
        }

        public static ArrayList GetArrayListOfNumbers(int countOfNumbers, string text = "Valor")
        {
            var numbers = new ArrayList();

            int index = 0;
            while (index < countOfNumbers)
            {
                var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive($"{text} {index + 1}:");
                numbers.Add(number);
                index++;
            }

            return numbers;
        }

        public static ArrayList GetArrayListOfNumbersLessThan(int countOfNumbers, string text, int lessThan)
        {
            var numbers = new ArrayList();

            int index = 0;
            while (index < countOfNumbers)
            {
                var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive($"{text} {index + 1}:", lessThan);
                numbers.Add(number);
                index++;
            }

            return numbers;
        }

        public static decimal TryDivisionRecursive()
        {
            var result = 0M;

            var questions = new string[]{
                "Introduzca el primer número: ",
                "Introduzca el segundo número: "
            };

            var answer1 = ConsoleAppPrintUtil.PrintQuestionWithStringAnswer(questions[0]);

            var answer2 = ConsoleAppPrintUtil.PrintQuestionWithStringAnswer(questions[1]);

            var number1 = answer1 == string.Empty ? null : answer1;

            var number2 = answer2 == string.Empty ? null : answer2;

            result = ConsoleAppPrintUtil.PrintDivision(number1, number2);

            if (result == 0M)
                TryDivisionRecursive();

            return result;
        }
        #endregion

        #region .: Private Methods :.

        private static void PrintExerciseOptions(IEnumerable<int> exerciseNumbers)
        {
            Console.Clear();
            Console.WriteLine("Seleccione un ejercicio y presione <ENTER> para ver el resultado: ");
            Console.WriteLine(LineSeparator);
            exerciseNumbers.ToList().ForEach(exerciseNumber => Console.WriteLine($"Ejercicio {exerciseNumber} : {exerciseNumber}"));
            Console.WriteLine("Salir : E");
            Console.WriteLine("");
            Console.Write("> ");
        }

        #endregion
    }
}
